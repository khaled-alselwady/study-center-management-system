using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.People
{
    public partial class frmFindPerson : Form
    {
        public Action<int?> PersonIDBack;

        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PersonIDBack?.Invoke(ucPersonCardWithFilter1.PersonID);
            Close();
        }

        private void frmFindPerson_Activated(object sender, EventArgs e)
        {
            ucPersonCardWithFilter1.FilterFocus();
        }
    }
}
