using StudyCenterDataAccess;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsSubject
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? SubjectID { get; set; }

        private string _oldSubjectName = string.Empty;
        private string _subjectName = string.Empty;
        public string SubjectName
        {
            get => _subjectName;

            set
            {
                // If the old SubjectName is not set (indicating either a new user or the SubjectName is being set for the first time),
                // initialize it with the current SubjectName value to track changes.
                if (string.IsNullOrWhiteSpace(_oldSubjectName))
                {
                    _oldSubjectName = _subjectName;
                }

                _subjectName = value;
            }
        }

        public clsSubject()
        {
            SubjectID = null;
            SubjectName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsSubject(int? subjectID, string subjectName)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;

            Mode = enMode.Update;
        }

        private bool _Validate()
        {
            if (Mode == enMode.Update && !SubjectID.HasValue)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(_subjectName))
            {
                return false;
            }

            // If the old SubjectName is different from the new SubjectName or in AddNew Mode:
            // - In AddNew Mode: This indicates the new SubjectName, requiring validation.
            // - In Update Mode: This indicates that the SubjectName has been changed, so we need to check if it already exists in the database.
            // If the new SubjectName already exists in the database, return false to indicate validation failure.
            if ((Mode == enMode.AddNew) || (_oldSubjectName.Trim().ToLower() != _subjectName.Trim().ToLower()))
            {
                if (Exists(_subjectName))
                {
                    return false;
                }
            }

            return true;
        }

        private bool _Add()
        {
            SubjectID = clsSubjectData.Add(SubjectName);

            return (SubjectID.HasValue);
        }

        private bool _Update()
        {
            return clsSubjectData.Update(SubjectID.Value, SubjectName);
        }

        public bool Save()
        {
            if (!_Validate())
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

        public static clsSubject Find(int? subjectID)
        {
            string subjectName = string.Empty;

            bool isFound = clsSubjectData.GetInfoByID(subjectID, ref subjectName);

            return (isFound) ? (new clsSubject(subjectID, subjectName)) : null;
        }

        public static bool Delete(int? subjectID)
            => clsSubjectData.Delete(subjectID);

        public static bool Exists(int? subjectID)
            => clsSubjectData.Exists(subjectID);

        public static bool Exists(string subjectName)
            => clsSubjectData.Exists(subjectName);

        public static DataTable All()
            => clsSubjectData.All();

        public static DataTable AllOnlyNames()
            => clsSubjectData.AllOnlyNames();

        public static string GetSubjectNameBySubjectID(int? subjectID)
            => clsSubjectData.GetSubjectNameBySubjectID(subjectID);

        public static string GetSubjectNameBySubjectGradeLevelID(int? subjectGradeLevelID)
            => clsSubjectData.GetSubjectNameBySubjectGradeLevelID(subjectGradeLevelID);

        public static byte? GetSubjectID(string subjectName)
            => clsSubjectData.GetSubjectID(subjectName);
    }

}