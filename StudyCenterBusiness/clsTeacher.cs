using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsTeacher
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? TeacherID { get; set; }

        private int? _oldPersonID = null;
        private int? _personID = null;
        public int? PersonID
        {
            get => _personID;

            set
            {
                if (!_oldPersonID.HasValue)
                {
                    _oldPersonID = _personID;
                }

                _personID = value;
            }
        }

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
            CreatedByUserInfo = clsUser.FindBy(createdByUserID, clsUser.enFindBy.UserID);
            EducationLevelInfo = clsEducationLevel.Find(educationLevelID);

            Mode = enMode.Update;
        }

        private bool _Validate()
        {
            if (Mode == enMode.Update && !TeacherID.HasValue)
            {
                return false;
            }

            if (!PersonID.HasValue || !EducationLevelID.HasValue || !CreatedByUserID.HasValue)
            {
                return false;
            }

            if ((Mode == enMode.AddNew) || _oldPersonID != _personID)
            {
                if (IsTeacher(_personID))
                {
                    return false;
                }
            }

            if (Mode == enMode.AddNew && CreationDate.Date < DateTime.Now.Date)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the current instance of <see cref="clsTeacher"/> using the <see cref="clsValidationHelper"/>.
        /// </summary>
        /// <returns>
        /// Returns true if the current instance passes all validation checks; otherwise, false.
        /// </returns>
        private bool _ValidateUsingHelperClass()
        {
            return clsValidationHelper.Validate
            (
            this,

            // ID Check: Ensure TeacherID is valid if in Update mode
            idCheck: teacher => (Mode != enMode.Update || clsValidationHelper.HasValue(teacher.TeacherID)),

            // Value Check: Ensure PersonID, EducationLevelID, and CreatedByUserID are provided
            valueCheck: teacher => clsValidationHelper.HasValue(teacher.PersonID) &&
                       clsValidationHelper.HasValue(teacher.EducationLevelID) &&
                       clsValidationHelper.HasValue(teacher.CreatedByUserID),

            // Date Check: Ensure CreationDate is valid if in AddNew mode
            dateCheck: teacher => Mode != enMode.AddNew ||
                       clsValidationHelper.DateIsNotValid(teacher.CreationDate, DateTime.Now),

            // Additional Checks: Check various conditions and provide corresponding error messages
            additionalChecks: new (Func<clsTeacher, bool>, string)[]
            {
                // Check if PersonID already exists as a teacher, considering mode and previous value
                (teacher => (Mode != enMode.AddNew && _oldPersonID == teacher.PersonID) ||
                            !clsValidationHelper.ExistsInDatabase(() => IsTeacher(teacher.PersonID)),
                            "Teacher already exists."),
            }
            );
        }

        private bool _Add()
        {
            TeacherID = clsTeacherData.Add(PersonID.Value, EducationLevelID.Value, TeachingExperience,
                Certifications, CreatedByUserID.Value);

            return (TeacherID.HasValue);
        }

        private bool _Update()
        {
            return clsTeacherData.Update(TeacherID.Value, PersonID.Value, EducationLevelID.Value, TeachingExperience,
                Certifications, CreatedByUserID.Value);
        }

        public bool Save()
        {
            if (!_ValidateUsingHelperClass())
            {
                return false;
            }

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

        public static bool Delete(int? teacherID, int? deletedByUserID)
            => clsTeacherData.Delete(teacherID, deletedByUserID);

        public static bool Exists(int? teacherID) => clsTeacherData.Exists(teacherID);

        public static DataTable All() => clsTeacherData.All();

        public static int Count() => clsTeacherData.Count();

        public static bool IsTeacher(int? personID) => clsTeacherData.IsTeacher(personID);

        public static DataTable AllInPages(short PageNumber, int RowsPerPage)
            => clsTeacherData.AllInPages(PageNumber, RowsPerPage);

        public static string GetFullName(int? teacherID)
            => clsTeacherData.GetFullName(teacherID);
    }
}