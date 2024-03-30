using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
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

        private bool _Add()
        {
            LogID = clsTeacherDeletedData.Add(TeacherID, TeacherName,
                EducationLevelID, CreatedByUserID, DeletedByUserID, CreationDate);

            return (LogID.HasValue);
        }

        private bool _Update()
        {
            return clsTeacherDeletedData.Update(LogID, TeacherID,
                TeacherName, EducationLevelID, CreatedByUserID,
                DeletedByUserID, CreationDate);
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

        public static bool Delete(int? logID) => clsTeacherDeletedData.Delete(logID);

        public static bool Exists(int? logID) => clsTeacherDeletedData.Exists(logID);

        public static DataTable All() => clsTeacherDeletedData.All();
    }
}
