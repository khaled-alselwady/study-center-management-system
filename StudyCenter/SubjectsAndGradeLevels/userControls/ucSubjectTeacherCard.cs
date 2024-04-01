using StudyCenter.GlobalClasses;
using StudyCenter.Teachers;
using StudyCenter_Business;
using System.Windows.Forms;

namespace StudyCenter.SubjectsAndGradeLevels.userControls
{
    public partial class ucSubjectTeacherCard : UserControl
    {
        private int? _subjectTeacherID = null;
        private clsSubjectTeacher _subjectTeacher = null;

        public int? SubjectTeacherID => _subjectTeacherID;
        public clsSubjectTeacher SubjectTeacher => _subjectTeacher;

        public ucSubjectTeacherCard()
        {
            InitializeComponent();
        }

        private void _FillStudentData()
        {
            lblSubjectTeacherID.Text = _subjectTeacher.SubjectTeacherID.ToString();
            lblSubjectGradeLevelID.Text = _subjectTeacher.SubjectGradeLevelID.ToString();
            lblTeacherID.Text = _subjectTeacher.TeacherID.ToString();
            lblGradeLevel.Text = _subjectTeacher.SubjectGradeLevelInfo.GradeLevelInfo.GradeName;
            lblAssignmentDate.Text = clsFormat.DateToShort(_subjectTeacher.AssignmentDate);

            lblLastModifiedDate.Text = (_subjectTeacher.LastModifiedDate.HasValue)
                                       ? clsFormat.DateToShort(_subjectTeacher.LastModifiedDate)
                                       : "N/A";

            lblIsActive.Text = _subjectTeacher.IsActive ? "Yes" : "No";

            llShowSubjectInfo.Enabled = true;
            llShowTeacherInfo.Enabled = true;
        }

        public void Reset()
        {
            _subjectTeacherID = null;
            _subjectTeacher = null;

            lblSubjectTeacherID.Text = "[????]";
            lblSubjectGradeLevelID.Text = "[????]";
            lblTeacherID.Text = "[????]";
            lblGradeLevel.Text = "[????]";
            lblAssignmentDate.Text = "[????]";
            lblLastModifiedDate.Text = "[????]";
            lblIsActive.Text = "[????]";

            llShowSubjectInfo.Enabled = false;
            llShowTeacherInfo.Enabled = false;
        }

        public void LoadSubjectsTeacherInfo(int? subjectTeacherID)
        {
            _subjectTeacherID = subjectTeacherID;

            if (!_subjectTeacherID.HasValue)
            {
                clsStandardMessages.ShowMissingDataMessage("subject-teacherID", _subjectTeacherID);

                Reset();

                return;
            }

            _subjectTeacher = clsSubjectTeacher.Find(_subjectTeacherID);

            if (_subjectTeacher == null)
            {
                clsStandardMessages.ShowMissingDataMessage("subject-teacherID", _subjectTeacherID);

                Reset();

                return;
            }

            _FillStudentData();
        }

        private void llShowTeacherInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTeacherInfo showTeacherInfo = new frmShowTeacherInfo(_subjectTeacher?.TeacherID);
            showTeacherInfo.ShowDialog();
        }

        private void llShowSubjectInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }
    }
}
