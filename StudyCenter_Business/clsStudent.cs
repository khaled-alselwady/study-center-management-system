using StudyCenter_DataAccess;
using System.Data;

namespace StudyCenter_Business
{
    public class clsStudent
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? StudentID { get; set; }
        public int PersonID { get; set; }
        public int GradeLevelID { get; set; }
        public bool IsActive { get; set; }

        public clsStudent()
        {
            StudentID = null;
            PersonID = -1;
            GradeLevelID = -1;
            IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsStudent(int? studentID, int personID, int gradeLevelID, bool isActive)
        {
            StudentID = studentID;
            PersonID = personID;
            GradeLevelID = gradeLevelID;
            IsActive = isActive;

            Mode = enMode.Update;
        }

        private bool _AddNewStudent()
        {
            StudentID = clsStudentData.AddNewStudent(PersonID, GradeLevelID, IsActive);

            return (StudentID.HasValue);
        }

        private bool _UpdateStudent()
        {
            return clsStudentData.UpdateStudent(StudentID, PersonID, GradeLevelID, IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStudent())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateStudent();
            }

            return false;
        }

        public static clsStudent Find(int? studentID)
        {
            int personID = -1;
            int gradeLevelID = -1;
            bool isActive = false;

            bool isFound = clsStudentData.GetStudentInfoByID(studentID, ref personID, ref gradeLevelID, ref isActive);

            return (isFound) ? (new clsStudent(studentID, personID, gradeLevelID, isActive)) : null;
        }

        public static bool DeleteStudent(int? studentID)
        {
            return clsStudentData.DeleteStudent(studentID);
        }

        public static bool DoesStudentExist(int? studentID)
        {
            return clsStudentData.DoesStudentExist(studentID);
        }

        public static DataTable GetAllStudents()
        {
            return clsStudentData.GetAllStudents();
        }

    }

}