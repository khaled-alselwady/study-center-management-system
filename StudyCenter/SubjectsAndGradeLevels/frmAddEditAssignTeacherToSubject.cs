using StudyCenter.GlobalClasses;
using StudyCenter_Business;
using System;
using System.Data;
using System.Windows.Forms;
using static StudyCenter.Teachers.UserControls.ucTeacherCardWithFilter;

namespace StudyCenter.SubjectsAndGradeLevels
{
    public partial class frmAddEditAssignTeacherToSubject : Form
    {
        public Action<int?> SubjectTeacherIDBack;
        private DataTable _dtAllSubjects = new DataTable();
        private enum _enMode { AddNew, Update };
        private _enMode _mode = _enMode.AddNew;

        public enum enEntityType { TeacherID, SubjectTeacherID }

        private int? _subjectTeacherID = null;
        private clsSubjectTeacher _subjectTeacher = null;

        private int? _selectedTeacherID = null;

        public frmAddEditAssignTeacherToSubject()
        {
            InitializeComponent();

            _mode = _enMode.AddNew;
        }

        public frmAddEditAssignTeacherToSubject(int? value, enEntityType entityType)
        {
            InitializeComponent();

            if (entityType == enEntityType.SubjectTeacherID)
                _subjectTeacherID = value;
            else
                _selectedTeacherID = value;

            _mode = _enMode.Update;
        }

        private void _FillComboBoxWithGradeLevels()
        {
            cbGrades.Items.Clear();

            cbGrades.Items.Add("All");

            DataTable gradeLevels = clsGradeLevel.AllOnlyNames();

            foreach (DataRow drTitle in gradeLevels.Rows)
            {
                cbGrades.Items.Add(drTitle["GradeName"].ToString());
            }
        }

        private void _FillComboBoxWithSubjectsName()
        {
            cbSubjects.Items.Clear();

            cbSubjects.Items.Add("All");

            DataTable subjectNames = clsSubject.AllOnlyNames();

            foreach (DataRow drTitle in subjectNames.Rows)
            {
                cbSubjects.Items.Add(drTitle["SubjectName"].ToString());
            }

            if (cbSubjects.Items.Count > 0)
                cbSubjects.SelectedIndex = 0;
        }

        private void _RefreshSubjectGradeLevelsList()
        {
            if (_selectedTeacherID == null)
                _dtAllSubjects.Clear();
            else
                _dtAllSubjects = clsSubjectGradeLevel.AllUntaughtSubjectsByTeacher(_selectedTeacherID);

            dgvList.DataSource = _dtAllSubjects;

            if (dgvList.Rows.Count > 0)
            {
                dgvList.Columns[0].HeaderText = "Subject Grade-Level ID";
                dgvList.Columns[0].Width = 200;

                dgvList.Columns[1].HeaderText = "Subject Name";
                dgvList.Columns[1].Width = 180;

                dgvList.Columns[2].HeaderText = "Grade Name";
                dgvList.Columns[2].Width = 180;

                dgvList.Columns[3].HeaderText = "Description";
                dgvList.Columns[3].Width = 245;
            }
        }

        private int? _GetSubjectGradeLevelIDFromDGV()
        {
            return (int?)dgvList.CurrentRow.Cells["SubjectGradeLevelID"].Value;
        }

        private string _GetSubjectNameFromDGV()
        {
            return (string)dgvList.CurrentRow.Cells["SubjectName"].Value;
        }

        private string _GetGradeNameFromDGV()
        {
            return (string)dgvList.CurrentRow.Cells["GradeName"].Value;
        }

        private void _ResetFields()
        {
            ucTeacherCardWithFilter1.Clear();
        }

        private void _ResetDefaultValues()
        {
            _RefreshSubjectGradeLevelsList();

            if (_mode == _enMode.AddNew)
            {
                lblTitle.Text = "Assign Teacher to Subject";
                _subjectTeacher = new clsSubjectTeacher();
                _DisableTabPageSubject();

                ucTeacherCardWithFilter1.FilterFocus();

                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Teacher Assignment to Subject";
            }

            this.Text = lblTitle.Text;
        }

        private void _DisableTabPageSubject()
        {
            cbGrades.Enabled = false;
            cbSubjects.Enabled = false;
            dgvList.Enabled = false;
            cbFilter.Enabled = false;
            tpSubject.Cursor = Cursors.No;
        }

        private void _EnableTabPageSubject()
        {
            cbGrades.Enabled = true;
            cbSubjects.Enabled = true;
            dgvList.Enabled = true;
            cbFilter.Enabled = true;
            tpSubject.Cursor = Cursors.Default;
        }

        private void _LoadData()
        {
            if (_selectedTeacherID.HasValue)
            {
                ucTeacherCardWithFilter1.LoadTeacherInfoByTeacherID(_selectedTeacherID);
                ucTeacherCardWithFilter1.FilterEnabled = false;
                _subjectTeacher = new clsSubjectTeacher();
                return;
            }

            _subjectTeacher = clsSubjectTeacher.Find(_subjectTeacherID);
            ucTeacherCardWithFilter1.FilterEnabled = false;

            if (_subjectTeacher == null)
            {
                clsStandardMessages.ShowMissingDataMessage("Subject Teacher", _subjectTeacherID);

                this.Close();

                return;
            }

            ucTeacherCardWithFilter1.LoadTeacherInfoByTeacherID(_subjectTeacher.TeacherID);
        }

        private void _FillSubjectTeacherObjectWithFieldsData()
        {
            _subjectTeacher.TeacherID = _selectedTeacherID;
            _subjectTeacher.SubjectGradeLevelID = _GetSubjectGradeLevelIDFromDGV();
            _subjectTeacher.IsActive = true;
        }

        private void _SaveSubjectTeacher()
        {
            _FillSubjectTeacherObjectWithFieldsData();

            if (_subjectTeacher.Save())
            {
                lblTitle.Text = "Update Teacher Assignment to Subject";
                this.Text = lblTitle.Text;

                // change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("Subject Teacher");

                // Trigger the event to send data back to the caller form
                SubjectTeacherIDBack?.Invoke(_subjectTeacher.SubjectTeacherID);
            }
            else
            {
                clsStandardMessages.ShowError("Subject Teacher");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You have to select a subject!", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show($"Are you sure you want to assign the teacher with ID {_selectedTeacherID}" +
                $" to the {_GetSubjectNameFromDGV()} subject for the {_GetGradeNameFromDGV()}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            if (clsSubjectTeacher.IsTeachingSubject(_selectedTeacherID, _GetSubjectGradeLevelIDFromDGV()))
            {
                MessageBox.Show("This teacher is currently teaching the specified subject.",
                    "Teacher Subject Status", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _SaveSubjectTeacher();
        }

        private void frmAddEditAssignTeacherToSubject_Activated(object sender, EventArgs e)
        {
            ucTeacherCardWithFilter1.FilterFocus();
        }

        private void frmAddEditAssignTeacherToSubject_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _FillComboBoxWithGradeLevels();
            _FillComboBoxWithSubjectsName();

            cbFilter.SelectedIndex = 0;

            if (_mode == _enMode.Update)
                _LoadData();
        }

        private void ucTeacherCardWithFilter1_OnTeacherSelected(object sender, TeacherSelectedEventArgs e)
        {
            if (!e.TeacherID.HasValue)
            {
                btnSave.Enabled = false;
                _DisableTabPageSubject();
                _dtAllSubjects.Clear();
                return;
            }

            _selectedTeacherID = e.TeacherID;
            btnSave.Enabled = true;
            _EnableTabPageSubject();
            _RefreshSubjectGradeLevelsList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None")
                _RefreshSubjectGradeLevelsList();

            cbSubjects.Visible = (cbFilter.Text == "Subject");

            cbGrades.Visible = (cbFilter.Text == "Grade Level");

            if (cbSubjects.Visible)
                cbSubjects.SelectedIndex = 0;

            if (cbGrades.Visible)
                cbGrades.SelectedIndex = 0;
        }

        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllSubjects == null || _dtAllSubjects.Rows.Count == 0)
                return;

            if (cbSubjects.Text == "All")
            {
                _dtAllSubjects.DefaultView.RowFilter = "";

                return;
            }

            _dtAllSubjects.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "SubjectName", cbSubjects.Text);
        }

        private void cbGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllSubjects == null || _dtAllSubjects.Rows.Count == 0)
                return;

            if (cbGrades.Text == "All")
            {
                _dtAllSubjects.DefaultView.RowFilter = "";

                return;
            }

            _dtAllSubjects.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "GradeName", cbGrades.Text);
        }
    }
}
