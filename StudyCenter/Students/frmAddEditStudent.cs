using StudyCenter.GlobalClasses;
using StudyCenter_Business;
using System;
using System.Data;
using System.Windows.Forms;
using static StudyCenter.People.UserControls.ucPersonCardWithFilter;

namespace StudyCenter.Students
{
    public partial class frmAddEditStudent : Form
    {
        public Action<int?> StudentIDBack;

        private enum _enMode { Add, Update }
        private _enMode _mode = _enMode.Add;

        private int? _studentID = null;
        private clsStudent _student = null;

        private int? _selectedPersonID = null;

        public frmAddEditStudent()
        {
            InitializeComponent();
            _mode = _enMode.Add;
        }

        public frmAddEditStudent(int? studentID)
        {
            InitializeComponent();

            _studentID = studentID;
            _mode = _enMode.Update;
        }

        private void _FillComboBoxWithGradeLevels()
        {
            DataTable gradeLevels = clsGradeLevel.AllOnlyNames();

            foreach (DataRow drTitle in gradeLevels.Rows)
            {
                cbGradeLevels.Items.Add(drTitle["GradeName"].ToString());
            }

            if (cbGradeLevels.Items.Count > 0)
                cbGradeLevels.SelectedIndex = 0;
        }

        private void _ResetFields()
        {
            ucPersonCardWithFilter1.Reset();

            lblStudentID.Text = "[????]";
            lblCreatedByUser.Text = clsGlobal.CurrentUser?.Username;
        }

        private void _ResetDefaultValues()
        {
            _FillComboBoxWithGradeLevels();

            if (_mode == _enMode.Add)
            {
                lblTitle.Text = "Add New Student";
                _student = new clsStudent();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Student";
            }

            this.Text = lblTitle.Text;
        }

        private void _FillFieldsWithStudentInfo()
        {
            ucPersonCardWithFilter1.LoadPersonInfo(_student.PersonID);

            lblStudentID.Text = _student.StudentID.ToString();
            lblCreatedByUser.Text = _student.CreatedByUserInfo?.Username;

            cbGradeLevels.SelectedIndex = cbGradeLevels.FindString(clsGradeLevel.GetGradeLevelName(_student.GradeLevelID));
        }

        private void _LoadData()
        {
            _student = clsStudent.FindByStudentID(_studentID);
            ucPersonCardWithFilter1.FilterEnabled = false;

            if (_student == null)
            {
                MessageBox.Show($"There is no a student with ID = {_studentID} !",
                  "Missing Student", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                return;
            }

            _FillFieldsWithStudentInfo();
        }

        private void _FillStudentObjectWithFieldsData()
        {
            _student.PersonID = _selectedPersonID;
            _student.GradeLevelID = clsGradeLevel.GetGradeLevelID(cbGradeLevels.Text);
            _student.CreatedByUserID = clsGlobal.CurrentUser?.UserID;
        }

        private void _SaveStudent()
        {
            _FillStudentObjectWithFieldsData();

            if (_student.Save())
            {
                lblTitle.Text = "Update Student";
                this.Text = lblTitle.Text;
                lblStudentID.Text = _student.StudentID.ToString();

                // change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("Student");

                ucPersonCardWithFilter1.FilterEnabled = false;

                // Trigger the event to send data back to the caller form
                StudentIDBack?.Invoke(_student.StudentID);
            }
            else
            {
                clsStandardMessages.ShowError("student");
            }
        }

        private void frmAddEditStudent_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_mode == _enMode.Update)
                _LoadData();
        }

        private void ucPersonCardWithFilter1_OnPersonSelected(object sender, PersonSelectedEventArgs e)
        {
            if (!e.PersonID.HasValue)
            {
                btnSave.Enabled = false;
                return;
            }

            if (_mode == _enMode.Add && clsStudent.IsStudent(e.PersonID))
            {
                MessageBox.Show("This person is already registered as a student. Please select another person.",
                                "Already Registered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            _selectedPersonID = e.PersonID;
            btnSave.Enabled = true;
        }

        private void frmAddEditStudent_Activated(object sender, EventArgs e)
        {
            ucPersonCardWithFilter1.FilterFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                clsStandardMessages.ShowValidationErrorMessage();
                return;
            }

            _SaveStudent();
        }
    }
}
