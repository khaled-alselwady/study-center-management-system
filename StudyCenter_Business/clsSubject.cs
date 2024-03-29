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

private bool _Add()
{
    SubjectID = clsSubjectData.Add(SubjectName);

    return (SubjectID.HasValue);
}

private bool _Update()
{
return clsSubjectData.Update(SubjectID, SubjectName);
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

public static clsSubject Find(int? subjectID)
{
string subjectName = string.Empty;

bool isFound = clsSubjectData.GetInfoByID(subjectID, ref subjectName);

return (isFound) ? (new clsSubject(subjectID, subjectName)) : null;
}

public static bool Delete(int? subjectID)
{
return clsSubjectData.Delete(subjectID);
}

public static bool Exists(int? subjectID)
{
return clsSubjectData.Exists(subjectID);
}

public static DataTable All()
{
return clsSubjectData.All();
}

}

}