using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsStudent
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? StudentID { get; set; }
        public int? PersonID { get; set; }
        public byte? GradeLevelID { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime CreationDate { get; set; }

        public clsPerson PersonInfo { get; private set; }
        public clsGradeLevel GradeLevelInfo { get; private set; }
        public clsUser CreatedByUserInfo { get; private set; }

        public clsStudent()
        {
            StudentID = null;
            PersonID = null;
            GradeLevelID = null;
            CreatedByUserID = null;
            CreationDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsStudent(int? studentID, int? personID, byte? gradeLevelID,
            int? createdByUserID, DateTime creationDate)
        {
            StudentID = studentID;
            PersonID = personID;
            GradeLevelID = gradeLevelID;
            CreatedByUserID = createdByUserID;
            CreationDate = creationDate;

            PersonInfo = clsPerson.Find(personID);
            GradeLevelInfo = clsGradeLevel.Find(gradeLevelID);
            CreatedByUserInfo = clsUser.FindBy(createdByUserID, clsUser.enFindBy.UserID);

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            StudentID = clsStudentData.Add(PersonID, GradeLevelID, CreatedByUserID);

            return (StudentID.HasValue);
        }

        private bool _Update()
        {
            return clsStudentData.Update(StudentID, PersonID, GradeLevelID, CreatedByUserID);
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

        public static clsStudent FindByStudentID(int? studentID)
        {
            int? personID = null;
            byte? gradeLevelID = null;
            int? createdByUserID = null;
            DateTime creationDate = DateTime.Now;

            bool isFound = clsStudentData.GetInfoByStudentID(studentID, ref personID,
                ref gradeLevelID, ref createdByUserID, ref creationDate);

            return (isFound) ? (new clsStudent(studentID, personID, gradeLevelID,
                                createdByUserID, creationDate))
                             : null;
        }

        public static clsStudent FindByPersonID(int? personID)
        {
            int? studentID = null;
            byte? gradeLevelID = null;
            int? createdByUserID = null;
            DateTime creationDate = DateTime.Now;

            bool isFound = clsStudentData.GetInfoByPersonID(personID, ref studentID,
                ref gradeLevelID, ref createdByUserID, ref creationDate);

            return (isFound) ? (new clsStudent(studentID, personID, gradeLevelID,
                                createdByUserID, creationDate))
                             : null;
        }

        public static bool Delete(int? studentID, int? deletedByUserID)
            => clsStudentData.Delete(studentID, deletedByUserID);

        public static bool Exists(int? studentID)
        => clsStudentData.Exists(studentID);

        public static DataTable All() => clsStudentData.All();

        public static int Count() => clsStudentData.Count();

        public static bool IsStudent(int? personID)
            => clsStudentData.IsStudent(personID);

        public static bool IsStudentActive(int? personID)
            => clsStudentData.IsStudentActive(personID);

        public static DataTable AllInPages(short PageNumber, int RowsPerPage)
            => clsStudentData.AllInPages(PageNumber, RowsPerPage);

        public static byte? GetGradeLevelIDOfStudent(int? studentID)
            => clsStudentData.GetGradeLevelIDOfStudent(studentID);
    }
}