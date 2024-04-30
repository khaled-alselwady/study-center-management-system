using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Classes
{
    public partial class frmClassesAreTaughtByTeacher : Form
    {
        public frmClassesAreTaughtByTeacher(int? teacherID)
        {
            InitializeComponent();

            ucClassesAreTaughtByTeacher1.LoadAllGroupsAreTaughtByTeacher(teacherID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
