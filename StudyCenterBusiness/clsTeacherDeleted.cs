using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsTeacherDeleted
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? LogID { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public int EducationLevelID { get; set; }
        public int CreatedByUserID { get; set; }
        public int DeletedByUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeletionDate { get; set; }

        public clsTeacherDeleted()
        {
            LogID = null;
            TeacherID = -1;
            TeacherName = string.Empty;
            EducationLevelID = -1;
            CreatedByUserID = -1;
            DeletedByUserID = -1;
            CreationDate = DateTime.Now;
            DeletionDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsTeacherDeleted(int? logID, int teacherID,
            string teacherName, int educationLevelID,
            int createdByUserID, int deletedByUserID,
            DateTime creationDate, DateTime deletionDate)
        {
            LogID = logID;
            TeacherID = teacherID;
            TeacherName = teacherName;
            EducationLevelID = educationLevelID;
            CreatedByUserID = createdByUserID;
            DeletedByUserID = deletedByUserID;
            CreationDate = creationDate;
            DeletionDate = deletionDate;

            Mode = enMode.Update;
        }

        public static clsTeacherDeleted Find(int? logID)
        {
            int teacherID = -1;
            string teacherName = string.Empty;
            int educationLevelID = -1;
            int createdByUserID = -1;
            int deletedByUserID = -1;
            DateTime creationDate = DateTime.Now;
            DateTime deletionDate = DateTime.Now;

            bool isFound = clsTeacherDeletedData.GetInfoByID(logID, ref teacherID, ref teacherName, ref educationLevelID, ref createdByUserID, ref deletedByUserID, ref creationDate, ref deletionDate);

            return (isFound) ? (new clsTeacherDeleted(logID, teacherID, teacherName, educationLevelID, createdByUserID, deletedByUserID, creationDate, deletionDate)) : null;
        }

        public static DataTable All() => clsTeacherDeletedData.All();
    }
}
