using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
    public class clsTeacher
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? TeacherID { get; set; }
        public int? PersonID { get; set; }
        public byte? EducationLevelID { get; set; }
        public byte? TeachingExperience { get; set; }
        public string Certifications { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime CreationDate { get; set; }

        public clsPerson PersonInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }
        public clsEducationLevel EducationLevelInfo { get; private set; }

        public clsTeacher()
        {
            TeacherID = null;
            PersonID = null;
            EducationLevelID = 0;
            TeachingExperience = null;
            Certifications = null;
            CreatedByUserID = null;
            CreationDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsTeacher(int? teacherID, int? personID, byte? educationLevelID,
            byte? teachingExperience, string certifications, int? createdByUserID,
            DateTime creationDate)
        {
            TeacherID = teacherID;
            PersonID = personID;
            EducationLevelID = educationLevelID;
            TeachingExperience = teachingExperience;
            Certifications = certifications;
            CreatedByUserID = createdByUserID;
            CreationDate = creationDate;

            PersonInfo = clsPerson.Find(personID);
            CreatedByUserInfo = clsUser.Find(createdByUserID);
            EducationLevelInfo = clsEducationLevel.Find(educationLevelID);

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            TeacherID = clsTeacherData.Add(PersonID, EducationLevelID, TeachingExperience,
                Certifications, CreatedByUserID);

            return (TeacherID.HasValue);
        }

        private bool _Update()
        {
            return clsTeacherData.Update(TeacherID, PersonID, EducationLevelID, TeachingExperience,
                Certifications, CreatedByUserID);
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

        public static clsTeacher FindByTeacherID(int? teacherID)
        {
            int? personID = null;
            byte? educationLevelID = null;
            byte? teachingExperience = null;
            string certifications = null;
            int? createdByUserID = null;
            DateTime creationDate = DateTime.Now;

            bool isFound = clsTeacherData.GetInfoByTeacherID(teacherID, ref personID, ref educationLevelID,
                ref teachingExperience, ref certifications, ref createdByUserID, ref creationDate);

            return (isFound) ? (new clsTeacher(teacherID, personID, educationLevelID,
                                teachingExperience, certifications, createdByUserID, creationDate))
                             : null;
        }

        public static clsTeacher FindByPersonID(int? personID)
        {
            int? teacherID = null;
            byte? educationLevelID = null;
            byte? teachingExperience = null;
            string certifications = null;
            int? createdByUserID = null;
            DateTime creationDate = DateTime.Now;

            bool isFound = clsTeacherData.GetInfoByPersonID(personID, ref teacherID, ref educationLevelID,
                ref teachingExperience, ref certifications, ref createdByUserID, ref creationDate);

            return (isFound) ? (new clsTeacher(teacherID, personID, educationLevelID,
                                teachingExperience, certifications, createdByUserID, creationDate))
                             : null;
        }

        public static bool Delete(int? teacherID) => clsTeacherData.Delete(teacherID);

        public static bool Exists(int? teacherID) => clsTeacherData.Exists(teacherID);

        public static DataTable All() => clsTeacherData.All();

        public static int Count() => clsTeacherData.Count();

        public static bool IsTeacher(int? personID) => clsTeacherData.IsTeacher(personID);
    }
}