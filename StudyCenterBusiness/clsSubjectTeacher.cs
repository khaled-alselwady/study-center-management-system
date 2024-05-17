using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsSubjectTeacher
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? SubjectTeacherID { get; set; }
        public int? SubjectGradeLevelID { get; set; }
        public int? TeacherID { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public clsSubjectGradeLevel SubjectGradeLevelInfo { get; private set; }
        public clsTeacher TeacherInfo { get; private set; }

        public clsSubjectTeacher()
        {
            SubjectTeacherID = null;
            SubjectGradeLevelID = null;
            TeacherID = null;
            AssignmentDate = DateTime.Now;
            LastModifiedDate = null;
            IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsSubjectTeacher(int? subjectTeacherID, int? subjectGradeLevelID,
            int? teacherID, DateTime assignmentDate, DateTime? lastModifiedDate, bool isActive)
        {
            SubjectTeacherID = subjectTeacherID;
            SubjectGradeLevelID = subjectGradeLevelID;
            TeacherID = teacherID;
            AssignmentDate = assignmentDate;
            LastModifiedDate = lastModifiedDate;
            IsActive = isActive;

            SubjectGradeLevelInfo = clsSubjectGradeLevel.Find(subjectGradeLevelID);
            TeacherInfo = clsTeacher.FindByTeacherID(teacherID);

            Mode = enMode.Update;
        }

        private bool _Validate()
        {
            if (Mode == enMode.Update && !SubjectTeacherID.HasValue)
            {
                return false;
            }

            if (!SubjectGradeLevelID.HasValue || !TeacherID.HasValue)
            {
                return false;
            }

            if ((Mode == enMode.AddNew) && AssignmentDate.Date < DateTime.Now.Date)
            {
                return false;
            }

            if ((Mode == enMode.Update) && LastModifiedDate.HasValue && AssignmentDate.Date > LastModifiedDate.Value.Date)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the current instance of <see cref="clsSubjectTeacher"/> using the <see cref="clsValidationHelper"/>.
        /// </summary>
        /// <returns>
        /// Returns true if the current instance passes all validation checks; otherwise, false.
        /// </returns>
        private bool _ValidateUsingHelperClass()
        {
            return clsValidationHelper.Validate
            (
            this,

            // ID Check: Ensure SubjectTeacherID is valid if in Update mode
            idCheck: subjectTeacher => (Mode != enMode.Update || clsValidationHelper.HasValue(subjectTeacher.SubjectTeacherID)),

            // Value Check: Ensure SubjectGradeLevelID and TeacherID are provided
            valueCheck: subjectTeacher => clsValidationHelper.HasValue(subjectTeacher.SubjectGradeLevelID) &&
                                          clsValidationHelper.HasValue(subjectTeacher.TeacherID),

            // Date Check: Ensure AssignmentDate is valid if in AddNew mode
            dateCheck: subjectTeacher => Mode != enMode.AddNew ||
                       clsValidationHelper.DateIsNotValid(subjectTeacher.AssignmentDate, DateTime.Now),

            // Additional Checks: Check various conditions and provide corresponding error messages
            additionalChecks: new (Func<clsSubjectTeacher, bool>, string)[]
            {
                // Check if AssignmentDate is not after LastModifiedDate in Update mode
                (subjectTeacher => !(Mode == enMode.Update && subjectTeacher.LastModifiedDate.HasValue &&
                                !clsValidationHelper.DateIsNotValid(subjectTeacher.AssignmentDate, subjectTeacher.LastModifiedDate.Value)),
                                "Assignment date cannot be after the last modified date.")
            }
            );
        }

        private bool _Add()
        {
            SubjectTeacherID = clsSubjectTeacherData.Add(SubjectGradeLevelID.Value, TeacherID.Value);

            return (SubjectTeacherID.HasValue);
        }

        private bool _Update()
        {
            return clsSubjectTeacherData.Update(SubjectTeacherID.Value,
                SubjectGradeLevelID.Value, TeacherID.Value, IsActive);
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

        public static clsSubjectTeacher Find(int? subjectTeacherID)
        {
            int? subjectGradeLevelID = null;
            int? teacherID = null;
            DateTime assignmentDate = DateTime.Now;
            DateTime? lastModifiedDate = null;
            bool isActive = true;

            bool isFound = clsSubjectTeacherData.GetInfoByID(subjectTeacherID,
                ref subjectGradeLevelID, ref teacherID, ref assignmentDate,
                ref lastModifiedDate, ref isActive);

            return (isFound) ? (new clsSubjectTeacher(subjectTeacherID,
                                subjectGradeLevelID, teacherID, assignmentDate,
                                lastModifiedDate, isActive))
                             : null;
        }

        public static bool Delete(int? subjectTeacherID)
            => clsSubjectTeacherData.Delete(subjectTeacherID);

        public static bool Exists(int? subjectTeacherID)
            => clsSubjectTeacherData.Exists(subjectTeacherID);

        public static DataTable All()
            => clsSubjectTeacherData.All();

        public static bool IsTeachingSubject(int? teacherID, int? subjectGradeLevelID)
            => clsSubjectTeacherData.IsTeachingSubject(teacherID, subjectGradeLevelID);

        public static DataTable AllSubjectsTaughtByTeacher(int? teacherID)
            => clsSubjectTeacherData.AllSubjectsTaughtByTeacher(teacherID);

        public static DataTable AllActiveSubjectsTaughtByTeacher(int? teacherID)
            => clsSubjectTeacherData.AllActiveSubjectsTaughtByTeacher(teacherID);
    }
}