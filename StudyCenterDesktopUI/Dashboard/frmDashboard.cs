using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Dashboard
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();

            _CountElements();
            _RefreshGroupsList();

            gbList.Text = $"Schedule of Today ({DateTime.Now.DayOfWeek})";
            lblHiUsername.Text = $"Hi {clsGlobal.CurrentUser?.Username ?? "Username"}";
        }

        private void _CountElements()
        {
            lblNumberOfTeachers.Text = clsTeacher.Count().ToString();
            lblNumberOfUsers.Text = clsUser.Count().ToString();
            lblNumberOfClasses.Text = clsClass.Count().ToString();
        }

        private void _RefreshGroupsList()
        {
            dgvGroupsList.DataSource = clsGroup.AllScheduleForToday();

            lblNumberOfRecords.Text = dgvGroupsList.Rows.Count.ToString();

            if (dgvGroupsList.Rows.Count > 0)
            {
                dgvGroupsList.Columns[0].HeaderText = "Teacher Name";
                dgvGroupsList.Columns[0].Width = 250;

                dgvGroupsList.Columns[1].HeaderText = "Subject Name";
                dgvGroupsList.Columns[1].Width = 150;

                dgvGroupsList.Columns[2].HeaderText = "Class Name";
                dgvGroupsList.Columns[2].Width = 150;

                dgvGroupsList.Columns[3].HeaderText = "Group Name";
                dgvGroupsList.Columns[3].Width = 120;

                dgvGroupsList.Columns[4].HeaderText = "Meeting Days";
                dgvGroupsList.Columns[4].Width = 120;

                dgvGroupsList.Columns[5].HeaderText = "Time";
                dgvGroupsList.Columns[5].Width = 120;
            }
        }
    }
}
