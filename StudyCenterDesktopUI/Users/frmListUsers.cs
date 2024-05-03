using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Users
{
    public partial class frmListUsers : Form
    {
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void _RefreshUsersList()
        {
            object dataSource = clsUser.All();

            var columnsInfo = new[] { ("User ID", 110),
                                     ("Full Name", 300),
                                     ("Username", 140),
                                     ("Gender", 120),
                                     ("Is Active", 160)
                                    };

            ucSubList1.LoadInfo(null, dataSource, columnsInfo);
        }

        private int? _GetUserIDFromList()
        {
            return (int?)ucSubList1.GetIDFromDGV("UserID");
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (ucSubList1.RowsCount > 0);
        }

        private void frmListUsers_Load(object sender, System.EventArgs e)
        {
            _RefreshUsersList();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void tsmShowUserDetails_Click(object sender, System.EventArgs e)
        {
            frmShowUserInfo showUserInfo = new frmShowUserInfo(_GetUserIDFromList());
            showUserInfo.ShowDialog();

            _RefreshUsersList();
        }

        private void tsmEditUser_Click(object sender, System.EventArgs e)
        {
            frmAddEditUser editUser = new frmAddEditUser(_GetUserIDFromList());
            editUser.ShowDialog();

            _RefreshUsersList();
        }

        private void tsmDeleteUser_Click(object sender, System.EventArgs e)
        {
            if (clsStandardMessages.ShowDeleteConfirmation("user") == DialogResult.No)
            {
                return;
            }

            if (clsUser.Delete(_GetUserIDFromList()))
            {
                clsStandardMessages.ShowDeletionSuccess("user");
            }
            else
            {
                clsStandardMessages.ShowDeletionFailure("user");
            }
        }
    }
}
