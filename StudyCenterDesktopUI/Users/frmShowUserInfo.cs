using System.Windows.Forms;

namespace StudyCenterDesktopUI.Users
{
    public partial class frmShowUserInfo : Form
    {
        public frmShowUserInfo(int? userID)
        {
            InitializeComponent();

            ucUserCard1.LoadUserInfoByUserID(userID);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
