using System;
using System.Windows.Forms;

namespace StudyCenterUI.Classes
{
    public partial class frmShowAllActiveGroupsInClass : Form
    {
        public frmShowAllActiveGroupsInClass(int? classID)
        {
            InitializeComponent();

            ucGetAllActiveGroupsInClass1.LoadAllActiveGroupsInClass(classID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
