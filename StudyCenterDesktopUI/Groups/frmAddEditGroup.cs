using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using StudyCenterDesktopUI.MeetingTimes;
using System;
using System.Data;
using System.Windows.Forms;
using static StudyCenterDesktopUI.Classes.UserControls.ucClassCardWithFilter;
using static StudyCenterDesktopUI.Teachers.UserControls.ucTeacherCardWithFilter;

namespace StudyCenterDesktopUI.Groups
{
    public partial class frmAddEditGroup : Form
    {
        public Action<int?> GroupIDBack;
        private enum _enMode { AddNew, Update };
        private _enMode _mode = _enMode.AddNew;

        public enum enEntityType { GroupID, ClassID }

        private int? _groupID = null;
        private clsGroup _group = null;

        private int? _selectedTeacherID = null;
        private int? _selectedClassID = null;

        private DataTable _dtMeetingTimes;

        public frmAddEditGroup()
        {
            InitializeComponent();

            _mode = _enMode.AddNew;
        }

        public frmAddEditGroup(int? value, enEntityType entityType)
        {
            InitializeComponent();

            switch (entityType)
            {
                case enEntityType.GroupID:
                    _groupID = value;
                    break;

                case enEntityType.ClassID:
                    _selectedClassID = value;
                    _mode = _enMode.AddNew;
                    return;

                default:
                    _groupID = value;
                    break;
            }

            _mode = _enMode.Update;
        }

        private void _RefreshMeetingTimesList()
        {
            _dtMeetingTimes = clsMeetingTime.AllWithoutTeacherOrClass(_selectedTeacherID, _selectedClassID);

            dgvMeetingTimesList.DataSource = _dtMeetingTimes;
        }

        private int? _GetMeetingTimeIDFromDGV()
        {
            return (int?)dgvMeetingTimesList.CurrentRow.Cells["MeetingTimeID"].Value;
        }

        private void _ResetFields()
        {
            ucTeacherCardWithFilter1.Clear();
            ucClassCardWithFilter1.Clear();
        }

        private void _ResetDefaultValues()
        {
            if (_selectedClassID.HasValue)
            {
                ucClassCardWithFilter1.LoadClassInfo(_selectedClassID);
                ucClassCardWithFilter1.FilterEnabled = false;
            }

            if (_mode == _enMode.AddNew)
            {
                lblTitle.Text = "Add New Group";
                _group = new clsGroup();

                ucClassCardWithFilter1.FilterFocus();

                lblStudentsCount.Text = "0";
                lblCreatedByUsername.Text = clsGlobal.CurrentUser?.Username;

                if (!_selectedClassID.HasValue)
                    _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Group";
            }

            this.Text = lblTitle.Text;
        }

        private void _LoadClassInfo()
        {
            ucClassCardWithFilter1.LoadClassInfo(_selectedClassID);
            _group = new clsGroup();
        }

        private void _LoadTeacherInfo()
        {
            ucTeacherCardWithFilter1.LoadTeacherInfoByTeacherID(_selectedTeacherID);
            _group = new clsGroup();
        }

        private void _FillFieldsWithGroupInfo()
        {
            if (_group == null)
                return;

            lblGroupID.Text = _group.GroupID.ToString();
            lblTeacherID.Text = _group.TeacherID.ToString();
            lblClassID.Text = _group.ClassID.ToString();
            lblSubjectGradeLevelID.Text = _group.SubjectTeacherInfo?.SubjectGradeLevelID.ToString();
            lblGroupName.Text = _group.GroupName;
            lblMeetingTimeID.Text = _group.MeetingTimeID.ToString();
            lblStudentsCount.Text = _group.GetStudentCount();
            lblCreatedByUsername.Text = _group.CreatedByUserInfo.Username;
        }

        private void _LoadData()
        {
            if (_selectedTeacherID.HasValue)
            {
                _LoadTeacherInfo();
                return;
            }

            if (_selectedClassID.HasValue)
            {
                _LoadClassInfo();
                return;
            }

            _group = clsGroup.Find(_groupID);

            if (_group == null)
            {
                clsStandardMessages.ShowMissingDataMessage("group", _groupID);

                this.Close();

                return;
            }

            ucTeacherCardWithFilter1.LoadTeacherInfoByTeacherID(_group.TeacherID);
            ucClassCardWithFilter1.LoadClassInfo(_group.ClassID);

            _FillFieldsWithGroupInfo();
        }

        private void _FillGroupObjectWithFieldsData()
        {
            _group.TeacherID = _selectedTeacherID;
            _group.ClassID = _selectedClassID;
            _group.SubjectTeacherID = ucGetAllSubjectsTaughtByTeacher1.SubjectTeacherID;

            if (dgvMeetingTimesList.SelectedRows.Count > 0)
                _group.MeetingTimeID = _GetMeetingTimeIDFromDGV();

            _group.CreatedByUserID = clsGlobal.CurrentUser?.UserID;
        }

        private void _SaveGroup()
        {
            _FillGroupObjectWithFieldsData();

            if (_group.Save())
            {
                lblTitle.Text = "Update Group";
                this.Text = lblTitle.Text;

                // change form mode to update
                _mode = _enMode.Update;

                _ShowGroupInfo();

                clsStandardMessages.ShowSuccess("Group");

                // Trigger the event to send data back to the caller form
                GroupIDBack?.Invoke(_group.GroupID);
            }
            else
            {
                clsStandardMessages.ShowError("group");
            }
        }

        private void _ShowGroupInfo()
        {
            if (_group == null)
                return;

            lblGroupID.Text = _group.GroupID.ToString();
            lblGroupName.Text = _group.GroupName;
            lblSubjectGradeLevelID.Text = ucGetAllSubjectsTaughtByTeacher1?.SubjectGradeLevelID.ToString();
            lblMeetingTimeID.Text = _group.MeetingTimeID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditGroup_Activated(object sender, EventArgs e)
        {
            ucClassCardWithFilter1.FilterFocus();
        }

        private void frmAddEditGroup_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            cbFilterMeetingTimeBy.SelectedIndex = 0;

            if (_mode == _enMode.Update)
                _LoadData();
        }

        private void ucClassCardWithFilter1_OnClassSelected(object sender, ClassSelectedEventArgs e)
        {
            _selectedClassID = e.ClassID;

            if (!(e?.ClassID.HasValue) ?? true)
            {
                btnSave.Enabled = false;
                dgvMeetingTimesList.DataSource = null;
                lblClassID.Text = "[????]";
                return;
            }

            if (_mode == _enMode.Update && _group.ClassID != _selectedClassID &&
                clsClass.DoesGroupNameExistInClass(_selectedClassID, _group.GroupName))
            {
                MessageBox.Show($"The group name [{_group.GroupName}] already exists in this class. Please choose a different class.",
                 "Duplicate Group Name", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;
                dgvMeetingTimesList.DataSource = null;
                lblClassID.Text = "[????]";
                return;
            }

            lblClassID.Text = _selectedClassID.ToString();

            if (_selectedTeacherID.HasValue)
            {
                _RefreshMeetingTimesList();
                btnSave.Enabled = true;
            }
        }

        private void ucTeacherCardWithFilter1_OnTeacherSelected(object sender, TeacherSelectedEventArgs e)
        {
            _selectedTeacherID = e.TeacherID;

            if (!(e?.TeacherID.HasValue) ?? true)
            {
                btnSave.Enabled = false;
                ucGetAllSubjectsTaughtByTeacher1.Clear();
                dgvMeetingTimesList.DataSource = null;
                lblTeacherID.Text = "[????]";
                return;
            }

            ucGetAllSubjectsTaughtByTeacher1.LoadActiveSubjectsInfoTaughtByTeacher(_selectedTeacherID);

            lblTeacherID.Text = _selectedTeacherID.ToString();

            if (_selectedClassID.HasValue)
            {
                _RefreshMeetingTimesList();
                btnSave.Enabled = true;
            }
        }

        private void cbMeetingDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtMeetingTimes == null || _dtMeetingTimes.Rows.Count == 0)
                return;

            if (cbMeetingDays.Text == "All")
            {
                _dtMeetingTimes.DefaultView.RowFilter = "";

                return;
            }
            _dtMeetingTimes.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "MeetingDays", cbMeetingDays.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                clsStandardMessages.ShowValidationErrorMessage();
                return;
            }

            if (_group?.TeacherID != _selectedTeacherID && dgvMeetingTimesList.Rows.Count == 0)
            {
                MessageBox.Show("This teacher does not have any available meeting times.",
                    "No Meeting Times", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_group?.TeacherID != _selectedTeacherID && dgvMeetingTimesList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a meeting time.", "Select Meeting Time",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (ucGetAllSubjectsTaughtByTeacher1.NumberOfSubjectsTaughtByTeacher == 0)
            {
                MessageBox.Show("This teacher is not assigned to teach any subjects.",
                    "No Subjects Assigned", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _SaveGroup();
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected tab/page
            TabPage selectedTabPage = guna2TabControl1.SelectedTab;

            if (selectedTabPage == tpTeacherInfo)
                ucTeacherCardWithFilter1.FilterFocus();

            else if (selectedTabPage == tpClassInfo)
                ucClassCardWithFilter1.FilterFocus();
        }

        private void btnAddMeetingTime_Click(object sender, EventArgs e)
        {
            frmAddEditMeetingTime addMeetingTime = new frmAddEditMeetingTime();
            addMeetingTime.ShowDialog();

            if (_selectedTeacherID.HasValue && _selectedClassID.HasValue)
            {
                _RefreshMeetingTimesList();
            }
        }
    }
}
