using Guna.UI2.WinForms;
using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Groups
{
    public partial class frmAddEditAssignStudentToGroup : Form
    {
        public Action<int?> StudentGroupIDBack;
        private DataTable _dtAllGroups = new DataTable();
        private enum _enMode { AddNew, Update };
        private _enMode _mode = _enMode.AddNew;

        public enum enEntityType { StudentID, GroupID, StudentGroupID }

        private int? _studentGroupID = null;
        private clsStudentGroup _studentGroup = null;

        private int? _selectedStudentID = null;
        private int? _groupID = null;

        public frmAddEditAssignStudentToGroup()
        {
            InitializeComponent();

            _mode = _enMode.AddNew;
        }

        public frmAddEditAssignStudentToGroup(int? value, enEntityType entityType)
        {
            InitializeComponent();

            switch (entityType)
            {
                case enEntityType.StudentGroupID:
                    _studentGroupID = value;
                    break;

                case enEntityType.StudentID:
                    _selectedStudentID = value;
                    _mode = _enMode.AddNew;
                    return;

                case enEntityType.GroupID:
                    _groupID = value;
                    _mode = _enMode.AddNew;
                    return;

                default:
                    _studentGroupID = value;
                    break;

            }

            _mode = _enMode.Update;
        }

        private void _FillComboBoxWithSubjectsName()
        {
            cbSubjectNames.Items.Clear();

            cbSubjectNames.Items.Add("All");

            DataTable subjectNames = clsSubject.AllOnlyNames();

            foreach (DataRow drTitle in subjectNames.Rows)
            {
                cbSubjectNames.Items.Add(drTitle["SubjectName"].ToString());
            }
        }

        private void _FillComboBoxWithGroupNames()
        {
            cbGroupNames.Items.Clear();

            cbGroupNames.Items.Add("All");

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                cbGroupNames.Items.Add(letter);
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Group ID":
                    return "GroupID";

                case "Group Name":
                    return "GroupName";

                case "Class Name":
                    return "ClassName";

                case "Teacher Name":
                    return "TeacherName";

                case "Subject Name":
                    return "SubjectName";

                case "Meeting Days":
                    return "MeetingDays";

                default:
                    return "None";
            }
        }

        private void _RefreshGroupsList()
        {
            if (_groupID.HasValue)
                return;

            if (_selectedStudentID != null)
                _dtAllGroups = clsStudentGroup.AllAvailableGroupsForStudent(_selectedStudentID);

            dgvGroupsList.DataSource = _dtAllGroups;

            if (dgvGroupsList.Rows.Count > 0)
            {
                dgvGroupsList.Columns[0].HeaderText = "Group ID";
                dgvGroupsList.Columns[0].Width = 110;

                dgvGroupsList.Columns[1].HeaderText = "Group Name";
                dgvGroupsList.Columns[1].Width = 150;

                dgvGroupsList.Columns[2].HeaderText = "Class Name";
                dgvGroupsList.Columns[2].Width = 200;

                dgvGroupsList.Columns[3].HeaderText = "Teacher Name";
                dgvGroupsList.Columns[3].Width = 250;

                dgvGroupsList.Columns[4].HeaderText = "Subject Name";
                dgvGroupsList.Columns[4].Width = 200;

                dgvGroupsList.Columns[5].HeaderText = "Grade Name";
                dgvGroupsList.Columns[5].Width = 170;

                dgvGroupsList.Columns[6].HeaderText = "Start Time";
                dgvGroupsList.Columns[6].Width = 120;

                dgvGroupsList.Columns[7].HeaderText = "End Time";
                dgvGroupsList.Columns[7].Width = 120;

                dgvGroupsList.Columns[8].HeaderText = "Meeting Days";
                dgvGroupsList.Columns[8].Width = 120;

                dgvGroupsList.Columns[9].HeaderText = "Students Count";
                dgvGroupsList.Columns[9].Width = 160;

                dgvGroupsList.Columns[10].HeaderText = "Fees";
                dgvGroupsList.Columns[10].Width = 100;

                dgvGroupsList.Columns[11].HeaderText = "Is Active";
                dgvGroupsList.Columns[11].Width = 80;
            }
        }

        private int? _GetGroupIDFromDGV()
        {
            return (int?)dgvGroupsList?.CurrentRow?.Cells["GroupID"]?.Value;
        }

        private decimal? _GetFeesFromDGV()
        {
            return (decimal?)dgvGroupsList?.CurrentRow?.Cells["Fees"]?.Value ?? null;
        }

        private void _FilterComboBox(Guna2ComboBox comboBox, string entityName)
        {
            if (_dtAllGroups == null || _dtAllGroups.Rows.Count == 0 || comboBox == null)
                return;

            if (comboBox.Text == "All")
            {
                _dtAllGroups.DefaultView.RowFilter = "";

                return;
            }

            _dtAllGroups.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", entityName, comboBox.Text);
        }

        private void _ResetFields()
        {
            ucStudentCardWithFilter1.Clear();
        }

        private void _ResetDefaultValues()
        {
            if (_groupID.HasValue)
            {
                ucGroupCard1.LoadGroupInfo(_groupID);
                gbSelectGroup.Visible = false;
                ucGroupCard1.Visible = true;
                ucGroupCard1.Location = new System.Drawing.Point(25, 22);
                ucGroupCard1.Size = new System.Drawing.Size(862, 316);
            }
            else
            {
                _RefreshGroupsList();
            }

            if (_mode == _enMode.AddNew)
            {
                lblTitle.Text = "Assign Student to Group";
                _studentGroup = new clsStudentGroup();

                if (!_groupID.HasValue)
                    _DisableTabPageSubject();

                ucStudentCardWithFilter1.FilterFocus();

                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Student Assignment to Group";
            }

            this.Text = lblTitle.Text;
        }

        private void _DisableTabPageSubject()
        {
            cbGroupNames.Enabled = false;
            cbMeetingDays.Enabled = false;
            cbSubjectNames.Enabled = false;
            txtSearch.Enabled = false;
            dgvGroupsList.Enabled = false;
            cbFilter.Enabled = false;
            tpGroup.Cursor = Cursors.No;
        }

        private void _EnableTabPageSubject()
        {
            cbGroupNames.Enabled = true;
            cbMeetingDays.Enabled = true;
            cbSubjectNames.Enabled = true;
            txtSearch.Enabled = true;
            dgvGroupsList.Enabled = true;
            cbFilter.Enabled = true;
            tpGroup.Cursor = Cursors.Default;
        }

        private void _LoadData()
        {
            if (_selectedStudentID.HasValue)
            {
                ucStudentCardWithFilter1.LoadStudentInfoByStudentID(_selectedStudentID);
                ucStudentCardWithFilter1.FilterEnabled = false;
                _studentGroup = new clsStudentGroup();
                return;
            }

            _studentGroup = clsStudentGroup.Find(_studentGroupID);
            ucStudentCardWithFilter1.FilterEnabled = false;

            if (_studentGroup == null)
            {
                clsStandardMessages.ShowMissingDataMessage("Student Group", _studentGroupID);
                this.Close();
                return;
            }

            ucStudentCardWithFilter1.LoadStudentInfoByStudentID(_studentGroup.StudentID);
        }

        private void _FillStudentGroupObjectWithFieldsData()
        {
            _studentGroup.StudentID = _selectedStudentID;

            if (dgvGroupsList.Rows.Count > 0)
                _studentGroup.GroupID = _GetGroupIDFromDGV();

            else if (_groupID.HasValue)
                _studentGroup.GroupID = _groupID;

            _studentGroup.IsActive = true;
            _studentGroup.CreatedByUserID = clsGlobal.CurrentUser?.UserID;
        }

        private void _SaveStudentGroup()
        {
            _FillStudentGroupObjectWithFieldsData();

            if (_studentGroup.Save())
            {
                lblTitle.Text = "Update Student Assignment to Group";
                this.Text = lblTitle.Text;

                // change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("Student Group");

                // Trigger the event to send data back to the caller form
                StudentGroupIDBack?.Invoke(_studentGroup.StudentGroupID);

                // refresh the group card when the _groupID has a value
                if (_groupID.HasValue)
                    ucGroupCard1.LoadGroupInfo(_groupID);
            }
            else
            {
                clsStandardMessages.ShowError("Student Group");
            }
        }

        private void frmAddEditAssignStudentToGroup_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _FillComboBoxWithSubjectsName();
            _FillComboBoxWithGroupNames();

            cbFilter.SelectedIndex = 0;

            if (_mode == _enMode.Update || _selectedStudentID.HasValue)
                _LoadData();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None")
                _RefreshGroupsList();

            txtSearch.Visible = (cbFilter.Text != "None") &&
                                (cbFilter.Text != "Group Name") &&
                                (cbFilter.Text != "Subject Name") &&
                                (cbFilter.Text != "Meeting Days") &&
                                (cbFilter.Text != "Is Active");

            cbGroupNames.Visible = (cbFilter.Text == "Group Name");
            cbSubjectNames.Visible = (cbFilter.Text == "Subject Name");
            cbMeetingDays.Visible = (cbFilter.Text == "Meeting Days");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbGroupNames.Visible)
                cbGroupNames.SelectedIndex = 0;

            if (cbSubjectNames.Visible)
                cbSubjectNames.SelectedIndex = 0;

            if (cbMeetingDays.Visible)
                cbMeetingDays.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllGroups == null || _dtAllGroups.Rows.Count == 0)
                return;

            string columnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllGroups.DefaultView.RowFilter = "";

                return;
            }

            if (cbFilter.Text == "Group ID")
            {
                // search with numbers
                _dtAllGroups.DefaultView.RowFilter = string.Format("[{0}] = {1}", columnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllGroups.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", columnName, txtSearch.Text.Trim());
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Group ID")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbGroupNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterComboBox(cbGroupNames, "GroupName");
        }

        private void cbSubjectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterComboBox(cbSubjectNames, "SubjectName");
        }

        private void cbMeetingDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterComboBox(cbMeetingDays, "MeetingDays");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_groupID.HasValue && dgvGroupsList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You have to select a subject!", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            decimal? fees = _GetFeesFromDGV();
            decimal displayFees = (fees) ?? (clsGroup.GetSubjectFeesByGroupID(_groupID));

            string message = $"The student with ID {_selectedStudentID} has to pay {displayFees:C2}. Are you sure " +
                             $"you want to assign them to the group with ID {_groupID ?? _GetGroupIDFromDGV()}?";

            if (MessageBox.Show(message, "Confirm",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            _SaveStudentGroup();
        }

        private void frmAddEditAssignStudentToGroup_Activated(object sender, EventArgs e)
        {
            ucStudentCardWithFilter1.FilterFocus();
        }

        private void ucStudentCardWithFilter1_OnStudentSelected(object sender, Students.UserControls.ucStudentCardWithFilter.StudentSelectedEventArgs e)
        {
            if (!e.StudentID.HasValue)
            {
                btnSave.Enabled = false;
                _DisableTabPageSubject();
                _dtAllGroups.Clear();
                return;
            }

            if ((_groupID.HasValue) &&
                (clsStudent.GetGradeLevelIDOfStudent(e.StudentID) !=
                ucGroupCard1?.groupInfo?.SubjectTeacherInfo?.SubjectGradeLevelInfo?.GradeLevelID))
            {
                MessageBox.Show("The grade level of this student is different from the grade level " +
                                "of the group! Choose another one.", "Not Allowed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;
                ucStudentCardWithFilter1.FilterFocus();

                return;
            }

            if (_groupID.HasValue && clsStudentGroup.IsStudentAssignedToGroup(e.StudentID, _groupID))
            {
                MessageBox.Show("This student is currently studying in this group.",
                   "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _selectedStudentID = e.StudentID;
            btnSave.Enabled = true;
            _EnableTabPageSubject();
            _RefreshGroupsList();
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvGroupsList.Rows.Count > 0);
        }

        private void tsmShowGroupDetails_Click(object sender, EventArgs e)
        {
            frmShowGroupInfo showGroupInfo = new frmShowGroupInfo(_GetGroupIDFromDGV());
            showGroupInfo.ShowDialog();

            _RefreshGroupsList();
        }
    }
}
