using Guna.UI2.WinForms;
using StudyCenter.Students;
using StudyCenter_Business;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using static StudyCenter.Groups.frmAddEditAssignStudentToGroup;

namespace StudyCenter.Groups
{
    public partial class frmListGroups : Form
    {
        private DataTable _dtAllGroups = new DataTable();
        private int _allGroupsCount = 0;
        private readonly short _rowsPerPage = 0;

        public frmListGroups()
        {
            InitializeComponent();

            if (short.TryParse(ConfigurationManager.AppSettings["RowsPerPage"], out short value))
                _rowsPerPage = value;
            else
                _rowsPerPage = 10;
        }

        private void _FillPagesComboBox()
        {
            cbPages.Items.Clear();

            _allGroupsCount = clsStudent.Count();
            short numberOfPages = (short)Math.Ceiling(_allGroupsCount / (_rowsPerPage == 0 ? 10M : _rowsPerPage));

            for (short i = 1; i <= numberOfPages; i++)
            {
                cbPages.Items.Add(i.ToString());
            }

            if (cbPages.Items.Count > 0)
                cbPages.SelectedIndex = 0;
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

                case "Grade Name":
                    return "GradeName";

                case "Meeting Days":
                    return "MeetingDays";

                case "Is Active":
                    return "IsActive";

                default:
                    return "None";
            }
        }

        private void _RefreshGroupsList()
        {
            _dtAllGroups = clsGroup.AllInPages(short.Parse(cbPages.Text), _rowsPerPage);

            dgvGroupsList.DataSource = _dtAllGroups;

            lblNumberOfRecords.Text = dgvGroupsList.Rows.Count.ToString();

            if (dgvGroupsList.Rows.Count > 0)
            {
                dgvGroupsList.Columns[0].HeaderText = "Group ID";
                dgvGroupsList.Columns[0].Width = 110;

                dgvGroupsList.Columns[1].HeaderText = "Group Name";
                dgvGroupsList.Columns[1].Width = 300;

                dgvGroupsList.Columns[2].HeaderText = "Class Name";
                dgvGroupsList.Columns[2].Width = 300;

                dgvGroupsList.Columns[3].HeaderText = "Teacher Name";
                dgvGroupsList.Columns[3].Width = 300;

                dgvGroupsList.Columns[4].HeaderText = "Subject Name";
                dgvGroupsList.Columns[4].Width = 300;

                dgvGroupsList.Columns[5].HeaderText = "Grade Name";
                dgvGroupsList.Columns[5].Width = 300;

                dgvGroupsList.Columns[6].HeaderText = "Start Time";
                dgvGroupsList.Columns[6].Width = 120;

                dgvGroupsList.Columns[7].HeaderText = "End Time";
                dgvGroupsList.Columns[7].Width = 120;

                dgvGroupsList.Columns[8].HeaderText = "Meeting Days";
                dgvGroupsList.Columns[8].Width = 120;

                dgvGroupsList.Columns[9].HeaderText = "Students Count";
                dgvGroupsList.Columns[9].Width = 130;

                dgvGroupsList.Columns[10].HeaderText = "Is Active";
                dgvGroupsList.Columns[10].Width = 60;
            }
        }

        private int? _GetGroupIDFromDGV()
        {
            return (int?)dgvGroupsList.CurrentRow.Cells["GroupID"].Value;
        }

        private string _GetGroupNameFromDGV()
        {
            return (string)dgvGroupsList.CurrentRow.Cells["GroupName"].Value;
        }

        private byte _GetStudentCountFromDGV()
        {
            return (byte)dgvGroupsList.CurrentRow.Cells["StudentCount"].Value;
        }

        private void _FilterComboBox(Guna2ComboBox comboBox, string entityName)
        {
            if (_dtAllGroups == null || _dtAllGroups.Rows.Count == 0 || comboBox == null)
                return;

            if (comboBox.Text == "All")
            {
                _dtAllGroups.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvGroupsList.Rows.Count.ToString();

                return;
            }

            _dtAllGroups.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", entityName, comboBox.Text);

            lblNumberOfRecords.Text = dgvGroupsList.Rows.Count.ToString();
        }

        private void frmListGroups_Load(object sender, EventArgs e)
        {
            _FillPagesComboBox();
            _RefreshGroupsList();
            _FillComboBoxWithGradeLevels();
            _FillComboBoxWithSubjectsName();
            _FillComboBoxWithGroupNames();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") &&
                                (cbFilter.Text != "Group Name") &&
                                (cbFilter.Text != "Subject Name") &&
                                (cbFilter.Text != "Grade Name") &&
                                (cbFilter.Text != "Meeting Days") &&
                                (cbFilter.Text != "Is Active");

            cbGroupNames.Visible = (cbFilter.Text == "Group Name");
            cbSubjectNames.Visible = (cbFilter.Text == "Subject Name");
            cbGrades.Visible = (cbFilter.Text == "Grade Name");
            cbMeetingDays.Visible = (cbFilter.Text == "Meeting Days");
            cbIsActive.Visible = (cbFilter.Text == "Is Active");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbIsActive.Visible)
                cbIsActive.SelectedIndex = 0;

            if (cbGrades.Visible)
                cbGrades.SelectedIndex = 0;

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
                lblNumberOfRecords.Text = dgvGroupsList.Rows.Count.ToString();

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

            lblNumberOfRecords.Text = dgvGroupsList.Rows.Count.ToString();
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

        private void cbMeetingDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterComboBox(cbMeetingDays, "MeetingDays");
        }

        private void cbSubjectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterComboBox(cbSubjectNames, "SubjectName");
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllGroups == null || _dtAllGroups.Rows.Count == 0)
                return;

            if (cbIsActive.Text == "All")
            {
                _dtAllGroups.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvGroupsList.Rows.Count.ToString();

                return;
            }
            _dtAllGroups.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "IsActive", cbIsActive.Text == "Yes");

            lblNumberOfRecords.Text = dgvGroupsList.Rows.Count.ToString();
        }

        private void cbGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterComboBox(cbGrades, "GradeName");
        }

        private void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshGroupsList();
            cbFilter.SelectedIndex = 0;
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvGroupsList.Rows.Count > 0);

            AddStudentToolStripMenuItem.Enabled =
                _GetStudentCountFromDGV() < clsGroup.GetMaxCapacityOfStudentsInGroup(_GetGroupIDFromDGV());
        }

        private void tsmShowGroupDetails_Click(object sender, EventArgs e)
        {
            frmShowGroupInfo showGroupInfo = new frmShowGroupInfo(_GetGroupIDFromDGV());
            showGroupInfo.ShowDialog();


            _RefreshGroupsList();
        }

        private void tsmEditGroup_Click(object sender, EventArgs e)
        {
            frmAddEditGroup editGroup = new frmAddEditGroup(_GetGroupIDFromDGV());
            editGroup.ShowDialog();

            _RefreshGroupsList();
        }

        private void temDeleteGroup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }

        private void dgvGroupsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowGroupInfo showGroupInfo = new frmShowGroupInfo(_GetGroupIDFromDGV());
            showGroupInfo.ShowDialog();


            _RefreshGroupsList();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            frmAddEditGroup addGroup = new frmAddEditGroup();
            addGroup.ShowDialog();

            _RefreshGroupsList();
        }

        private void ShowAllStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGetAllStudentsInGroup getAllStudentsInGroup = new frmGetAllStudentsInGroup(_GetGroupIDFromDGV(), _GetGroupNameFromDGV());
            getAllStudentsInGroup.ShowDialog();

            _RefreshGroupsList();
        }

        private void AddStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditAssignStudentToGroup addStudentToGroup = new frmAddEditAssignStudentToGroup(_GetGroupIDFromDGV(), enEntityType.GroupID);
            addStudentToGroup.ShowDialog();

            _RefreshGroupsList();
        }
    }
}
