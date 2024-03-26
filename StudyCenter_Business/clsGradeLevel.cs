using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
public class clsGradeLevel
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? GradeLevelID { get; set; }
public string GradeName { get; set; }

public clsGradeLevel()
{
    GradeLevelID = null;
    GradeName = string.Empty;

    Mode = enMode.AddNew;
}

private clsGradeLevel(int? gradeLevelID, string gradeName)
{
    GradeLevelID = gradeLevelID;
    GradeName = gradeName;

    Mode = enMode.Update;
}

private bool _AddNewGradeLevel()
{
    GradeLevelID = clsGradeLevelData.AddNewGradeLevel(GradeName);

    return (GradeLevelID.HasValue);
}

private bool _UpdateGradeLevel()
{
return clsGradeLevelData.UpdateGradeLevel(GradeLevelID, GradeName);
}

public bool Save()
{
switch (Mode)
{
case enMode.AddNew:
if (_AddNewGradeLevel())
{
Mode = enMode.Update;
return true;
}
else
{
return false;
}

case enMode.Update:
return _UpdateGradeLevel();
}

return false;
}

public static clsGradeLevel Find(int? gradeLevelID)
{
string gradeName = string.Empty;

bool isFound = clsGradeLevelData.GetGradeLevelInfoByID(gradeLevelID, ref gradeName);

return (isFound) ? (new clsGradeLevel(gradeLevelID, gradeName)) : null;
}

public static bool DeleteGradeLevel(int? gradeLevelID)
{
return clsGradeLevelData.DeleteGradeLevel(gradeLevelID);
}

public static bool DoesGradeLevelExist(int? gradeLevelID)
{
return clsGradeLevelData.DoesGradeLevelExist(gradeLevelID);
}

public static DataTable GetAllGradeLevels()
{
return clsGradeLevelData.GetAllGradeLevels();
}

}

}