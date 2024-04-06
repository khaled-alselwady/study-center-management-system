using StudyCenter.GlobalClasses;
using StudyCenter_Business;
using System;
using System.Data;
using System.Windows.Forms;
using static StudyCenter.Classes.UserControls.ucClassCardWithFilter;
using static StudyCenter.Teachers.UserControls.ucTeacherCardWithFilter;

namespace StudyCenter.Groups
{
    public partial class frmAddEditGroup : Form
    {
        public Action<int?> GroupIDBack;
        private enum _enMode { AddNew, Update };
        private _enMode _mode = _enMode.AddNew;

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

        public frmAddEditGroup(int? groupID)
        {
            InitializeComponent();

            _groupID = groupID;
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
            if (_mode == _enMode.AddNew)
            {
                lblTitle.Text = "Add New Group";
                _group = new clsGroup();

                ucClassCardWithFilter1.FilterFocus();

                lblStudentsCount.Text = "0";
                lblCreatedByUsername.Text = clsGlobal.CurrentUser?.Username ?? "Admin";

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
            ucClassCardWithFilter1.FilterEnabled = false;
            _group = new clsGroup();
        }

        private void _LoadTeacherInfo()
        {
            ucTeacherCardWithFilter1.LoadTeacherInfoByTeacherID(_selectedTeacherID);
            ucTeacherCardWithFilter1.FilterEnabled = false;
            _group = new clsGroup();
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
            ucTeacherCardWithFilter1.FilterEnabled = false;
            ucClassCardWithFilter1.FilterEnabled = false;

            if (_group == null)
            {
                clsStandardMessages.ShowMissingDataMessage("group", _groupID);

                this.Close();

                return;
            }

            ucTeacherCardWithFilter1.LoadTeacherInfoByTeacherID(_group.TeacherID);
            ucClassCardWithFilter1.LoadClassInfo(_group.ClassID);
        }

        private void _FillGroupObjectWithFieldsData()
        {
            _group.TeacherID = _selectedTeacherID;
            _group.ClassID = _selectedClassID;
            _group.SubjectTeacherID = ucGetAllSubjectsTaughtByTeacher1.SubjectTeacherID;
            _group.MeetingTimeID = _GetMeetingTimeIDFromDGV();
            _group.CreatedByUserID = clsGlobal.CurrentUser?.UserID ?? 1;
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

            if (dgvMeetingTimesList.Rows.Count == 0)
            {
                MessageBox.Show("This teacher does not have any available meeting times.",
                    "No Meeting Times", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (dgvMeetingTimesList.SelectedRows.Count <= 0)
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
    }
}
