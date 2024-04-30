using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.People
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int? personID)
        {
            InitializeComponent();

            ucPersonCard1.LoadPersonInfo(personID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
