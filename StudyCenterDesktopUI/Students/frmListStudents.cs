using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using StudyCenterDesktopUI.Groups;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using static StudyCenterDesktopUI.Groups.frmAddEditAssignStudentToGroup;

namespace StudyCenterDesktopUI.Students
{
    public partial class frmListStudents : Form
    {
        private DataTable _dtAllStudents = new DataTable();
        private int _allStudentsCount = 0;
        private readonly short _rowsPerPage = 0;

        public frmListStudents()
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

            _allStudentsCount = clsStudent.Count();
            short numberOfPages = (short)Math.Ceiling(_allStudentsCount / (_rowsPerPage == 0 ? 10M : _rowsPerPage));

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

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Student ID":
                    return "StudentID";

                case "Name":
                    return "FullName";

                case "Gender":
                    return "Gender";

                case "Grade":
                    return "Grade";

                case "Age":
                    return "Age";

                default:
                    return "None";
            }
        }

        private void _RefreshStudentsList()
        {
            cbFilter.SelectedIndex = 0;

            _dtAllStudents = clsStudent.AllInPages(short.Parse(cbPages.Text), _rowsPerPage);

            dgvStudentsList.DataSource = _dtAllStudents;

            lblNumberOfRecords.Text = dgvStudentsList.Rows.Count.ToString();

            if (dgvStudentsList.Rows.Count > 0)
            {
                dgvStudentsList.Columns[0].HeaderText = "Student ID";
                dgvStudentsList.Columns[0].Width = 110;

                dgvStudentsList.Columns[1].HeaderText = "Full Name";
                dgvStudentsList.Columns[1].Width = 300;

                dgvStudentsList.Columns[2].HeaderText = "Gender";
                dgvStudentsList.Columns[2].Width = 120;

                dgvStudentsList.Columns[3].HeaderText = "Date Of Birth";
                dgvStudentsList.Columns[3].Width = 120;

                dgvStudentsList.Columns[4].HeaderText = "Grade";
                dgvStudentsList.Columns[4].Width = 130;

                dgvStudentsList.Columns[5].HeaderText = "Age";
                dgvStudentsList.Columns[5].Width = 60;
            }
        }

        private int? _GetStudentIDFromDGV()
        {
            return (int?)dgvStudentsList.CurrentRow.Cells["StudentID"].Value;
        }

        private void frmListStudents_Load(object sender, System.EventArgs e)
        {
            _FillPagesComboBox();
            _RefreshStudentsList();
            _FillComboBoxWithGradeLevels();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") &&
                                (cbFilter.Text != "Gender") &&
                                (cbFilter.Text != "Grade");

            cbGender.Visible = (cbFilter.Text == "Gender");

            cbGrades.Visible = (cbFilter.Text == "Grade");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbGender.Visible)
                cbGender.SelectedIndex = 0;

            if (cbGrades.Visible)
                cbGrades.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (_dtAllStudents == null || _dtAllStudents.Rows.Count == 0)
                return;

            string columnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllStudents.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvStudentsList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Student ID" || cbFilter.Text == "Age")
            {
                // search with numbers
                _dtAllStudents.DefaultView.RowFilter = string.Format("[{0}] = {1}", columnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllStudents.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", columnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvStudentsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Student ID" || cbFilter.Text == "Age")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbGrades_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_dtAllStudents == null || _dtAllStudents.Rows.Count == 0)
                return;

            if (cbGrades.Text == "All")
            {
                _dtAllStudents.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvStudentsList.Rows.Count.ToString();

                return;
            }

            _dtAllStudents.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Grade", cbGrades.Text);

            lblNumberOfRecords.Text = dgvStudentsList.Rows.Count.ToString();
        }

        private void cbGender_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_dtAllStudents == null || _dtAllStudents.Rows.Count == 0)
                return;

            if (cbGender.Text == "All")
            {
                _dtAllStudents.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvStudentsList.Rows.Count.ToString();

                return;
            }

            _dtAllStudents.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);

            lblNumberOfRecords.Text = dgvStudentsList.Rows.Count.ToString();
        }

        private void cbPages_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _RefreshStudentsList();
            cbFilter.SelectedIndex = 0;
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvStudentsList.Rows.Count > 0);
        }

        private void tsmShowStudentDetails_Click(object sender, System.EventArgs e)
        {
            frmShowStudentInfo showStudentInfo = new frmShowStudentInfo(_GetStudentIDFromDGV());
            showStudentInfo.ShowDialog();

            _RefreshStudentsList();
        }

        private void tsmEditStudent_Click(object sender, System.EventArgs e)
        {
            frmAddEditStudent editStudent = new frmAddEditStudent(_GetStudentIDFromDGV());
            editStudent.ShowDialog();

            _RefreshStudentsList();
        }

        private void temDeleteStudent_Click(object sender, System.EventArgs e)
        {
            if (clsStandardMessages.ShowDeleteConfirmation("student") == DialogResult.No)
                return;

            if (clsStudent.Delete(_GetStudentIDFromDGV(), clsGlobal.CurrentUser?.UserID))
            {
                clsStandardMessages.ShowDeletionSuccess("student");

                _RefreshStudentsList();
            }
            else
                clsStandardMessages.ShowDeletionFailure("student", "Please check your permissions and try again.");
        }

        private void dgvStudentsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowStudentInfo showStudentInfo = new frmShowStudentInfo(_GetStudentIDFromDGV());
            showStudentInfo.ShowDialog();

            _RefreshStudentsList();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmAddEditStudent addStudent = new frmAddEditStudent();
            addStudent.ShowDialog();

            _RefreshStudentsList();
        }

        private void tsmAssignToGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditAssignStudentToGroup addAssignStudentToGroup
                = new frmAddEditAssignStudentToGroup(_GetStudentIDFromDGV(), enEntityType.StudentID);
            addAssignStudentToGroup.ShowDialog();

            _RefreshStudentsList();
        }
    }
}
