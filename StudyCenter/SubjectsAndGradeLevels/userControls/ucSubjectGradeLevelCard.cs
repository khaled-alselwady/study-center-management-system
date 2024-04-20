using StudyCenterUI.GlobalClasses;
using StudyCenterUI.Teachers;
using StudyCenterBusiness;
using System.Windows.Forms;

namespace StudyCenterUI.SubjectsAndGradeLevels.userControls
{
    public partial class ucSubjectGradeLevelCard : UserControl
    {
        private int? _subjectGradeLevelID = null;
        private clsSubjectGradeLevel _subjectGradeLevel = null;

        public int? SubjectGradeLevelID => _subjectGradeLevelID;
        public clsSubjectGradeLevel SubjectGradeLevel => _subjectGradeLevel;

        public ucSubjectGradeLevelCard()
        {
            InitializeComponent();
        }

        private void _FillStudentData()
        {
            lblSubjectGradeLevelID.Text = _subjectGradeLevel.SubjectGradeLevelID.ToString();
            lblSubjectID.Text = _subjectGradeLevel.SubjectID.ToString();
            lblGradeLevelID.Text = _subjectGradeLevel.GradeLevelID.ToString();
            lblFees.Text = $"{_subjectGradeLevel.Fees:C2}";
            lblSubjectName.Text = _subjectGradeLevel.SubjectInfo.SubjectName;
            lblGradeLevelName.Text = _subjectGradeLevel.GradeLevelInfo.GradeName;
            lblDescription.Text = string.IsNullOrWhiteSpace(_subjectGradeLevel.Description)
                                  ? "N/A"
                                  : _subjectGradeLevel.Description;

            llWhoTeachesIt.Enabled = true;
        }

        public void Reset()
        {
            _subjectGradeLevelID = null;
            _subjectGradeLevel = null;

            lblSubjectGradeLevelID.Text = "[????]";
            lblSubjectID.Text = "[????]";
            lblGradeLevelID.Text = "[????]";
            lblFees.Text = "[????]";
            lblSubjectName.Text = "[????]";
            lblGradeLevelName.Text = "[????]";
            lblDescription.Text = "[????]";

            llWhoTeachesIt.Enabled = false;
        }

        public void LoadSubjectGradeLevelInfo(int? subjectGradeLevelID)
        {
            _subjectGradeLevelID = subjectGradeLevelID;

            if (!_subjectGradeLevelID.HasValue)
            {
                clsStandardMessages.ShowMissingDataMessage("Subject-GradeLevel", _subjectGradeLevelID);

                Reset();

                return;
            }

            _subjectGradeLevel = clsSubjectGradeLevel.Find(_subjectGradeLevelID);

            if (_subjectGradeLevel == null)
            {
                clsStandardMessages.ShowMissingDataMessage("Subject-GradeLevel", _subjectGradeLevelID);

                Reset();

                return;
            }

            _FillStudentData();
        }

        private void llWhoTeachesIt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmGetAllTeachersTeachSubject getAllTeachersTeachSubject = new frmGetAllTeachersTeachSubject(_subjectGradeLevelID);
            getAllTeachersTeachSubject.ShowDialog();

            LoadSubjectGradeLevelInfo(_subjectGradeLevelID);
        }
    }
}
