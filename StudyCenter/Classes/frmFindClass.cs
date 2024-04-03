using System;
using System.Windows.Forms;

namespace StudyCenter.Classes
{
    public partial class frmFindClass : Form
    {
        public frmFindClass()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFindClass_Activated(object sender, EventArgs e)
        {
            ucClassCardWithFilter1.FilterFocus();
        }
    }
}
