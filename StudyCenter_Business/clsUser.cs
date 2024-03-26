using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
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

public clsUser()
{
    UserID = null;
    PersonID = -1;
    Username = string.Empty;
    Password = string.Empty;
    Permissions = -1;

    Mode = enMode.AddNew;
}

private clsUser(int? userID, int personID, string username, string password, int permissions)
{
    UserID = userID;
    PersonID = personID;
    Username = username;
    Password = password;
    Permissions = permissions;

    Mode = enMode.Update;
}

private bool _AddNewUser()
{
    UserID = clsUserData.AddNewUser(PersonID, Username, Password, Permissions);

    return (UserID.HasValue);
}

private bool _UpdateUser()
{
return clsUserData.UpdateUser(UserID, PersonID, Username, Password, Permissions);
}

public bool Save()
{
switch (Mode)
{
case enMode.AddNew:
if (_AddNewUser())
{
Mode = enMode.Update;
return true;
}
else
{
return false;
}

case enMode.Update:
return _UpdateUser();
}

return false;
}

public static clsUser Find(int? userID)
{
int personID = -1;
string username = string.Empty;
string password = string.Empty;
int permissions = -1;

bool isFound = clsUserData.GetUserInfoByID(userID, ref personID, ref username, ref password, ref permissions);

return (isFound) ? (new clsUser(userID, personID, username, password, permissions)) : null;
}

public static clsUser Find(string username)
{
int? userID = null;
int personID = -1;
string password = string.Empty;
int permissions = -1;

    bool isFound = clsUserData.GetUserInfoByUsername(ref userID, ref personID, username, ref password, ref permissions);

return (isFound) ? (new clsUser(userID, personID, username, password, permissions)) : null;
}

public static clsUser Find(string username, string password)
{
int? userID = null;
int personID = -1;
int permissions = -1;
    bool isFound = clsUserData.GetUserInfoByUsernameAndPassword(ref userID, ref personID, username, password, ref permissions);

return (isFound) ? (new clsUser(userID, personID, username, password, permissions)) : null;
}

public static bool DeleteUser(int? userID)
{
return clsUserData.DeleteUser(userID);
}

public static bool DoesUserExist(int? userID)
{
return clsUserData.DoesUserExist(userID);
}

public static bool DoesUserExist(string username)
{
    return clsUserData.DoesUserExist(username);
}

public static bool DoesUserExist(string username, string password)
{
    return clsUserData.DoesUserExist(username, password);
}

public static DataTable GetAllUsers()
{
return clsUserData.GetAllUsers();
}

}

}