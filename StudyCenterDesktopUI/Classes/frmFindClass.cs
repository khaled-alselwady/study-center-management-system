using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Classes
{
    public partial class frmFindClass : Form
    {
        public Action<int?> ClassIDBack;
        private bool _closingMode = false;

        public frmFindClass()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _closingMode = true;
            ClassIDBack?.Invoke(ucClassCardWithFilter1.ClassID);
            Close();
        }

        private void frmFindClass_Activated(object sender, EventArgs e)
        {
            ucClassCardWithFilter1.FilterFocus();
        }

        private void frmFindClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_closingMode)
            {
                ClassIDBack?.Invoke(ucClassCardWithFilter1.ClassID);
            }
        }
    }
}
