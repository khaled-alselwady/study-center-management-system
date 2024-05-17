using StudyCenterDataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enFindBy
        {
            UserID,
            PersonID,
            Username,
            UsernameAndPassword
        };

        public enum enPermissions
        {
            All = -1,
            AddUser = 1,
            UpdateUser = 2,
            DeleteUser = 4,
            ListUsers = 8
        }

        public int? UserID { get; set; }

        private int? _oldPersonID = null;
        private int? _personID = null;
        public int? PersonID
        {
            get => _personID;

            set
            {
                if (!_oldPersonID.HasValue)
                {
                    _oldPersonID = _personID;
                }

                _personID = value;
            }
        }

        private string _oldUsername = string.Empty;
        private string _userName = string.Empty;
        public string Username
        {
            get => _userName;

            set
            {
                // If the old username is not set (indicating either a new user or the username is being set for the first time),
                // initialize it with the current username value to track changes.
                if (string.IsNullOrWhiteSpace(_oldUsername))
                {
                    _oldUsername = _userName;
                }

                _userName = value;
            }
        }

        public string Password { get; set; }
        public int Permissions { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo { get; private set; }

        public clsUser()
        {
            UserID = null;
            PersonID = null;
            Username = string.Empty;
            Password = string.Empty;
            Permissions = -1;
            IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsUser(int? userID, int? personID, string username, string password,
            int permissions, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            Username = username;
            Password = password;
            Permissions = permissions;
            IsActive = isActive;

            PersonInfo = clsPerson.Find(personID);

            Mode = enMode.Update;
        }

        private bool _Validate()
        {
            if (Mode == enMode.Update && !UserID.HasValue)
            {
                return false;
            }

            if (!PersonID.HasValue)
            {
                return false;
            }

            if ((Mode == enMode.AddNew) || _oldPersonID != _personID)
            {
                if (Exist(_personID, enFindBy.PersonID))
                {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(_userName))
            {
                return false;
            }

            // If the old username is different from the new username:
            // - In AddNew Mode: This indicates the new username, requiring validation.
            // - In Update Mode: This indicates that the username has been changed, so we need to check if it already exists in the database.
            // If the new username already exists in the database, return false to indicate validation failure.
            if ((Mode == enMode.AddNew) || (_oldUsername.Trim().ToLower() != _userName.Trim().ToLower()))
            {
                if (Exist(_userName, enFindBy.Username))
                {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the current instance of <see cref="clsUser"/> using the <see cref="clsValidationHelper"/>.
        /// </summary>
        /// <returns>
        /// Returns true if the current instance passes all validation checks; otherwise, false.
        /// </returns>
        private bool _ValidateUsingHelperClass()
        {
            return clsValidationHelper.Validate
            (
            this,

            // ID Check: Ensure UserID is valid if in Update mode
            idCheck: user => (Mode != enMode.Update || clsValidationHelper.HasValue(user.UserID)),

            // Value Check: Ensure PersonID is provided
            valueCheck: user => clsValidationHelper.HasValue(user.PersonID),

            // Additional Checks: Check various conditions and provide corresponding error messages
            additionalChecks: new (Func<clsUser, bool>, string)[]
            {
                // Check if PersonID already exists, considering mode and previous value
                (user => (Mode != enMode.AddNew && _oldPersonID == user.PersonID) ||
                         !clsValidationHelper.ExistsInDatabase(() => Exist(user.PersonID, enFindBy.PersonID)),
                         "Person already exists."),

                // Check if Username is not empty
                (user => clsValidationHelper.IsNotEmpty(user.Username), "Username is empty."),

                // Check if Username already exists, considering mode and previous value
                (user => (Mode != enMode.AddNew && _oldUsername.Trim().ToLower() == user.Username.Trim().ToLower()) ||
                         !clsValidationHelper.ExistsInDatabase(() => Exist(user.Username, enFindBy.Username)),
                         "Username already exists."),

                // Check if Password is not empty
                (user => clsValidationHelper.IsNotEmpty(user.Password), "Password is empty.")
            }
            );
        }

        private bool _Add()
        {
            UserID = clsUserData.Add(PersonID.Value, Username, Password, Permissions, IsActive);

            return (UserID.HasValue);
        }

        private bool _Update()
        {
            return clsUserData.Update(UserID.Value, PersonID.Value, Username, Password, Permissions, IsActive);
        }

        public bool Save()
        {
            if (!_ValidateUsingHelperClass())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        private static clsUser _FindByUserID(int? UserID)
        {
            int? PersonID = null;
            string Username = string.Empty;
            string Password = string.Empty;
            int permissions = -1;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserID(UserID, ref PersonID,
                ref Username, ref Password, ref permissions, ref IsActive);

            return (IsFound) ? (new clsUser(UserID, PersonID, Username, Password, permissions, IsActive)) : null;
        }

        private static clsUser _FindByPersonID(int? PersonID)
        {
            int? UserID = null;
            string Username = string.Empty;
            string Password = string.Empty;
            int permissions = -1;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByPersonID(PersonID, ref UserID,
                ref Username, ref Password, ref permissions, ref IsActive);

            return (IsFound) ? (new clsUser(UserID, PersonID, Username, Password, permissions, IsActive)) : null;
        }

        private static clsUser _FindByUsername(string Username)
        {
            int? UserID = null;
            int? PersonID = null;
            string Password = string.Empty;
            int permissions = -1;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsername(ref UserID, ref PersonID,
                Username, ref Password, ref permissions, ref IsActive);

            return (IsFound) ? (new clsUser(UserID, PersonID, Username, Password, permissions, IsActive)) : null;
        }

        private static clsUser _FindByUsernameAndPassword(string Username, string Password)
        {
            int? UserID = null;
            int? PersonID = null;
            bool IsActive = false;
            int permissions = -1;
            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword(ref UserID, ref PersonID, Username,
                Password, ref permissions, ref IsActive);

            return (IsFound) ? (new clsUser(UserID, PersonID, Username, Password, permissions, IsActive)) : null;
        }

        public static clsUser FindBy<T>(T Data, enFindBy ItemToFindBy)
        {
            switch (ItemToFindBy)
            {
                case enFindBy.UserID:
                    return _FindByUserID(Data as int?);

                case enFindBy.PersonID:
                    return _FindByPersonID(Data as int?);

                case enFindBy.Username:
                    return _FindByUsername(Data as string);

                default:
                    return null;
            }
        }

        public static clsUser FindBy<T>(T Data1, T Data2, enFindBy ItemToFindBy = enFindBy.UsernameAndPassword)
        {
            switch (ItemToFindBy)
            {
                case enFindBy.UsernameAndPassword:
                    return _FindByUsernameAndPassword(Data1 as string, Data2 as string);

                default:
                    return null;
            }
        }

        public static bool Delete(int? userID)
            => clsUserData.Delete(userID);

        private static bool _ExistByUserID(int? UserID)
            => clsUserData.ExistsByUserID(UserID);

        private static bool _ExistByPersonID(int? PersonID)
            => clsUserData.ExistsByPersonID(PersonID);

        private static bool _ExistByUsername(string Username)
            => clsUserData.ExistsByUsername(Username);

        private static bool _ExistByUsernameAndPassword(string Username, string Password)
            => clsUserData.ExistsByUsernameAndPassword(Username, Password);

        public static bool Exist(object Data, enFindBy ItemToFindBy)
        {
            switch (ItemToFindBy)
            {
                case enFindBy.UserID:
                    return _ExistByUserID((int?)Data ?? null);

                case enFindBy.PersonID:
                    return _ExistByPersonID((int?)Data ?? null);

                case enFindBy.Username:
                    return _ExistByUsername((string)Data ?? null);

                default:
                    return false;
            }
        }

        public static bool Exist(object Data1, object Data2, enFindBy ItemToFindBy = enFindBy.UsernameAndPassword)
        {
            switch (ItemToFindBy)
            {
                case enFindBy.UsernameAndPassword:
                    return _ExistByUsernameAndPassword((string)Data1 ?? null, (string)Data2 ?? null);

                default:
                    return false;
            }
        }

        public static DataTable All()
            => clsUserData.All();

        public static int Count()
            => clsUserData.Count();

        public bool ChangePassword(string NewPassword)
            => ChangePassword(UserID, NewPassword);

        public static bool ChangePassword(int? UserID, string NewPassword)
            => clsUserData.ChangePassword(UserID, NewPassword);

        public List<string> PermissionsText()
        {
            if (Permissions == -1)
                return new List<string>() { "Admin" };

            List<string> permissions = new List<string>();

            if (((int)enPermissions.AddUser & Permissions) == (int)enPermissions.AddUser)
            {
                permissions.Add("Add User");
            }

            if (((int)enPermissions.UpdateUser & Permissions) == (int)enPermissions.UpdateUser)
            {
                permissions.Add("Update User");
            }

            if (((int)enPermissions.DeleteUser & Permissions) == (int)enPermissions.DeleteUser)
            {
                permissions.Add("Delete User");
            }

            if (((int)enPermissions.ListUsers & Permissions) == (int)enPermissions.ListUsers)
            {
                permissions.Add("List Users");
            }

            return permissions;
        }
    }
}