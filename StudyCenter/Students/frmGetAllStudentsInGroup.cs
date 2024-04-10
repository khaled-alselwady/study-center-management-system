using System;
using System.Windows.Forms;

namespace StudyCenter.Students
{
    public partial class frmGetAllStudentsInGroup : Form
    {
        public frmGetAllStudentsInGroup(int? groupID, string groupName)
        {
            InitializeComponent();

            ucGetAllStudentsInGroup1.LoadAllStudentsInGroup(groupID, groupName);

            this.Text = $"Students are in group {groupName}";
            lblTitle.Text = $"Students are in group {groupName}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
