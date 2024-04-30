using StudyCenterBusiness;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.SubjectsAndGradeLevels.userControls
{
    public partial class ucGetAllSubjectsTaughtByTeacher : UserControl
    {
        private int? _teacherID = null;

        public int? SubjectTeacherID => _GetSubjectTeacherIDFromDGV();

        public int? SubjectGradeLevelID => _GetSubjectGradeLevelIDFromDGV();

        public byte NumberOfSubjectsTaughtByTeacher => (byte)ucSubList1.RowsCount;

        public ucGetAllSubjectsTaughtByTeacher()
        {
            InitializeComponent();
        }

        private int? _GetSubjectTeacherIDFromDGV()
        {
            return (int?)ucSubList1.GetIDFromDGV("SubjectTeacherID");
        }

        private int? _GetSubjectGradeLevelIDFromDGV()
        {
            return (int?)ucSubList1.GetIDFromDGV("SubjectGradeLevelID");
        }

        private void _LoadSubjectTeacherInfo(int? teacherID, object dataSource)
        {
            _teacherID = teacherID;

            var columnsInfo = new[] { ("Subject Teacher ID", 180),
                                     ("Teacher ID", 120),
                                     ("Subject Grade-Level ID", 200),
                                     ("Subject Name", 200),
                                     ("Grade Name", 130),
                                     ("Assignment Date", 160),
                                     ("Is Active", 110)
            };

            ucSubList1.LoadInfo(_teacherID, dataSource, columnsInfo);

            clsTeacher teacherInfo = clsTeacher.FindByTeacherID(teacherID);

            if (teacherInfo != null)
            {
                string prefix = teacherInfo.PersonInfo.Gender == clsPerson.enGender.Male ? "Mr." : "Ms.";
                ucSubList1.Title = $"Subjects taught by {prefix} {teacherInfo.PersonInfo.FullName}";
            }
        }

        public void Clear()
        {
            ucSubList1.Clear();
            ucSubList1.Title = $"Subjects that taught by a teacher";
        }

        public void LoadAllSubjectsInfoTaughtByTeacher(int? teacherID)
        {
            _LoadSubjectTeacherInfo(teacherID, clsSubjectTeacher.AllSubjectsTaughtByTeacher(teacherID));
        }

        public void LoadActiveSubjectsInfoTaughtByTeacher(int? teacherID)
        {
            _LoadSubjectTeacherInfo(teacherID, clsSubjectTeacher.AllActiveSubjectsTaughtByTeacher(teacherID));
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowSubjectTeacherInfo showSubjectTeacherInfo = new frmShowSubjectTeacherInfo(_GetSubjectTeacherIDFromDGV());
            showSubjectTeacherInfo.ShowDialog();

            LoadAllSubjectsInfoTaughtByTeacher(_teacherID);
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (ucSubList1.RowsCount > 0);
        }
    }
}
