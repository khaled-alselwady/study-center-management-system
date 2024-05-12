using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Students
{
    public partial class frmFindStudent : Form
    {
        public Action<int?> StudentIDBack;

        public frmFindStudent()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            StudentIDBack?.Invoke(ucStudentCardWithFilter1.StudentID);
            Close();
        }

        private void frmFindStudent_Activated(object sender, EventArgs e)
        {
            ucStudentCardWithFilter1.FilterFocus();
        }
    }
}
