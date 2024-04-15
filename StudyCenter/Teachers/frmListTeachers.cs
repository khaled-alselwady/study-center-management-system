using StudyCenter.GlobalClasses;
using StudyCenter.Groups;
using StudyCenter.SubjectsAndGradeLevels;
using StudyCenter_Business;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using static StudyCenter.SubjectsAndGradeLevels.frmAddEditAssignTeacherToSubject;

namespace StudyCenter.Teachers
{
    public partial class frmListTeachers : Form
    {
        private DataTable _dtAllTeachers = new DataTable();
        private int _allTeachersCount = 0;
        private readonly short _rowsPerPage = 0;

        public frmListTeachers()
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

            _allTeachersCount = clsTeacher.Count();
            short numberOfPages = (short)Math.Ceiling(_allTeachersCount / (_rowsPerPage == 0 ? 10M : _rowsPerPage));

            for (short i = 1; i <= numberOfPages; i++)
            {
                cbPages.Items.Add(i.ToString());
            }

            if (cbPages.Items.Count > 0)
                cbPages.SelectedIndex = 0;
        }

        private void _FillComboBoxWithEducationLevels()
        {
            cbEducationLevels.Items.Clear();

            cbEducationLevels.Items.Add("All");

            DataTable educationLevels = clsEducationLevel.AllOnlyNames();

            foreach (DataRow drTitle in educationLevels.Rows)
            {
                cbEducationLevels.Items.Add(drTitle["LevelName"].ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Teacher ID":
                    return "TeacherID";

                case "Name":
                    return "FullName";

                case "Gender":
                    return "Gender";

                case "Education Level":
                    return "EducationLevel";

                case "Age":
                    return "Age";

                default:
                    return "None";
            }
        }

        private void _RefreshTeachersList()
        {
            _dtAllTeachers = clsTeacher.AllInPages(short.Parse(cbPages.Text), _rowsPerPage);

            dgvTeachersList.DataSource = _dtAllTeachers;

            lblNumberOfRecords.Text = dgvTeachersList.Rows.Count.ToString();

            if (dgvTeachersList.Rows.Count > 0)
            {
                dgvTeachersList.Columns[0].HeaderText = "Teacher ID";
                dgvTeachersList.Columns[0].Width = 110;

                dgvTeachersList.Columns[1].HeaderText = "Full Name";
                dgvTeachersList.Columns[1].Width = 300;

                dgvTeachersList.Columns[2].HeaderText = "Gender";
                dgvTeachersList.Columns[2].Width = 120;

                dgvTeachersList.Columns[3].HeaderText = "Date Of Birth";
                dgvTeachersList.Columns[3].Width = 120;

                dgvTeachersList.Columns[4].HeaderText = "Education Level";
                dgvTeachersList.Columns[4].Width = 130;

                dgvTeachersList.Columns[5].HeaderText = "Age";
                dgvTeachersList.Columns[5].Width = 60;
            }
        }

        private int _GetTeacherIDFromDGV()
        {
            return (int)dgvTeachersList.CurrentRow.Cells["TeacherID"].Value;
        }

        private void frmListTeachers_Load(object sender, EventArgs e)
        {
            _FillPagesComboBox();
            _RefreshTeachersList();
            _FillComboBoxWithEducationLevels();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") &&
                                (cbFilter.Text != "Gender") &&
                                (cbFilter.Text != "Education Level");

            cbGender.Visible = (cbFilter.Text == "Gender");

            cbEducationLevels.Visible = (cbFilter.Text == "Education Level");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbGender.Visible)
                cbGender.SelectedIndex = 0;

            if (cbEducationLevels.Visible)
                cbEducationLevels.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllTeachers == null || _dtAllTeachers.Rows.Count == 0)
                return;

            string columnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllTeachers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTeachersList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Teacher ID" || cbFilter.Text == "Age")
            {
                // search with numbers
                _dtAllTeachers.DefaultView.RowFilter = string.Format("[{0}] = {1}", columnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllTeachers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", columnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvTeachersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Teacher ID" || cbFilter.Text == "Age")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbEducationLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllTeachers == null || _dtAllTeachers.Rows.Count == 0)
                return;

            if (cbEducationLevels.Text == "All")
            {
                _dtAllTeachers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTeachersList.Rows.Count.ToString();

                return;
            }

            // Handling single quotes by escaping them with an additional single quote.
            _dtAllTeachers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "EducationLevel", cbEducationLevels.Text.Replace("'", "''"));

            lblNumberOfRecords.Text = dgvTeachersList.Rows.Count.ToString();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllTeachers == null || _dtAllTeachers.Rows.Count == 0)
                return;

            if (cbGender.Text == "All")
            {
                _dtAllTeachers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTeachersList.Rows.Count.ToString();

                return;
            }

            _dtAllTeachers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);

            lblNumberOfRecords.Text = dgvTeachersList.Rows.Count.ToString();
        }

        private void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshTeachersList();
            cbFilter.SelectedIndex = 0;
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvTeachersList.Rows.Count > 0);
        }

        private void tsmShowTeacherDetails_Click(object sender, EventArgs e)
        {
            frmShowTeacherInfo showTeacherInfo = new frmShowTeacherInfo(_GetTeacherIDFromDGV());
            showTeacherInfo.ShowDialog();

            _RefreshTeachersList();
        }

        private void dgvTeachersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowTeacherInfo showTeacherInfo = new frmShowTeacherInfo(_GetTeacherIDFromDGV());
            showTeacherInfo.ShowDialog();

            _RefreshTeachersList();
        }

        private void tsmEditTeacher_Click(object sender, EventArgs e)
        {
            frmAddEditTeacher editTeacher = new frmAddEditTeacher(_GetTeacherIDFromDGV());
            editTeacher.ShowDialog();

            _RefreshTeachersList();
        }

        private void temDeleteTeacher_Click(object sender, EventArgs e)
        {
            if (clsStandardMessages.ShowDeleteConfirmation("teacher") == DialogResult.No)
                return;

            if (clsTeacher.Delete(_GetTeacherIDFromDGV(), clsGlobal.CurrentUser?.UserID))
            {
                clsStandardMessages.ShowDeletionSuccess("teacher");

                _RefreshTeachersList();
            }
            else
                clsStandardMessages.ShowDeletionFailure("teacher", "Please check your permissions and try again.");
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmAddEditTeacher addTeacher = new frmAddEditTeacher();
            addTeacher.ShowDialog();

            _RefreshTeachersList();
        }

        private void tsmAssignToSubject_Click(object sender, EventArgs e)
        {
            frmAddEditAssignTeacherToSubject assignTeacherToSubject = new frmAddEditAssignTeacherToSubject(_GetTeacherIDFromDGV(), enEntityType.TeacherID);
            assignTeacherToSubject.ShowDialog();

            _RefreshTeachersList();
        }

        private void SubjectsHeTeachesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGetAllSubjectsTaughtByTeacher allSubjectsTaughtByTeacher = new frmGetAllSubjectsTaughtByTeacher(_GetTeacherIDFromDGV());
            allSubjectsTaughtByTeacher.ShowDialog();

            _RefreshTeachersList();
        }

        private void GroupsHeTeachesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGroupsAreTaughtByTeacher groupsAreTaughtByTeacher = new frmGroupsAreTaughtByTeacher(_GetTeacherIDFromDGV());
            groupsAreTaughtByTeacher.ShowDialog();

            _RefreshTeachersList();
        }
    }
}
