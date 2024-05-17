using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ClassID { get; set; }

        private string _className = string.Empty;
        private string _oldClassName = string.Empty;
        public string ClassName
        {
            get => _className;

            set
            {
                // If the old ClassName is not set (indicating either a new user or the ClassName is being set for the first time),
                // initialize it with the current ClassName value to track changes.
                if (string.IsNullOrWhiteSpace(_oldClassName))
                {
                    _oldClassName = _className;
                }

                _className = value;
            }
        }

        public byte Capacity { get; set; }
        public string Description { get; set; }

        public clsClass()
        {
            ClassID = null;
            ClassName = string.Empty;
            Capacity = 1;
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

        private bool _Validate()
        {
            if (Mode == enMode.Update && !ClassID.HasValue)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(_className))
            {
                return false;
            }

            // If the old ClassName is different from the new ClassName or in AddNew Mode:
            // - In AddNew Mode: This indicates the new ClassName, requiring validation.
            // - In Update Mode: This indicates that the ClassName has been changed, so we need to check if it already exists in the database.
            // If the new ClassName already exists in the database, return false to indicate validation failure.
            if ((Mode == enMode.AddNew) || (_oldClassName.Trim().ToLower() != _className.Trim().ToLower()))
            {
                if (Exists(_className))
                {
                    return false;
                }
            }

            if (Capacity <= 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the current instance of <see cref="clsClass"/> using the <see cref="clsValidationHelper"/>.
        /// </summary>
        /// <returns>
        /// Returns true if the current instance passes all validation checks; otherwise, false.
        /// </returns>
        private bool _ValidateUsingHelperClass()
        {
            return clsValidationHelper.Validate
            (
            this,

            // ID Check: Ensure ClassID is valid if in Update mode
            idCheck: c => (c.Mode != enMode.Update) || clsValidationHelper.HasValue(c.ClassID),

            // Value Check: Ensure ClassName is not empty and Capacity is positive
            valueCheck: c => !string.IsNullOrWhiteSpace(c.ClassName) &&
                             c.Capacity > 0,

            // Additional Checks: Ensure ClassName does not already exist in the database
            additionalChecks: new (Func<clsClass, bool>, string)[]
            {
                (c => (c.Mode != enMode.AddNew && _oldClassName.Trim().ToLower() == c.ClassName.Trim().ToLower()) ||
                      !clsValidationHelper.ExistsInDatabase(() => Exists(c.ClassName)),
                      "Class name already exists.")
            }
            );
        }

        private bool _Add()
        {
            ClassID = clsClassData.Add(ClassName, Capacity, Description);

            return (ClassID.HasValue);
        }

        private bool _Update()
        {
            return clsClassData.Update(ClassID.Value, ClassName, Capacity, Description);
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

        public static DataTable AllActiveGroupsInClass(int? classID)
            => clsClassData.AllActiveGroupsInClass(classID);

        public static bool DoesGroupNameExistInClass(int? classID, string groupName)
            => clsClassData.DoesGroupNameExistInClass(classID, groupName);
    }

}