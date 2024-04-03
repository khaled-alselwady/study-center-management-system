using StudyCenter.Teachers;
using StudyCenter_Business;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace StudyCenter.SubjectsAndGradeLevels
{
    public partial class frmListSubjectsGradeLevel : Form
    {
        private DataTable _dtAllSubjectGradeLevels = new DataTable();
        private int _allSubjectGradeLevelsCount = 0;
        private readonly short _rowsPerPage = 0;

        public frmListSubjectsGradeLevel()
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

            _allSubjectGradeLevelsCount = clsSubjectGradeLevel.Count();
            short numberOfPages = (short)Math.Ceiling(_allSubjectGradeLevelsCount / (_rowsPerPage == 0 ? 10M : _rowsPerPage));

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
            cbSubjects.Items.Clear();

            cbSubjects.Items.Add("All");

            DataTable subjectNames = clsSubject.AllOnlyNames();

            foreach (DataRow drTitle in subjectNames.Rows)
            {
                cbSubjects.Items.Add(drTitle["SubjectName"].ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Subject Grade Level ID":
                    return "SubjectGradeLevelID";

                case "Subject Name":
                    return "SubjectName";

                case "Grade Level":
                    return "GenderName";

                default:
                    return "None";
            }
        }

        private void _RefreshSubjectGradeLevelsList()
        {
            _dtAllSubjectGradeLevels = clsSubjectGradeLevel.AllInPages(short.Parse(cbPages.Text), _rowsPerPage);

            dgvSubjectsGradeLevelsList.DataSource = _dtAllSubjectGradeLevels;

            lblNumberOfRecords.Text = dgvSubjectsGradeLevelsList.Rows.Count.ToString();

            if (dgvSubjectsGradeLevelsList.Rows.Count > 0)
            {
                dgvSubjectsGradeLevelsList.Columns[0].HeaderText = "Subject Grade Level ID";
                dgvSubjectsGradeLevelsList.Columns[0].Width = 110;

                dgvSubjectsGradeLevelsList.Columns[1].HeaderText = "Subject Name";
                dgvSubjectsGradeLevelsList.Columns[1].Width = 200;

                dgvSubjectsGradeLevelsList.Columns[2].HeaderText = "Grade Level Name";
                dgvSubjectsGradeLevelsList.Columns[2].Width = 220;

                dgvSubjectsGradeLevelsList.Columns[3].HeaderText = "Description";
                dgvSubjectsGradeLevelsList.Columns[3].Width = 300;
            }
        }

        private int? _GetSubjectGradeLevelIDFromDGV()
        {
            return (int?)dgvSubjectsGradeLevelsList.CurrentRow.Cells["SubjectGradeLevelID"].Value;
        }

        private void frmListSubjectsGradeLevel_Load(object sender, EventArgs e)
        {
            _FillPagesComboBox();
            _RefreshSubjectGradeLevelsList();
            _FillComboBoxWithGradeLevels();
            _FillComboBoxWithSubjectsName();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None")
                _RefreshSubjectGradeLevelsList();

            txtSearch.Visible = (cbFilter.Text != "None") &&
                                (cbFilter.Text != "Grade Level") &&
                                (cbFilter.Text != "Subject Name");

            cbSubjects.Visible = (cbFilter.Text == "Subject Name");

            cbGrades.Visible = (cbFilter.Text == "Grade Level");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbSubjects.Visible)
                cbSubjects.SelectedIndex = 0;

            if (cbGrades.Visible)
                cbGrades.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllSubjectGradeLevels == null || _dtAllSubjectGradeLevels.Rows.Count == 0)
                return;

            string columnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllSubjectGradeLevels.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvSubjectsGradeLevelsList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Subject Grade Level ID")
            {
                // search with numbers
                _dtAllSubjectGradeLevels.DefaultView.RowFilter = string.Format("[{0}] = {1}", columnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllSubjectGradeLevels.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", columnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvSubjectsGradeLevelsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Subject Grade Level ID")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllSubjectGradeLevels == null || _dtAllSubjectGradeLevels.Rows.Count == 0)
                return;

            if (cbSubjects.Text == "All")
            {
                _dtAllSubjectGradeLevels.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvSubjectsGradeLevelsList.Rows.Count.ToString();

                return;
            }

            _dtAllSubjectGradeLevels.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "SubjectName", cbSubjects.Text);

            lblNumberOfRecords.Text = dgvSubjectsGradeLevelsList.Rows.Count.ToString();
        }

        private void cbGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllSubjectGradeLevels == null || _dtAllSubjectGradeLevels.Rows.Count == 0)
                return;

            if (cbGrades.Text == "All")
            {
                _dtAllSubjectGradeLevels.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvSubjectsGradeLevelsList.Rows.Count.ToString();

                return;
            }

            _dtAllSubjectGradeLevels.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "GradeName", cbGrades.Text);

            lblNumberOfRecords.Text = dgvSubjectsGradeLevelsList.Rows.Count.ToString();
        }

        private void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshSubjectGradeLevelsList();
            cbFilter.SelectedIndex = 0;
        }

        private void tsmShowSubjectDetails_Click(object sender, EventArgs e)
        {
            frmShowSubjectGradeLevelInfo showSubjectGradeLevelInfo = new frmShowSubjectGradeLevelInfo(_GetSubjectGradeLevelIDFromDGV());
            showSubjectGradeLevelInfo.ShowDialog();

            _RefreshSubjectGradeLevelsList();
        }

        private void dgvStudentsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowSubjectGradeLevelInfo showSubjectGradeLevelInfo = new frmShowSubjectGradeLevelInfo(_GetSubjectGradeLevelIDFromDGV());
            showSubjectGradeLevelInfo.ShowDialog();

            _RefreshSubjectGradeLevelsList();
        }

        private void tsmEditSubject_Click(object sender, EventArgs e)
        {
            frmAddEditSubjectsGradeLevels editSubjectsGradeLevels = new frmAddEditSubjectsGradeLevels(_GetSubjectGradeLevelIDFromDGV());
            editSubjectsGradeLevels.ShowDialog();

            _RefreshSubjectGradeLevelsList();
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            frmAddEditSubjectsGradeLevels addSubjectsGradeLevels = new frmAddEditSubjectsGradeLevels();
            addSubjectsGradeLevels.ShowDialog();

            _RefreshSubjectGradeLevelsList();
        }

        private void WhoTeachesItToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGetAllTeachersTeachSubject allTeachersTeachSubject = new frmGetAllTeachersTeachSubject(_GetSubjectGradeLevelIDFromDGV());
            allTeachersTeachSubject.ShowDialog();

            _RefreshSubjectGradeLevelsList();
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvSubjectsGradeLevelsList.Rows.Count > 0);
        }
    }
}
