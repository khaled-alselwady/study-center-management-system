using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
public class clsSubjectGradeLevel
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? SubjectGradeLevelID { get; set; }
public int SubjectID { get; set; }
public int GradeLevelID { get; set; }
public decimal Fees { get; set; }
public string Description { get; set; }

public clsSubjectGradeLevel()
{
    SubjectGradeLevelID = null;
    SubjectID = -1;
    GradeLevelID = -1;
    Fees = -1M;
    Description = null;

    Mode = enMode.AddNew;
}

private clsSubjectGradeLevel(int? subjectGradeLevelID, int subjectID, int gradeLevelID, decimal fees, string description)
{
    SubjectGradeLevelID = subjectGradeLevelID;
    SubjectID = subjectID;
    GradeLevelID = gradeLevelID;
    Fees = fees;
    Description = description;

    Mode = enMode.Update;
}

private bool _AddNewSubjectGradeLevel()
{
    SubjectGradeLevelID = clsSubjectGradeLevelData.AddNewSubjectGradeLevel(SubjectID, GradeLevelID, Fees, Description);

    return (SubjectGradeLevelID.HasValue);
}

private bool _UpdateSubjectGradeLevel()
{
return clsSubjectGradeLevelData.UpdateSubjectGradeLevel(SubjectGradeLevelID, SubjectID, GradeLevelID, Fees, Description);
}

public bool Save()
{
switch (Mode)
{
case enMode.AddNew:
if (_AddNewSubjectGradeLevel())
{
Mode = enMode.Update;
return true;
}
else
{
return false;
}

case enMode.Update:
return _UpdateSubjectGradeLevel();
}

return false;
}

public static clsSubjectGradeLevel Find(int? subjectGradeLevelID)
{
int subjectID = -1;
int gradeLevelID = -1;
decimal fees = -1M;
string description = null;

bool isFound = clsSubjectGradeLevelData.GetSubjectGradeLevelInfoByID(subjectGradeLevelID, ref subjectID, ref gradeLevelID, ref fees, ref description);

return (isFound) ? (new clsSubjectGradeLevel(subjectGradeLevelID, subjectID, gradeLevelID, fees, description)) : null;
}

public static bool DeleteSubjectGradeLevel(int? subjectGradeLevelID)
{
return clsSubjectGradeLevelData.DeleteSubjectGradeLevel(subjectGradeLevelID);
}

public static bool DoesSubjectGradeLevelExist(int? subjectGradeLevelID)
{
return clsSubjectGradeLevelData.DoesSubjectGradeLevelExist(subjectGradeLevelID);
}

public static DataTable GetAllSubjectsGradeLevels()
{
return clsSubjectGradeLevelData.GetAllSubjectsGradeLevels();
}

}

}