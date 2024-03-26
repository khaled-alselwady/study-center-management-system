using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
public class clsGroup
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? GroupID { get; set; }
public string GroupName { get; set; }
public int ClassID { get; set; }
public int TeacherID { get; set; }
public int SubjectGradeLevelID { get; set; }
public int MeetingTimeID { get; set; }
public byte StudentCount { get; set; }
public DateTime CreationDate { get; set; }
public DateTime? LastModifiedDate { get; set; }
public bool IsActive { get; set; }

public clsGroup()
{
    GroupID = null;
    GroupName = string.Empty;
    ClassID = -1;
    TeacherID = -1;
    SubjectGradeLevelID = -1;
    MeetingTimeID = -1;
    StudentCount = 0;
    CreationDate = DateTime.Now;
    LastModifiedDate = null;
    IsActive = false;

    Mode = enMode.AddNew;
}

private clsGroup(int? groupID, string groupName, int classID, int teacherID, int subjectGradeLevelID, int meetingTimeID, byte studentCount, DateTime creationDate, DateTime? lastModifiedDate, bool isActive)
{
    GroupID = groupID;
    GroupName = groupName;
    ClassID = classID;
    TeacherID = teacherID;
    SubjectGradeLevelID = subjectGradeLevelID;
    MeetingTimeID = meetingTimeID;
    StudentCount = studentCount;
    CreationDate = creationDate;
    LastModifiedDate = lastModifiedDate;
    IsActive = isActive;

    Mode = enMode.Update;
}

private bool _AddNewGroup()
{
    GroupID = clsGroupData.AddNewGroup(GroupName, ClassID, TeacherID, SubjectGradeLevelID, MeetingTimeID, StudentCount, CreationDate, LastModifiedDate, IsActive);

    return (GroupID.HasValue);
}

private bool _UpdateGroup()
{
return clsGroupData.UpdateGroup(GroupID, GroupName, ClassID, TeacherID, SubjectGradeLevelID, MeetingTimeID, StudentCount, CreationDate, LastModifiedDate, IsActive);
}

public bool Save()
{
switch (Mode)
{
case enMode.AddNew:
if (_AddNewGroup())
{
Mode = enMode.Update;
return true;
}
else
{
return false;
}

case enMode.Update:
return _UpdateGroup();
}

return false;
}

public static clsGroup Find(int? groupID)
{
string groupName = string.Empty;
int classID = -1;
int teacherID = -1;
int subjectGradeLevelID = -1;
int meetingTimeID = -1;
byte studentCount = 0;
DateTime creationDate = DateTime.Now;
DateTime? lastModifiedDate = null;
bool isActive = false;

bool isFound = clsGroupData.GetGroupInfoByID(groupID, ref groupName, ref classID, ref teacherID, ref subjectGradeLevelID, ref meetingTimeID, ref studentCount, ref creationDate, ref lastModifiedDate, ref isActive);

return (isFound) ? (new clsGroup(groupID, groupName, classID, teacherID, subjectGradeLevelID, meetingTimeID, studentCount, creationDate, lastModifiedDate, isActive)) : null;
}

public static bool DeleteGroup(int? groupID)
{
return clsGroupData.DeleteGroup(groupID);
}

public static bool DoesGroupExist(int? groupID)
{
return clsGroupData.DoesGroupExist(groupID);
}

public static DataTable GetAllGroups()
{
return clsGroupData.GetAllGroups();
}

}

}