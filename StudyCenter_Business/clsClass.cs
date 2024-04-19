using StudyCenter_DataAccess;
using System.Data;

namespace StudyCenter_Business
{
    public class clsClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ClassID { get; set; }
        public string ClassName { get; set; }
        public byte Capacity { get; set; }
        public string Description { get; set; }

        public clsClass()
        {
            ClassID = null;
            ClassName = string.Empty;
            Capacity = 0;
            Description = null;

            Mode = enMode.AddNew;
        }

        private clsClass(int? classID, string className, byte capacity, string description)
        {
            ClassID = classID;
            ClassName = className;
            Capacity = capacity;
            Description = description;

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            ClassID = clsClassData.Add(ClassName, Capacity, Description);

            return (ClassID.HasValue);
        }

        private bool _Update()
        {
            return clsClassData.Update(ClassID, ClassName, Capacity, Description);
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

        public static clsClass Find(int? classID)
        {
            string className = string.Empty;
            byte capacity = 0;
            string description = null;

            bool isFound = clsClassData.GetInfoByID(classID, ref className, ref capacity, ref description);

            return (isFound) ? (new clsClass(classID, className, capacity, description)) : null;
        }

        public static bool Delete(int? classID)
            => clsClassData.Delete(classID);

        public static bool Exists(int? classID)
            => clsClassData.Exists(classID);

        public static bool Exists(string className)
           => clsClassData.Exists(className);

        public static DataTable All()
            => clsClassData.All();

        public static int Count()
            => clsClassData.Count();

        public static DataTable AllInPages(short PageNumber, int RowsPerPage)
            => clsClassData.AllInPages(PageNumber, RowsPerPage);

        public static DataTable AllTeachersTeachInClass(int? classID)
            => clsClassData.AllTeachersTeachInClass(classID);

        public static DataTable AllClassesAreTaughtByTeacher(int? teacherID)
            => clsClassData.AllClassesAreTaughtByTeacher(teacherID);
    }

}