using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsGroup
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? GroupID { get; set; }
        public string GroupName { get; set; }
        public int? ClassID { get; set; }
        public int? TeacherID { get; set; }
        public int? SubjectTeacherID { get; set; }
        public int? MeetingTimeID { get; set; }
        public byte StudentCount { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public clsClass ClassInfo { get; private set; }
        public clsTeacher TeacherInfo { get; private set; }
        public clsSubjectTeacher SubjectTeacherInfo { get; private set; }
        public clsMeetingTime MeetingTimeInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }

        public clsGroup()
        {
            GroupID = null;
            GroupName = string.Empty;
            ClassID = null;
            TeacherID = null;
            SubjectTeacherID = null;
            MeetingTimeID = null;
            StudentCount = 0;
            CreatedByUserID = null;
            CreationDate = DateTime.Now;
            LastModifiedDate = null;
            IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsGroup(int? groupID, string groupName, int? classID,
            int? teacherID, int? subjectTeacherID, int? meetingTimeID,
            byte studentCount, int? createdByUserID, DateTime creationDate,
             DateTime? lastModifiedDate, bool isActive)
        {
            GroupID = groupID;
            GroupName = groupName;
            ClassID = classID;
            TeacherID = teacherID;
            SubjectTeacherID = subjectTeacherID;
            MeetingTimeID = meetingTimeID;
            StudentCount = studentCount;
            CreatedByUserID = createdByUserID;
            CreationDate = creationDate;
            LastModifiedDate = lastModifiedDate;
            IsActive = isActive;

            ClassInfo = clsClass.Find(classID);
            TeacherInfo = clsTeacher.FindByTeacherID(teacherID);
            SubjectTeacherInfo = clsSubjectTeacher.Find(subjectTeacherID);
            MeetingTimeInfo = clsMeetingTime.Find(meetingTimeID);
            CreatedByUserInfo = clsUser.FindBy(createdByUserID, clsUser.enFindBy.UserID);

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            GroupID = clsGroupData.Add(ClassID, TeacherID, SubjectTeacherID,
                MeetingTimeID, CreatedByUserID);

            if (GroupID.HasValue)
            {
                GroupName = GetGroupName(GroupID);
                return true;
            }

            return false;
        }

        private bool _Update()
        {
            return clsGroupData.Update(GroupID, ClassID, TeacherID,
                SubjectTeacherID, MeetingTimeID, IsActive);
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

        public static clsGroup Find(int? groupID)
        {
            string groupName = string.Empty;
            int? classID = null;
            int? teacherID = null;
            int? subjectTeacherID = null;
            int? meetingTimeID = null;
            byte studentCount = 0;
            int? createdByUserID = null;
            DateTime creationDate = DateTime.Now;
            DateTime? lastModifiedDate = null;
            bool isActive = true;

            bool isFound = clsGroupData.GetInfoByID(groupID, ref groupName,
                ref classID, ref teacherID, ref subjectTeacherID,
                ref meetingTimeID, ref studentCount,
                ref createdByUserID, ref creationDate,
                ref lastModifiedDate, ref isActive);

            return (isFound) ? (new clsGroup(groupID, groupName, classID,
                                teacherID, subjectTeacherID, meetingTimeID,
                                studentCount, createdByUserID, creationDate,
                                lastModifiedDate, isActive))
                             : null;
        }

        public static bool Delete(int? groupID)
            => clsGroupData.Delete(groupID);

        public static bool Exists(int? groupID)
            => clsGroupData.Exists(groupID);

        public static DataTable All()
            => clsGroupData.All();

        public static DataTable AllInPages(short PageNumber, int RowsPerPage)
            => clsGroupData.AllInPages(PageNumber, RowsPerPage);

        public static DataTable AllStudentsInGroup(int? groupID)
            => clsGroupData.AllStudentsInGroup(groupID);

        public static string GetGroupName(int? groupID)
            => clsGroupData.GetGroupName(groupID);

        public static byte GetMaxCapacityOfStudentsInGroup(int? groupID)
            => clsGroupData.GetMaxCapacityOfStudentsInGroup(groupID);

        public static DataTable AllGroupsAreTaughtByTeacher(int? teacherID)
            => clsGroupData.AllGroupsAreTaughtByTeacher(teacherID);

        public static DataTable AllGroupNames()
            => clsGroupData.AllGroupNames();

        public static DataTable AllScheduleForToday()
            => clsGroupData.AllScheduleForToday();

        public static int Count()
            => clsGroupData.Count();

        public static decimal GetSubjectFeesByGroupID(int? groupID)
            => clsGroupData.GetSubjectFeesByGroupID(groupID);

        public string GetStudentCount()
            => StudentCount.ToString() + "/" + ClassInfo?.Capacity
            + ((StudentCount <= 1) ? "  Student" : "  Students");

    }
}