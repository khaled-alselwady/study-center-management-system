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

private bool _AddNewSubjectTeacher()
{
    SubjectTeacherID = clsSubjectTeacherData.AddNewSubjectTeacher(SubjectGradeLevelID, TeacherID, AssignmentDate, IsActive);

    return (SubjectTeacherID.HasValue);
}

private bool _UpdateSubjectTeacher()
{
return clsSubjectTeacherData.UpdateSubjectTeacher(SubjectTeacherID, SubjectGradeLevelID, TeacherID, AssignmentDate, IsActive);
}

public bool Save()
{
switch (Mode)
{
case enMode.AddNew:
if (_AddNewSubjectTeacher())
{
Mode = enMode.Update;
return true;
}
else
{
return false;
}

case enMode.Update:
return _UpdateSubjectTeacher();
}

return false;
}

public static clsSubjectTeacher Find(int? subjectTeacherID)
{
int subjectGradeLevelID = -1;
int teacherID = -1;
DateTime assignmentDate = DateTime.Now;
bool isActive = false;

bool isFound = clsSubjectTeacherData.GetSubjectTeacherInfoByID(subjectTeacherID, ref subjectGradeLevelID, ref teacherID, ref assignmentDate, ref isActive);

return (isFound) ? (new clsSubjectTeacher(subjectTeacherID, subjectGradeLevelID, teacherID, assignmentDate, isActive)) : null;
}

public static bool DeleteSubjectTeacher(int? subjectTeacherID)
{
return clsSubjectTeacherData.DeleteSubjectTeacher(subjectTeacherID);
}

public static bool DoesSubjectTeacherExist(int? subjectTeacherID)
{
return clsSubjectTeacherData.DoesSubjectTeacherExist(subjectTeacherID);
}

public static DataTable GetAllSubjectsTeachers()
{
return clsSubjectTeacherData.GetAllSubjectsTeachers();
}

}

}