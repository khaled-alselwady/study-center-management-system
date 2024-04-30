using StudyCenterDataAccess;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsEducationLevel
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public byte? EducationLevelID { get; set; }
        public string LevelName { get; set; }

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

        private bool _Add()
        {
            EducationLevelID = clsEducationLevelData.Add(LevelName);

            return (EducationLevelID.HasValue);
        }

        private bool _Update()
        {
            return clsEducationLevelData.Update(EducationLevelID, LevelName);
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

        public static clsEducationLevel Find(byte? educationLevelID)
        {
            string levelName = string.Empty;

            bool isFound = clsEducationLevelData.GetInfoByID(educationLevelID, ref levelName);

            return (isFound) ? (new clsEducationLevel(educationLevelID, levelName)) : null;
        }

        public static bool Delete(byte? educationLevelID) => clsEducationLevelData.Delete(educationLevelID);

        public static bool Exists(byte? educationLevelID) => clsEducationLevelData.Exists(educationLevelID);

        public static DataTable All() => clsEducationLevelData.All();

        public static DataTable AllOnlyNames() => clsEducationLevelData.AllOnlyNames();

        public static string GetEducationLeveName(byte? educationLevelID)
            => clsEducationLevelData.GetEducationLevelName(educationLevelID);

        public static byte? GetEducationLeveID(string levelName)
            => clsEducationLevelData.GetEducationLevelID(levelName);
    }
}
