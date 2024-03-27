using StudyCenter_DataAccess;
using System.Data;

namespace StudyCenter_Business
{
    public class clsTeacher
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? TeacherID { get; set; }
        public int PersonID { get; set; }
        public string EducationLevel { get; set; }
        public byte? TeachingExperience { get; set; }
        public string Certifications { get; set; }
        public bool IsActive { get; set; }

        public clsTeacher()
        {
            TeacherID = null;
            PersonID = -1;
            EducationLevel = string.Empty;
            TeachingExperience = null;
            Certifications = null;
            IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsTeacher(int? teacherID, int personID, string educationLevel, byte? teachingExperience, string certifications, bool isActive)
        {
            TeacherID = teacherID;
            PersonID = personID;
            EducationLevel = educationLevel;
            TeachingExperience = teachingExperience;
            Certifications = certifications;
            IsActive = isActive;

            Mode = enMode.Update;
        }

        private bool _AddNewTeacher()
        {
            TeacherID = clsTeacherData.AddNewTeacher(PersonID, EducationLevel, TeachingExperience, Certifications, IsActive);

            return (TeacherID.HasValue);
        }

        private bool _UpdateTeacher()
        {
            return clsTeacherData.UpdateTeacher(TeacherID, PersonID, EducationLevel, TeachingExperience, Certifications, IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTeacher())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTeacher();
            }

            return false;
        }

        public static clsTeacher Find(int? teacherID)
        {
            int personID = -1;
            string educationLevel = string.Empty;
            byte? teachingExperience = null;
            string certifications = null;
            bool isActive = false;

            bool isFound = clsTeacherData.GetTeacherInfoByID(teacherID, ref personID, ref educationLevel, ref teachingExperience, ref certifications, ref isActive);

            return (isFound) ? (new clsTeacher(teacherID, personID, educationLevel, teachingExperience, certifications, isActive)) : null;
        }

        public static bool DeleteTeacher(int? teacherID)
        {
            return clsTeacherData.DeleteTeacher(teacherID);
        }

        public static bool DoesTeacherExist(int? teacherID)
        {
            return clsTeacherData.DoesTeacherExist(teacherID);
        }

        public static DataTable GetAllTeachers()
        {
            return clsTeacherData.GetAllTeachers();
        }

    }

}