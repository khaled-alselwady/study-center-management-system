using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
public class clsSubjectTeacher
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? SubjectTeacherID { get; set; }
public int SubjectGradeLevelID { get; set; }
public int TeacherID { get; set; }
public DateTime AssignmentDate { get; set; }
public bool IsActive { get; set; }

public clsSubjectTeacher()
{
    SubjectTeacherID = null;
    SubjectGradeLevelID = -1;
    TeacherID = -1;
    AssignmentDate = DateTime.Now;
    IsActive = false;

    Mode = enMode.AddNew;
}

private clsSubjectTeacher(int? subjectTeacherID, int subjectGradeLevelID, int teacherID, DateTime assignmentDate, bool isActive)
{
    SubjectTeacherID = subjectTeacherID;
    SubjectGradeLevelID = subjectGradeLevelID;
    TeacherID = teacherID;
    AssignmentDate = assignmentDate;
    IsActive = isActive;

    Mode = enMode.Update;
}

private bool _Add()
{
    SubjectTeacherID = clsSubjectTeacherData.Add(SubjectGradeLevelID, TeacherID, AssignmentDate, IsActive);

    return (SubjectTeacherID.HasValue);
}

private bool _Update()
{
return clsSubjectTeacherData.Update(SubjectTeacherID, SubjectGradeLevelID, TeacherID, AssignmentDate, IsActive);
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

public static clsSubjectTeacher Find(int? subjectTeacherID)
{
int subjectGradeLevelID = -1;
int teacherID = -1;
DateTime assignmentDate = DateTime.Now;
bool isActive = false;

bool isFound = clsSubjectTeacherData.GetInfoByID(subjectTeacherID, ref subjectGradeLevelID, ref teacherID, ref assignmentDate, ref isActive);

return (isFound) ? (new clsSubjectTeacher(subjectTeacherID, subjectGradeLevelID, teacherID, assignmentDate, isActive)) : null;
}

public static bool Delete(int? subjectTeacherID)
{
return clsSubjectTeacherData.Delete(subjectTeacherID);
}

public static bool Exists(int? subjectTeacherID)
{
return clsSubjectTeacherData.Exists(subjectTeacherID);
}

public static DataTable All()
{
return clsSubjectTeacherData.All();
}

}

}