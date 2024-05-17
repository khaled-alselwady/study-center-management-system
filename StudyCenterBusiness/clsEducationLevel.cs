using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsEducationLevel
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public byte? EducationLevelID { get; set; }

        private string _oldLevelName = string.Empty;
        private string _levelName = string.Empty;
        public string LevelName
        {
            get => _levelName;

            set
            {
                // If the old LevelName is not set (indicating either a new user or the LevelName is being set for the first time),
                // initialize it with the current LevelName value to track changes.
                if (string.IsNullOrWhiteSpace(_oldLevelName))
                {
                    _oldLevelName = _levelName;
                }

                _levelName = value;
            }
        }

        public clsEducationLevel()
        {
            EducationLevelID = null;
            LevelName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsEducationLevel(byte? educationLevelID, string levelName)
        {
            EducationLevelID = educationLevelID;
            LevelName = levelName;

            Mode = enMode.Update;
        }

        private bool _Validate()
        {
            if (Mode == enMode.Update && !EducationLevelID.HasValue)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(_levelName))
            {
                return false;
            }

            // If the old LevelName is different from the new LevelName or in AddNew Mode:
            // - In AddNew Mode: This indicates the new LevelName, requiring validation.
            // - In Update Mode: This indicates that the LevelName has been changed, so we need to check if it already exists in the database.
            // If the new LevelName already exists in the database, return false to indicate validation failure.
            if ((Mode == enMode.AddNew) || (_oldLevelName.Trim().ToLower() != _levelName.Trim().ToLower()))
            {
                if (Exists(_levelName))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Validates the current instance of <see cref="clsEducationLevel"/> using the <see cref="clsValidationHelper"/>.
        /// </summary>
        /// <returns>
        /// Returns true if the current instance passes all validation checks; otherwise, false.
        /// </returns>
        private bool _ValidateUsingHelperClass()
        {
            return clsValidationHelper.Validate
            (
            this,

            // ID Check: Ensure EducationLevelID is valid if in Update mode
            idCheck: el => (el.Mode != enMode.Update) || clsValidationHelper.HasValue(el.EducationLevelID),

            // Value Check: Ensure LevelName is not empty
            valueCheck: el => !string.IsNullOrWhiteSpace(el.LevelName),

            // Additional Checks: Ensure LevelName does not already exist in the database
            additionalChecks: new (Func<clsEducationLevel, bool>, string)[]
            {
                (el => (el.Mode != enMode.AddNew && _oldLevelName.Trim().ToLower() == el.LevelName.Trim().ToLower()) ||
                      !clsValidationHelper.ExistsInDatabase(() => Exists(el.LevelName)),
                      "Education level name already exists.")
            }
            );
        }

        private bool _Add()
        {
            EducationLevelID = clsEducationLevelData.Add(LevelName);

            return (EducationLevelID.HasValue);
        }

        private bool _Update()
        {
            return clsEducationLevelData.Update(EducationLevelID.Value, LevelName);
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

        public static clsEducationLevel Find(byte? educationLevelID)
        {
            string levelName = string.Empty;

            bool isFound = clsEducationLevelData.GetInfoByID(educationLevelID, ref levelName);

            return (isFound) ? (new clsEducationLevel(educationLevelID, levelName)) : null;
        }

        public static bool Delete(byte? educationLevelID)
            => clsEducationLevelData.Delete(educationLevelID);

        public static bool Exists(byte? educationLevelID)
            => clsEducationLevelData.Exists(educationLevelID);

        public static bool Exists(string levelName)
            => clsEducationLevelData.Exists(levelName);

        public static DataTable All() => clsEducationLevelData.All();

        public static DataTable AllOnlyNames() => clsEducationLevelData.AllOnlyNames();

        public static string GetEducationLeveName(byte? educationLevelID)
            => clsEducationLevelData.GetEducationLevelName(educationLevelID);

        public static byte? GetEducationLeveID(string levelName)
            => clsEducationLevelData.GetEducationLevelID(levelName);
    }
}
