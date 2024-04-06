using System;
using System.Windows.Forms;

namespace StudyCenter.Groups
{
    public partial class frmShowGroupInfo : Form
    {
        public frmShowGroupInfo(int? groupID)
        {
            InitializeComponent();

            ucGroupCard1.LoadGroupInfo(groupID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
