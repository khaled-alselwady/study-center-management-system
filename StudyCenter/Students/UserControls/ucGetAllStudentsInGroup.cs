using StudyCenter_Business;
using System.Windows.Forms;

namespace StudyCenter.Students.UserControls
{
    public partial class ucGetAllStudentsInGroup : UserControl
    {
        private int? _groupID = null;

        public ucGetAllStudentsInGroup()
        {
            InitializeComponent();
        }

        private void _RefreshAllStudentsInGroupList()
        {
            dgvStudentsList.DataSource =
                clsGroup.AllStudentsInGroup(_groupID);

            lblNumberOfRecords.Text = dgvStudentsList.Rows.Count.ToString() + " / " + clsGroup.GetMaxCapacityOfStudentsInGroup(_groupID); ;

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

        public void LoadAllStudentsInGroup(int? groupID)
        {
            _groupID = groupID;

            _RefreshAllStudentsInGroupList();
        }

        public void LoadAllStudentsInGroup(int? groupID, string groupName)
        {
            _groupID = groupID;

            gbStudentsInGroup.Text = $"Students are in group {groupName}";

            _RefreshAllStudentsInGroupList();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowStudentInfo showStudentInfo = new frmShowStudentInfo(_GetStudentIDFromDGV());
            showStudentInfo.ShowDialog();

            _RefreshAllStudentsInGroupList();
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvStudentsList.Rows.Count > 0);
        }

        private void dgvStudentsList_DoubleClick(object sender, System.EventArgs e)
        {
            frmShowStudentInfo showStudentInfo = new frmShowStudentInfo(_GetStudentIDFromDGV());
            showStudentInfo.ShowDialog();

            _RefreshAllStudentsInGroupList();
        }
    }
}
