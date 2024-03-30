using StudyCenter_DataAccess;
using System.Data;

namespace StudyCenter_Business
{
    public class clsGradeLevel
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public byte? GradeLevelID { get; set; }
        public string GradeName { get; set; }

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

        private bool _Add()
        {
            GradeLevelID = clsGradeLevelData.Add(GradeName);

            return (GradeLevelID.HasValue);
        }

        private bool _Update()
        {
            return clsGradeLevelData.Update(GradeLevelID, GradeName);
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

        public static clsGradeLevel Find(byte? gradeLevelID)
        {
            string gradeName = string.Empty;

            bool isFound = clsGradeLevelData.GetInfoByID(gradeLevelID, ref gradeName);

            return (isFound) ? (new clsGradeLevel(gradeLevelID, gradeName)) : null;
        }

        public static bool Delete(byte? gradeLevelID) => clsGradeLevelData.Delete(gradeLevelID);

        public static bool Exists(byte? gradeLevelID) => clsGradeLevelData.Exists(gradeLevelID);

        public static DataTable All() => clsGradeLevelData.All();

        public static DataTable AllOnlyNames() => clsGradeLevelData.AllOnlyNames();

        public static string GetGradeLevelName(byte? gradeLevelID)
            => clsGradeLevelData.GetGradeLevelName(gradeLevelID);

        public static byte? GetGradeLevelID(string gradeName)
            => clsGradeLevelData.GetGradeLevelID(gradeName);
    }

}