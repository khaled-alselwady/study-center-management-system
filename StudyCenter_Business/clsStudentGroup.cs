using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
    public class clsStudentGroup
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? StudentGroupID { get; set; }
        public int? StudentID { get; set; }
        public int? GroupID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public clsStudentGroup()
        {
            StudentGroupID = null;
            StudentID = null;
            GroupID = null;
            StartDate = DateTime.Now;
            EndDate = null;
            IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsStudentGroup(int? studentGroupID, int? studentID,
            int? groupID, DateTime startDate, DateTime? endDate, bool isActive)
        {
            StudentGroupID = studentGroupID;
            StudentID = studentID;
            GroupID = groupID;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            StudentGroupID = clsStudentGroupData.Add(StudentID, GroupID);

            return (StudentGroupID.HasValue);
        }

        private bool _Update()
        {
            return clsStudentGroupData.Update(StudentGroupID, StudentID, GroupID, EndDate, IsActive);
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

        public static clsStudentGroup Find(int? studentGroupID)
        {
            int? studentID = null;
            int? groupID = null;
            DateTime startDate = DateTime.Now;
            DateTime? endDate = null;
            bool isActive = false;

            bool isFound = clsStudentGroupData.GetInfoByID(studentGroupID, ref studentID,
                ref groupID, ref startDate, ref endDate, ref isActive);

            return (isFound) ? (new clsStudentGroup(studentGroupID, studentID, groupID,
                startDate, endDate, isActive)) : null;
        }

        public static bool Delete(int? studentGroupID)
            => clsStudentGroupData.Delete(studentGroupID);

        public static bool Delete(int? studentID, int? groupID)
            => clsStudentGroupData.Delete(studentID, groupID);

        public static bool Exists(int? studentGroupID)
            => clsStudentGroupData.Exists(studentGroupID);

        public static bool IsStudentAssignedToGroup(int? studentID, int? groupID)
            => clsStudentGroupData.IsStudentAssignedToGroup(studentID, groupID);

        public static DataTable All()
            => clsStudentGroupData.All();

        public static DataTable AllAvailableGroupsForStudent(int? studentID)
            => clsStudentGroupData.AllAvailableGroupsForStudent(studentID);
    }
}