using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.People
{
    public partial class frmFindPerson : Form
    {
        public Action<int?> PersonIDBack;
        private bool _closingMode = false;

        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _closingMode = true;
            PersonIDBack?.Invoke(ucPersonCardWithFilter1.PersonID);
            Close();
        }

        private void frmFindPerson_Activated(object sender, EventArgs e)
        {
            ucPersonCardWithFilter1.FilterFocus();
        }

        private void frmFindPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_closingMode)
            {
                PersonIDBack?.Invoke(ucPersonCardWithFilter1.PersonID);
            }
        }
    }
}
