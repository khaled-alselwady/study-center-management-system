using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
public class clsSubject
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? SubjectID { get; set; }
public string SubjectName { get; set; }

public clsSubject()
{
    SubjectID = null;
    SubjectName = string.Empty;

    Mode = enMode.AddNew;
}

private clsSubject(int? subjectID, string subjectName)
{
    SubjectID = subjectID;
    SubjectName = subjectName;

    Mode = enMode.Update;
}

private bool _AddNewSubject()
{
    SubjectID = clsSubjectData.AddNewSubject(SubjectName);

    return (SubjectID.HasValue);
}

private bool _UpdateSubject()
{
return clsSubjectData.UpdateSubject(SubjectID, SubjectName);
}

public bool Save()
{
switch (Mode)
{
case enMode.AddNew:
if (_AddNewSubject())
{
Mode = enMode.Update;
return true;
}
else
{
return false;
}

case enMode.Update:
return _UpdateSubject();
}

return false;
}

public static clsSubject Find(int? subjectID)
{
string subjectName = string.Empty;

bool isFound = clsSubjectData.GetSubjectInfoByID(subjectID, ref subjectName);

return (isFound) ? (new clsSubject(subjectID, subjectName)) : null;
}

public static bool DeleteSubject(int? subjectID)
{
return clsSubjectData.DeleteSubject(subjectID);
}

public static bool DoesSubjectExist(int? subjectID)
{
return clsSubjectData.DoesSubjectExist(subjectID);
}

public static DataTable GetAllSubjects()
{
return clsSubjectData.GetAllSubjects();
}

}

}