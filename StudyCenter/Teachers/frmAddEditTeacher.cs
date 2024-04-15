using StudyCenter.GlobalClasses;
using StudyCenter_Business;
using System;
using System.Data;
using System.Windows.Forms;
using static StudyCenter.People.UserControls.ucPersonCardWithFilter;

namespace StudyCenter.Teachers
{
    public partial class frmAddEditTeacher : Form
    {
        public Action<int?> TeacherIDBack;

        private enum _enMode { Add, Update }
        private _enMode _mode = _enMode.Add;

        private int? _teacherID = null;
        private clsTeacher _teacher = null;

        private int? _selectedPersonID = null;

        public frmAddEditTeacher()
        {
            InitializeComponent();

            _mode = _enMode.Add;
        }

        public frmAddEditTeacher(int? teacherID)
        {
            InitializeComponent();

            _teacherID = teacherID;
            _mode = _enMode.Update;
        }

        private void _FillComboBoxWithEducationLevels()
        {
            DataTable educationLevels = clsEducationLevel.AllOnlyNames();

            foreach (DataRow drTitle in educationLevels.Rows)
            {
                cbEducationLevels.Items.Add(drTitle["LevelName"].ToString());
            }

            if (cbEducationLevels.Items.Count > 0)
                cbEducationLevels.SelectedIndex = 0;
        }

        private void _ResetFields()
        {
            ucPersonCardWithFilter1.Reset();

            lblTeacherID.Text = "[????]";
            lblCreatedByUser.Text = clsGlobal.CurrentUser?.Username;
        }

        private void _ResetDefaultValues()
        {
            _FillComboBoxWithEducationLevels();

            if (_mode == _enMode.Add)
            {
                lblTitle.Text = "Add New Teacher";
                _teacher = new clsTeacher();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Teacher";
            }

            this.Text = lblTitle.Text;
        }

        private void _FillFieldsWithTeacherInfo()
        {
            ucPersonCardWithFilter1.LoadPersonInfo(_teacher.PersonID);

            lblTeacherID.Text = _teacher.TeacherID.ToString();
            lblCreatedByUser.Text = _teacher.CreatedByUserInfo?.Username;
            txtCertifications.Text = _teacher.Certifications;
            numaricTeachingExperience.Value = (decimal)_teacher.TeachingExperience;

            cbEducationLevels.SelectedIndex = cbEducationLevels.
                FindString(clsEducationLevel.GetEducationLeveName(_teacher.EducationLevelID));
        }

        private void _LoadData()
        {
            _teacher = clsTeacher.FindByTeacherID(_teacherID);
            ucPersonCardWithFilter1.FilterEnabled = false;

            if (_teacher == null)
            {
                clsStandardMessages.ShowMissingDataMessage("teacher", _teacherID);

                this.Close();
                return;
            }

            _FillFieldsWithTeacherInfo();
        }

        private void _FillTeacherObjectWithFieldsData()
        {
            _teacher.PersonID = _selectedPersonID;
            _teacher.EducationLevelID = clsEducationLevel.GetEducationLeveID(cbEducationLevels.Text);
            _teacher.TeachingExperience = (byte?)numaricTeachingExperience.Value;
            _teacher.Certifications = txtCertifications.Text.Trim();
            _teacher.CreatedByUserID = clsGlobal.CurrentUser?.UserID ?? 1;
        }

        private void _SaveTeacher()
        {
            _FillTeacherObjectWithFieldsData();

            if (_teacher.Save())
            {
                // Update UI elements
                lblTitle.Text = "Update Teacher";
                this.Text = lblTitle.Text;
                lblTeacherID.Text = _teacher.TeacherID.ToString();

                // Change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("Teacher");

                ucPersonCardWithFilter1.FilterEnabled = false;

                // Trigger the event to send the teacher ID back to the caller form
                TeacherIDBack?.Invoke(_teacher.TeacherID);
            }
            else
            {
                clsStandardMessages.ShowError("teacher");
            }
        }

        private void frmAddEditTeacher_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_mode == _enMode.Update)
                _LoadData();

            txtCertifications.BorderRadius = 17;
        }

        private void ucPersonCardWithFilter1_OnPersonSelected(object sender, PersonSelectedEventArgs e)
        {
            if (!e.PersonID.HasValue)
            {
                btnSave.Enabled = false;
                return;
            }

            if (_mode == _enMode.Add && clsTeacher.IsTeacher(e.PersonID))
            {
                MessageBox.Show("This person is already registered as a teacher. Please select another person.",
                                "Already Registered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (_mode == _enMode.Add &&
                clsStudent.IsStudent(e.PersonID) &&
                clsStudent.IsStudentActive(e.PersonID))
            {
                MessageBox.Show("This person is still an active student and " +
                                "cannot be registered as a teacher until they " +
                                "have graduated and finished learning at the Study Center.",
                                "Active Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            _selectedPersonID = e.PersonID;
            btnSave.Enabled = true;
        }

        private void frmAddEditTeacher_Activated(object sender, EventArgs e)
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

            _SaveTeacher();
        }
    }
}
