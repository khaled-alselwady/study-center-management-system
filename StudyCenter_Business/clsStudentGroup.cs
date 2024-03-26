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
        public int StudentID { get; set; }
        public int GroupID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }

        public clsStudentGroup()
        {
            StudentGroupID = null;
            StudentID = -1;
            GroupID = -1;
            EnrollmentDate = DateTime.Now;
            IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsStudentGroup(int? studentGroupID, int studentID, int groupID, DateTime enrollmentDate, bool isActive)
        {
            StudentGroupID = studentGroupID;
            StudentID = studentID;
            GroupID = groupID;
            EnrollmentDate = enrollmentDate;
            IsActive = isActive;

            Mode = enMode.Update;
        }

        private bool _AddNewStudentGroup()
        {
            StudentGroupID = clsStudentGroupData.AddNewStudentGroup(StudentID, GroupID, EnrollmentDate, IsActive);

            return (StudentGroupID.HasValue);
        }

        private bool _UpdateStudentGroup()
        {
            return clsStudentGroupData.UpdateStudentGroup(StudentGroupID, StudentID, GroupID, EnrollmentDate, IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStudentGroup())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateStudentGroup();
            }

            return false;
        }

        public static clsStudentGroup Find(int? studentGroupID)
        {
            int studentID = -1;
            int groupID = -1;
            DateTime enrollmentDate = DateTime.Now;
            bool isActive = false;

            bool isFound = clsStudentGroupData.GetStudentGroupInfoByID(studentGroupID, ref studentID, ref groupID, ref enrollmentDate, ref isActive);

            return (isFound) ? (new clsStudentGroup(studentGroupID, studentID, groupID, enrollmentDate, isActive)) : null;
        }

        public static bool DeleteStudentGroup(int? studentGroupID)
        {
            return clsStudentGroupData.DeleteStudentGroup(studentGroupID);
        }

        public static bool DoesStudentGroupExist(int? studentGroupID)
        {
            return clsStudentGroupData.DoesStudentGroupExist(studentGroupID);
        }

        public static DataTable GetAllStudentsGroups()
        {
            return clsStudentGroupData.GetAllStudentsGroups();
        }

    }

}