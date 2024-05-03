using StudyCenterDataAccess;
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
            ListUsers = 4
        }

        public int? UserID { get; set; }
        public int? PersonID { get; set; }
        public string Username { get; set; }
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

        private bool _Add()
        {
            UserID = clsUserData.Add(PersonID, Username, Password, Permissions, IsActive);

            return (UserID.HasValue);
        }

        private bool _Update()
        {
            return clsUserData.Update(UserID, PersonID, Username, Password, Permissions, IsActive);
        }

        public bool Save()
        {
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

            if (((int)enPermissions.ListUsers & Permissions) == (int)enPermissions.ListUsers)
            {
                permissions.Add("List Users");
            }

            return permissions;
        }
    }
}