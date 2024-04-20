using System;
using System.Windows.Forms;

namespace StudyCenterUI.Students
{
    public partial class frmFindStudent : Form
    {
        public frmFindStudent()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFindStudent_Activated(object sender, EventArgs e)
        {
            ucStudentCardWithFilter1.FilterFocus();
        }
    }
}
