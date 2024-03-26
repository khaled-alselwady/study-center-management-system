using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
public class clsClass
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? ClassID { get; set; }
public string ClassName { get; set; }
public byte Capacity { get; set; }
public string Description { get; set; }

public clsClass()
{
    ClassID = null;
    ClassName = string.Empty;
    Capacity = 0;
    Description = null;

    Mode = enMode.AddNew;
}

private clsClass(int? classID, string className, byte capacity, string description)
{
    ClassID = classID;
    ClassName = className;
    Capacity = capacity;
    Description = description;

    Mode = enMode.Update;
}

private bool _AddNewClass()
{
    ClassID = clsClassData.AddNewClass(ClassName, Capacity, Description);

    return (ClassID.HasValue);
}

private bool _UpdateClass()
{
return clsClassData.UpdateClass(ClassID, ClassName, Capacity, Description);
}

public bool Save()
{
switch (Mode)
{
case enMode.AddNew:
if (_AddNewClass())
{
Mode = enMode.Update;
return true;
}
else
{
return false;
}

case enMode.Update:
return _UpdateClass();
}

return false;
}

public static clsClass Find(int? classID)
{
string className = string.Empty;
byte capacity = 0;
string description = null;

bool isFound = clsClassData.GetClassInfoByID(classID, ref className, ref capacity, ref description);

return (isFound) ? (new clsClass(classID, className, capacity, description)) : null;
}

public static bool DeleteClass(int? classID)
{
return clsClassData.DeleteClass(classID);
}

public static bool DoesClassExist(int? classID)
{
return clsClassData.DoesClassExist(classID);
}

public static DataTable GetAllClasses()
{
return clsClassData.GetAllClasses();
}

}

}