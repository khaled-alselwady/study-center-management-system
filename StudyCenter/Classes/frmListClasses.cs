using StudyCenter_Business;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace StudyCenter.Classes
{
    public partial class frmListClasses : Form
    {
        private DataTable _dtAllClasses = new DataTable();
        private int _allClassesCount = 0;
        private readonly short _rowsPerPage = 0;

        public frmListClasses()
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

            _allClassesCount = clsClass.Count();
            short numberOfPages = (short)Math.Ceiling(_allClassesCount / (_rowsPerPage == 0 ? 10M : _rowsPerPage));

            for (short i = 1; i <= numberOfPages; i++)
            {
                cbPages.Items.Add(i.ToString());
            }

            if (cbPages.Items.Count > 0)
                cbPages.SelectedIndex = 0;
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Class ID":
                    return "ClassID";

                case "Class Name":
                    return "ClassName";

                default:
                    return "None";
            }
        }

        private void _RefreshClassesList()
        {
            _dtAllClasses = clsClass.AllInPages(short.Parse(cbPages.Text), _rowsPerPage);

            dgvClassesList.DataSource = _dtAllClasses;

            lblNumberOfRecords.Text = dgvClassesList.Rows.Count.ToString();

            if (dgvClassesList.Rows.Count > 0)
            {
                dgvClassesList.Columns[0].HeaderText = "Class ID";
                dgvClassesList.Columns[0].Width = 110;

                dgvClassesList.Columns[1].HeaderText = "Class Name";
                dgvClassesList.Columns[1].Width = 200;

                dgvClassesList.Columns[2].HeaderText = "Capacity";
                dgvClassesList.Columns[2].Width = 220;
            }
        }

        private int? _GetClassIDFromDGV()
        {
            return (int?)dgvClassesList.CurrentRow.Cells["ClassID"].Value;
        }

        private void _ShowClassInfo()
        {
            frmShowClassInfo showClassInfo = new frmShowClassInfo(_GetClassIDFromDGV());
            showClassInfo.ShowDialog();

            _RefreshClassesList();
        }

        private void _EditClass()
        {
            frmAddEditClass editClass = new frmAddEditClass(_GetClassIDFromDGV());
            editClass.ShowDialog();

            _RefreshClassesList();
        }

        private void _AddClass()
        {
            frmAddEditClass addClass = new frmAddEditClass();
            addClass.ShowDialog();

            _RefreshClassesList();
        }

        private void frmListClasses_Load(object sender, EventArgs e)
        {
            _FillPagesComboBox();
            _RefreshClassesList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None")
                _RefreshClassesList();

            txtSearch.Visible = (cbFilter.Text != "None");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllClasses == null || _dtAllClasses.Rows.Count == 0)
                return;

            string columnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllClasses.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvClassesList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Class ID")
            {
                // search with numbers
                _dtAllClasses.DefaultView.RowFilter = string.Format("[{0}] = {1}", columnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllClasses.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", columnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvClassesList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Class ID")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshClassesList();
            cbFilter.SelectedIndex = 0;
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvClassesList.Rows.Count > 0);
        }

        private void tsmShowClassDetails_Click(object sender, EventArgs e)
        {
            _ShowClassInfo();
        }

        private void dgvClassesList_DoubleClick(object sender, EventArgs e)
        {
            _ShowClassInfo();
        }

        private void tsmEditClass_Click(object sender, EventArgs e)
        {
            _EditClass();
        }

        private void WhoTeachesInItToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            _AddClass();
        }
    }
}
