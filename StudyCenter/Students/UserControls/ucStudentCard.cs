using StudyCenter.GlobalClasses;
using StudyCenter_Business;
using System.Windows.Forms;

namespace StudyCenter.Students.UserControls
{
    public partial class ucStudentCard : UserControl
    {
        private int? _studentID = null;
        private clsStudent _student = null;

        public int? StudentID => _studentID;
        public clsStudent StudentInfo => _student;

        public int? PersonID => ucPersonCard1.PersonID;
        public clsPerson PersonInfo => ucPersonCard1.PersonInfo;

        public ucStudentCard()
        {
            InitializeComponent();
        }

        private void _FillStudentData()
        {
            ucPersonCard1.LoadPersonInfo(_student.PersonID);

            lblStudentID.Text = _student.StudentID.ToString();
            lblGradeLevel.Text = _student.GradeLevelInfo?.GradeName;
            lblCreatedByUser.Text = _student.CreatedByUserInfo.Username;
            lblCreationDate.Text = clsFormat.DateToShort(_student.CreationDate);

            llEditStudentInfo.Enabled = true;
        }

        public void Reset()
        {
            _studentID = null;
            _student = null;

            ucPersonCard1.Reset();

            lblStudentID.Text = "[????]";
            lblGradeLevel.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblCreationDate.Text = "[????]";

            llEditStudentInfo.Enabled = false;
        }

        public void LoadStudentInfoByStudentID(int? studentID)
        {
            _studentID = studentID;

            if (!_studentID.HasValue)
            {
                clsStandardMessages.ShowMissingDataMessage("student", _studentID);

                Reset();

                return;
            }

            _student = clsStudent.FindByStudentID(_studentID);

            if (_student == null)
            {
                clsStandardMessages.ShowMissingDataMessage("student", _studentID);

                Reset();

                return;
            }

            _FillStudentData();
        }

        public void LoadStudentInfoByPersonID(int? personID)
        {
            if (!personID.HasValue)
            {
                MessageBox.Show("There is no a student!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _student = clsStudent.FindByPersonID(personID);

            if (_student == null)
            {
                MessageBox.Show($"There is no a student with Person ID = {personID} !",
                    "Missing student", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillStudentData();
        }

        private void llEditStudentInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditStudent editStudent = new frmAddEditStudent(_studentID);
            editStudent.ShowDialog();

            // Refresh
            LoadStudentInfoByStudentID(_studentID);
        }
    }
}
