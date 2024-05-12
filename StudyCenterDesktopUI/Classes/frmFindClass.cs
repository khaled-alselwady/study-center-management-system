using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Classes
{
    public partial class frmFindClass : Form
    {
        public Action<int?> ClassIDBack;

        public frmFindClass()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClassIDBack?.Invoke(ucClassCardWithFilter1.ClassID);
            Close();
        }

        private void frmFindClass_Activated(object sender, EventArgs e)
        {
            ucClassCardWithFilter1.FilterFocus();
        }
    }
}
