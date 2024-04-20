using System;
using System.Windows.Forms;

namespace StudyCenterUI.Classes
{
    public partial class frmShowClassInfo : Form
    {
        public frmShowClassInfo(int? classID)
        {
            InitializeComponent();

            ucClassCard1.LoadClassInfo(classID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
