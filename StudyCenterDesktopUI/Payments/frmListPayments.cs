using StudyCenterBusiness;
using StudyCenterDesktopUI.Groups;
using StudyCenterDesktopUI.Students;
using StudyCenterDesktopUI.SubjectsAndGradeLevels;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Payments
{
    public partial class frmListPayments : Form
    {
        private DataTable _dtAllPayments = new DataTable();
        private int _allPaymentsCount = 0;
        private readonly short _rowsPerPage = 0;

        public frmListPayments()
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

            _allPaymentsCount = clsPayment.Count();
            short numberOfPages = (short)Math.Ceiling(_allPaymentsCount / (_rowsPerPage == 0 ? 10M : _rowsPerPage));

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
                case "Payment ID":
                    return "PaymentID";

                case "Student ID":
                    return "StudentID";

                case "Group ID":
                    return "GroupID";

                case "Subject Grade-Level ID":
                    return "SubjectGradeLevelID";

                case "Payment Amount":
                    return "PaymentAmount";

                case "Payment Date":
                    return "PaymentDate";

                default:
                    return "None";
            }
        }

        private void _RefreshPaymentsList()
        {
            _dtAllPayments = clsPayment.AllInPages(short.Parse(cbPages.Text), _rowsPerPage);

            dgvPaymentsList.DataSource = _dtAllPayments;

            lblNumberOfRecords.Text = dgvPaymentsList.Rows.Count.ToString();

            if (dgvPaymentsList.Rows.Count > 0)
            {
                dgvPaymentsList.Columns[0].HeaderText = "Payment ID";
                dgvPaymentsList.Columns[0].Width = 140;

                dgvPaymentsList.Columns[1].HeaderText = "Student ID";
                dgvPaymentsList.Columns[1].Width = 140;

                dgvPaymentsList.Columns[2].HeaderText = "Group ID";
                dgvPaymentsList.Columns[2].Width = 135;

                dgvPaymentsList.Columns[3].HeaderText = "Subject Grade-Level ID";
                dgvPaymentsList.Columns[3].Width = 300;

                dgvPaymentsList.Columns[4].HeaderText = "Payment Amount";
                dgvPaymentsList.Columns[4].Width = 300;

                dgvPaymentsList.Columns[5].HeaderText = "Payment Date";
                dgvPaymentsList.Columns[5].Width = 300;
            }
        }

        private int? _GetNumericValueFromDGV(string columnName)
        {
            return (int?)dgvPaymentsList.CurrentRow.Cells[columnName].Value;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllPayments == null || _dtAllPayments.Rows.Count == 0)
                return;

            string columnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllPayments.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvPaymentsList.Rows.Count.ToString();

                return;
            }

            // search with numbers
            _dtAllPayments.DefaultView.RowFilter = string.Format("[{0}] = {1}", columnName, txtSearch.Text.Trim());

            lblNumberOfRecords.Text = dgvPaymentsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // make sure that the user can only enter the numbers
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshPaymentsList();
            cbFilter.SelectedIndex = 0;
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvPaymentsList.Rows.Count > 0);
        }

        private void ShowStudentDetailsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmShowStudentInfo showStudentInfo = new frmShowStudentInfo(_GetNumericValueFromDGV("StudentID"));
            showStudentInfo.ShowDialog();
        }

        private void ShowGroupDetailsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmShowGroupInfo showGroupInfo = new frmShowGroupInfo(_GetNumericValueFromDGV("GroupID"));
            showGroupInfo.ShowDialog();
        }

        private void ShowSubjectGradeLevelDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowSubjectGradeLevelInfo showSubjectGradeLevelInfo = new frmShowSubjectGradeLevelInfo(_GetNumericValueFromDGV("SubjectGradeLevelID"));
            showSubjectGradeLevelInfo.ShowDialog();
        }

        private void frmListPayments_Load(object sender, EventArgs e)
        {
            _FillPagesComboBox();
            _RefreshPaymentsList();

            cbFilter.SelectedIndex = 0;
        }
    }
}
