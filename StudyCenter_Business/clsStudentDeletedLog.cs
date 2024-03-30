using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
    public class clsStudentDeletedLog
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? LogID { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int GradeLevelID { get; set; }
        public int CreatedByUserID { get; set; }
        public int DeletedByUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeletionDate { get; set; }

        public clsStudentDeletedLog()
        {
            LogID = null;
            StudentID = -1;
            StudentName = string.Empty;
            GradeLevelID = -1;
            CreatedByUserID = -1;
            DeletedByUserID = -1;
            CreationDate = DateTime.Now;
            DeletionDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsStudentDeletedLog(int? logID, int studentID,
            string studentName, int gradeLevelID, int createdByUserID,
            int deletedByUserID, DateTime creationDate, DateTime deletionDate)
        {
            LogID = logID;
            StudentID = studentID;
            StudentName = studentName;
            GradeLevelID = gradeLevelID;
            CreatedByUserID = createdByUserID;
            DeletedByUserID = deletedByUserID;
            CreationDate = creationDate;
            DeletionDate = deletionDate;

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            LogID = clsStudentDeletedLogData.Add(StudentID, StudentName,
                GradeLevelID, CreatedByUserID, DeletedByUserID, CreationDate);

            return (LogID.HasValue);
        }

        private bool _Update()
        {
            return clsStudentDeletedLogData.Update(LogID, StudentID, StudentName,
                GradeLevelID, CreatedByUserID, DeletedByUserID, CreationDate);
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

        public static clsStudentDeletedLog Find(int? logID)
        {
            int studentID = -1;
            string studentName = string.Empty;
            int gradeLevelID = -1;
            int createdByUserID = -1;
            int deletedByUserID = -1;
            DateTime creationDate = DateTime.Now;
            DateTime deletionDate = DateTime.Now;

            bool isFound = clsStudentDeletedLogData.GetInfoByID(logID, ref studentID, ref studentName, ref gradeLevelID, ref createdByUserID, ref deletedByUserID, ref creationDate, ref deletionDate);

            return (isFound) ? (new clsStudentDeletedLog(logID, studentID, studentName, gradeLevelID, createdByUserID, deletedByUserID, creationDate, deletionDate)) : null;
        }

        public static bool Delete(int? logID) => clsStudentDeletedLogData.Delete(logID);

        public static bool Exists(int? logID) => clsStudentDeletedLogData.Exists(logID);

        public static DataTable All() => clsStudentDeletedLogData.All();
    }
}
