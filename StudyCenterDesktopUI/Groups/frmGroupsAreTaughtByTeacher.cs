using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Groups
{
    public partial class frmGroupsAreTaughtByTeacher : Form
    {
        public frmGroupsAreTaughtByTeacher(int? teacherID)
        {
            InitializeComponent();

            ucGroupsAreTaughtByTeacher1.LoadAllGroupsAreTaughtByTeacher(teacherID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
