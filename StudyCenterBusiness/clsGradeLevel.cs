using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsGradeLevel
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public byte? GradeLevelID { get; set; }

        private string _oldGradeName = string.Empty;
        private string _gradeName = string.Empty;
        public string GradeName
        {
            get => _gradeName;

            set
            {
                // If the old GradeName is not set (indicating either a new user or the GradeName is being set for the first time),
                // initialize it with the current GradeName value to track changes.
                if (string.IsNullOrWhiteSpace(_oldGradeName))
                {
                    _oldGradeName = _gradeName;
                }

                _gradeName = value;
            }
        }

        public clsGradeLevel()
        {
            GradeLevelID = null;
            GradeName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsGradeLevel(byte? gradeLevelID, string gradeName)
        {
            GradeLevelID = gradeLevelID;
            GradeName = gradeName;

            Mode = enMode.Update;
        }

        private bool _Validate()
        {
            if (Mode == enMode.Update && !GradeLevelID.HasValue)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(_gradeName))
            {
                return false;
            }

            // If the old GradeName is different from the new GradeName or in AddNew Mode:
            // - In AddNew Mode: This indicates the new GradeName, requiring validation.
            // - In Update Mode: This indicates that the GradeName has been changed, so we need to check if it already exists in the database.
            // If the new GradeName already exists in the database, return false to indicate validation failure.
            if ((Mode == enMode.AddNew) || (_oldGradeName.Trim().ToLower() != _gradeName.Trim().ToLower()))
            {
                if (Exists(_gradeName))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Validates the current instance of <see cref="clsGradeLevel"/> using the <see cref="clsValidationHelper"/>.
        /// </summary>
        /// <returns>
        /// Returns true if the current instance passes all validation checks; otherwise, false.
        /// </returns>
        private bool _ValidateUsingHelperClass()
        {
            return clsValidationHelper.Validate
            (
            this,

            // ID Check: Ensure GradeLevelID is valid if in Update mode
            idCheck: gl => (gl.Mode != enMode.Update) || clsValidationHelper.HasValue(gl.GradeLevelID),

            // Value Check: Ensure GradeName is not empty
            valueCheck: gl => !string.IsNullOrWhiteSpace(gl.GradeName),

            // Additional Checks: Ensure GradeName does not already exist in the database
            additionalChecks: new (Func<clsGradeLevel, bool>, string)[]
            {
                (gl => (gl.Mode != enMode.AddNew && _oldGradeName.Trim().ToLower() == gl.GradeName.Trim().ToLower()) ||
                      !clsValidationHelper.ExistsInDatabase(() => Exists(gl.GradeName)),
                      "Grade name already exists.")
            }
            );
        }

        private bool _Add()
        {
            GradeLevelID = clsGradeLevelData.Add(GradeName);

            return (GradeLevelID.HasValue);
        }

        private bool _Update()
        {
            return clsGradeLevelData.Update(GradeLevelID.Value, GradeName);
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

        public static clsGradeLevel Find(byte? gradeLevelID)
        {
            string gradeName = string.Empty;

            bool isFound = clsGradeLevelData.GetInfoByID(gradeLevelID, ref gradeName);

            return (isFound) ? (new clsGradeLevel(gradeLevelID, gradeName)) : null;
        }

        public static bool Delete(byte? gradeLevelID)
            => clsGradeLevelData.Delete(gradeLevelID);

        public static bool Exists(byte? gradeLevelID)
            => clsGradeLevelData.Exists(gradeLevelID);

        public static bool Exists(string gradeName)
            => clsGradeLevelData.Exists(gradeName);

        public static DataTable All()
            => clsGradeLevelData.All();

        public static DataTable AllOnlyNames() => clsGradeLevelData.AllOnlyNames();

        public static string GetGradeLevelName(byte? gradeLevelID)
            => clsGradeLevelData.GetGradeLevelName(gradeLevelID);

        public static byte? GetGradeLevelID(string gradeName)
            => clsGradeLevelData.GetGradeLevelID(gradeName);
    }

}