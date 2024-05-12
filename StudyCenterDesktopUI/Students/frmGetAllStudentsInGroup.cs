using StudyCenterDesktopUI.Groups;
using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Students
{
    public partial class frmGetAllStudentsInGroup : Form
    {
        private int? _groupID = null;
        private string _groupName = null;

        public frmGetAllStudentsInGroup(int? groupID, string groupName)
        {
            InitializeComponent();

            _groupID = groupID;
            _groupName = groupName;

            ucGetAllStudentsInGroup1.LoadAllStudentsInGroup(groupID, groupName);

            this.Text = $"Students are in group {groupName}";
            lblTitle.Text = $"Students are in group {groupName}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmAddEditAssignStudentToGroup addStudentToGroup = new frmAddEditAssignStudentToGroup(_groupID, frmAddEditAssignStudentToGroup.enEntityType.GroupID);
            addStudentToGroup.ShowDialog();

            // Refresh
            ucGetAllStudentsInGroup1.LoadAllStudentsInGroup(_groupID, _groupName);
        }
    }
}
