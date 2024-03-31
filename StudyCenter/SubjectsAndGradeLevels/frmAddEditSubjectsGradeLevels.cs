using StudyCenter.GlobalClasses;
using StudyCenter.Subjects;
using StudyCenter_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace StudyCenter.SubjectsAndGradeLevels
{
    public partial class frmAddEditSubjectsGradeLevels : Form
    {
        public Action<int?> SubjectGradeLevelIDBack;

        private enum _enMode { Add, Update };
        private _enMode _mode = _enMode.Add;

        private int? _subjectGradeLevelID = null;
        private clsSubjectGradeLevel _subjectGradeLevel = null;

        public frmAddEditSubjectsGradeLevels()
        {
            InitializeComponent();

            _mode = _enMode.Add;
        }

        public frmAddEditSubjectsGradeLevels(int? subjectsGradeLevelID)
        {
            InitializeComponent();

            _subjectGradeLevelID = subjectsGradeLevelID;
            _mode = _enMode.Update;
        }

        private void _FillComboBoxWithGradeLevels()
        {
            cbGradeLevels.Items.Clear();

            DataTable gradeLevels = clsGradeLevel.AllOnlyNames();

            foreach (DataRow drTitle in gradeLevels.Rows)
            {
                cbGradeLevels.Items.Add(drTitle["GradeName"].ToString());
            }

            if (cbGradeLevels.Items.Count > 0)
                cbGradeLevels.SelectedIndex = 0;
        }

        private void _FillComboBoxWithSubjectsName()
        {
            cbSubjectNames.Items.Clear();

            DataTable subjectNames = clsSubject.AllOnlyNames();

            foreach (DataRow drTitle in subjectNames.Rows)
            {
                cbSubjectNames.Items.Add(drTitle["SubjectName"].ToString());
            }

            if (cbSubjectNames.Items.Count > 0)
                cbSubjectNames.SelectedIndex = 0;
        }

        private void _ResetFields()
        {
            txtFees.Clear();
            txtDescription.Clear();
        }

        private void _ResetDefaultValues()
        {
            _FillComboBoxWithSubjectsName();
            _FillComboBoxWithGradeLevels();
            if (_mode == _enMode.Add)
            {
                lblTitle.Text = "Add New Subject-Grade Level";
                _subjectGradeLevel = new clsSubjectGradeLevel();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Subject-Grade Level";
            }

            this.Text = lblTitle.Text;
        }

        private void _FillFieldsWithSubjectInfo()
        {
            lblSubjectGradeLevelID.Text = _subjectGradeLevel.SubjectGradeLevelID.ToString();
            txtDescription.Text = _subjectGradeLevel.Description ?? "N/A";
            txtFees.Text = $"{_subjectGradeLevel.Fees:C2}";

            cbGradeLevels.SelectedIndex = cbGradeLevels.FindString(_subjectGradeLevel.GradeLevelInfo?.GradeName);
            cbSubjectNames.SelectedIndex = cbSubjectNames.FindString(_subjectGradeLevel.SubjectInfo?.SubjectName);
        }

        private void _LoadData()
        {
            _subjectGradeLevel = clsSubjectGradeLevel.Find(_subjectGradeLevelID);

            if (_subjectGradeLevel == null)
            {
                clsStandardMessages.ShowMissingDataMessage("Subject-GradeLevel", _subjectGradeLevelID);

                this.Close();
                return;
            }

            _FillFieldsWithSubjectInfo();
        }

        private void _FillSubjectObjectWithFieldsData()
        {
            _subjectGradeLevel.SubjectID = clsSubject.GetSubjectID(cbSubjectNames.Text.Trim());
            _subjectGradeLevel.GradeLevelID = clsGradeLevel.GetGradeLevelID(cbGradeLevels.Text.Trim());

            if (txtFees.Text.Trim()[0] == '$')
                _subjectGradeLevel.Fees = Convert.ToDecimal(txtFees.Text.Trim().Substring(1));
            else
                _subjectGradeLevel.Fees = Convert.ToDecimal(txtFees.Text.Trim());

            _subjectGradeLevel.Description = txtDescription.Text.Trim();
        }

        private void _SaveSubjectGradeLevel()
        {
            _FillSubjectObjectWithFieldsData();

            if (_subjectGradeLevel.Save())
            {
                lblTitle.Text = "Update Subject-GradeLevel";
                this.Text = lblTitle.Text;
                lblSubjectGradeLevelID.Text = _subjectGradeLevel.SubjectGradeLevelID.ToString();

                // change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("Subject-GradeLevel");

                // Trigger the event to send data back to the caller form
                SubjectGradeLevelIDBack?.Invoke(_subjectGradeLevel?.SubjectGradeLevelID);
            }
            else
            {
                clsStandardMessages.ShowError("Subject-GradeLevel");
            }
        }

        private void _ShowNewSubjectInTheComboBoxAfterAdding(int? subjectID)
        {
            // update list to include then new subject
            _FillComboBoxWithSubjectsName();

            cbSubjectNames.SelectedIndex = cbSubjectNames.FindString(clsSubject.GetSubjectName(subjectID));
        }

        private void frmAddEditSubjectsGradeLevels_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_mode == _enMode.Update)
                _LoadData();

            txtDescription.BorderRadius = 17;
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

            _SaveSubjectGradeLevel();
        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }

            string fees = txtFees.Text.Trim();

            if (txtFees.Text.Trim()[0] == '$')
                fees = txtFees.Text.Trim().Substring(1);

            if (!clsValidation.IsNumber(fees))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This is not a valid number! choose another one.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
        }

        private void llEditStudentInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditSubject addSubject = new frmAddEditSubject();
            addSubject.SubjectIDBack += _ShowNewSubjectInTheComboBoxAfterAdding;
            addSubject.ShowDialog();
        }
    }
}
