using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsSubjectGradeLevel
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? SubjectGradeLevelID { get; set; }

        private int? _oldSubjectID = null;
        private int? _subjectID = null;
        public int? SubjectID
        {
            get => _subjectID;

            set
            {
                if (!_oldSubjectID.HasValue)
                {
                    _oldSubjectID = _subjectID;
                }

                _subjectID = value;
            }
        }

        private byte? _oldGradeLevelID = null;
        private byte? _gradeLevelID = null;
        public byte? GradeLevelID
        {
            get => _gradeLevelID;

            set
            {
                if (!_oldGradeLevelID.HasValue)
                {
                    _oldGradeLevelID = _gradeLevelID;
                }

                _gradeLevelID = value;
            }
        }

        public decimal Fees { get; set; }
        public string Description { get; set; }

        public clsSubject SubjectInfo { get; private set; }
        public clsGradeLevel GradeLevelInfo { get; private set; }

        public clsSubjectGradeLevel()
        {
            SubjectGradeLevelID = null;
            SubjectID = null;
            GradeLevelID = null;
            Fees = -1M;
            Description = null;

            Mode = enMode.AddNew;
        }

        private clsSubjectGradeLevel(int? subjectGradeLevelID, int? subjectID,
            byte? gradeLevelID, decimal fees, string description)
        {
            SubjectGradeLevelID = subjectGradeLevelID;
            SubjectID = subjectID;
            GradeLevelID = gradeLevelID;
            Fees = fees;
            Description = description;

            SubjectInfo = clsSubject.Find(subjectID);
            GradeLevelInfo = clsGradeLevel.Find(gradeLevelID);

            Mode = enMode.Update;
        }

        private bool _Validate()
        {
            if (Mode == enMode.Update && !SubjectGradeLevelID.HasValue)
            {
                return false;
            }

            if (!SubjectID.HasValue || !GradeLevelID.HasValue)
            {
                return false;
            }

            if ((Mode == enMode.AddNew) || (_oldSubjectID != _subjectID || _oldGradeLevelID != _gradeLevelID))
            {
                if (Exists(_subjectID, _gradeLevelID))
                {
                    return false;
                }
            }

            if (Fees < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the current instance of <see cref="clsSubjectGradeLevel"/> using the <see cref="clsValidationHelper"/>.
        /// </summary>
        /// <returns>
        /// Returns true if the current instance passes all validation checks; otherwise, false.
        /// </returns>
        private bool _ValidateUsingHelperClass()
        {
            return clsValidationHelper.Validate
            (
            this,

            // ID Check: Ensure SubjectGradeLevelID is valid if in Update mode
            idCheck: sgl => (Mode != enMode.Update || clsValidationHelper.HasValue(sgl.SubjectGradeLevelID)),

            // Value Check: Ensure SubjectID and GradeLevelID are provided, and Fees is non-negative
            valueCheck: sgl => clsValidationHelper.HasValue(sgl.SubjectID) &&
                               clsValidationHelper.HasValue(sgl.GradeLevelID) &&
                               sgl.Fees >= 0,


            // Additional Checks: Check various conditions and provide corresponding error messages
            additionalChecks: new (Func<clsSubjectGradeLevel, bool>, string)[]
            {
                // Check if the combination of SubjectID and GradeLevelID already exists in the database
                ((sgl) => !((Mode == enMode.AddNew || sgl._oldSubjectID != sgl._subjectID || sgl._oldGradeLevelID != sgl._gradeLevelID) &&
                          clsValidationHelper.ExistsInDatabase(() => Exists(sgl.SubjectID, sgl.GradeLevelID))),
                          "Subject grade level already exists."),
            }
            );
        }

        private bool _Add()
        {
            SubjectGradeLevelID = clsSubjectGradeLevelData.Add(SubjectID.Value, GradeLevelID.Value,
                Fees, Description);

            return (SubjectGradeLevelID.HasValue);
        }

        private bool _Update()
        {
            return clsSubjectGradeLevelData.Update(SubjectGradeLevelID.Value, SubjectID.Value,
                GradeLevelID.Value, Fees, Description);
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

        public static clsSubjectGradeLevel Find(int? subjectGradeLevelID)
        {
            int? subjectID = null;
            byte? gradeLevelID = null;
            decimal fees = -1M;
            string description = null;

            bool isFound = clsSubjectGradeLevelData.GetInfoByID(subjectGradeLevelID,
                ref subjectID, ref gradeLevelID, ref fees, ref description);

            return (isFound) ? (new clsSubjectGradeLevel(subjectGradeLevelID,
                subjectID, gradeLevelID, fees, description)) : null;
        }

        public static bool Delete(int? subjectGradeLevelID)
            => clsSubjectGradeLevelData.Delete(subjectGradeLevelID);

        public static bool Exists(int? subjectGradeLevelID)
            => clsSubjectGradeLevelData.Exists(subjectGradeLevelID);

        public static bool Exists(int? subjectID, int? gradeLevelID)
            => clsSubjectGradeLevelData.Exists(subjectID, gradeLevelID);

        public static DataTable AllInPages(short pageNumber, int rowsPerPage)
            => clsSubjectGradeLevelData.AllInPages(pageNumber, rowsPerPage);

        public static DataTable AllUntaughtSubjectsByTeacher(int? teacherID)
            => clsSubjectGradeLevelData.AllUntaughtSubjectsByTeacher(teacherID);

        public static DataTable AllTeachersTeachSubject(int? subjectGradeLevelID)
            => clsSubjectGradeLevelData.AllTeachersTeachSubject(subjectGradeLevelID);

        public static int Count()
            => clsSubjectGradeLevelData.Count();
    }

}