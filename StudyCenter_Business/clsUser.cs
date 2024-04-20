using StudyCenterDataAccess;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            UserID = null;
            PersonID = -1;
            Username = string.Empty;
            Password = string.Empty;
            Permissions = -1;
            IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsUser(int? userID, int personID, string username, string password, int permissions, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            Username = username;
            Password = password;
            Permissions = permissions;
            IsActive = isActive;

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

        public static clsUser Find(int? userID)
        {
            int personID = -1;
            string username = string.Empty;
            string password = string.Empty;
            int permissions = -1;
            bool isActive = false;

            bool isFound = clsUserData.GetInfoByID(userID, ref personID, ref username, ref password, ref permissions, ref isActive);

            return (isFound) ? (new clsUser(userID, personID, username, password, permissions, isActive)) : null;
        }

        public static clsUser Find(string username)
        {
            int? userID = null;
            int personID = -1;
            string password = string.Empty;
            int permissions = -1;
            bool isActive = false;

            bool isFound = clsUserData.GetInfoByUsername(ref userID, ref personID, username, ref password, ref permissions, ref isActive);

            return (isFound) ? (new clsUser(userID, personID, username, password, permissions, isActive)) : null;
        }

        public static clsUser Find(string username, string password)
        {
            int? userID = null;
            int personID = -1;
            int permissions = -1;
            bool isActive = false;
            bool isFound = clsUserData.GetInfoByUsernameAndPassword(ref userID, ref personID, username, password, ref permissions, ref isActive);

            return (isFound) ? (new clsUser(userID, personID, username, password, permissions, isActive)) : null;
        }

        public static bool Delete(int? userID)
        {
            return clsUserData.Delete(userID);
        }

        public static bool Exists(int? userID)
        {
            return clsUserData.Exists(userID);
        }

        public static bool Exists(string username)
        {
            return clsUserData.Exists(username);
        }

        public static bool Exists(string username, string password)
        {
            return clsUserData.Exists(username, password);
        }

        public static DataTable All()
        {
            return clsUserData.All();
        }
    }
}