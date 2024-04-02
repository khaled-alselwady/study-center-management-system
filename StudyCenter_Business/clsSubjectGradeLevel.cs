using StudyCenter_DataAccess;
using System.Data;

namespace StudyCenter_Business
{
    public class clsSubjectGradeLevel
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? SubjectGradeLevelID { get; set; }
        public int? SubjectID { get; set; }
        public byte? GradeLevelID { get; set; }
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

        private bool _Add()
        {
            SubjectGradeLevelID = clsSubjectGradeLevelData.Add(SubjectID, GradeLevelID,
                Fees, Description);

            return (SubjectGradeLevelID.HasValue);
        }

        private bool _Update()
        {
            return clsSubjectGradeLevelData.Update(SubjectGradeLevelID, SubjectID,
                GradeLevelID, Fees, Description);
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

        public static DataTable AllUntaughtSubjectsByTeacher(int? teacherID)
            => clsSubjectGradeLevelData.AllUntaughtSubjectsByTeacher(teacherID);

        public static DataTable AllTeachersTeachSubject(int? subjectGradeLevelID)
            => clsSubjectGradeLevelData.AllTeachersTeachSubject(subjectGradeLevelID);
    }

}