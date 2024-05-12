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

        private void _CheckPermissions(clsUser.enPermissions entityPermissions)
        {
            if (clsGlobal.CurrentUser?.Permissions == -1)
            {
                _EnableDependingOnUserPermissions(entityPermissions);

                return;
            }

            if (((int)entityPermissions & clsGlobal.CurrentUser?.Permissions) == (int)entityPermissions)
            {
                _EnableDependingOnUserPermissions(entityPermissions);
            }
            else
            {
                _DisableDependingOnUserPermissions(entityPermissions);
            }
        }

        private void _EnableDependingOnUserPermissions(clsUser.enPermissions entityPermissions)
        {
            if (clsGlobal.CurrentUser?.Permissions == -1)
            {
                tsmShowUserDetails.Enabled = true;
                tsmEditUser.Enabled = true;
                tsmDeleteUser.Enabled = true;
                return;
            }

            switch (entityPermissions)
            {
                case clsUser.enPermissions.UpdateUser:
                    tsmEditUser.Enabled = true;
                    break;

                case clsUser.enPermissions.DeleteUser:
                    tsmDeleteUser.Enabled = true;
                    break;
            }
        }

        private void _DisableDependingOnUserPermissions(clsUser.enPermissions entityPermissions)
        {
            tsmShowUserDetails.Enabled = false;

            switch (entityPermissions)
            {
                case clsUser.enPermissions.UpdateUser:
                    tsmEditUser.Enabled = false;
                    break;

                case clsUser.enPermissions.DeleteUser:
                    tsmDeleteUser.Enabled = false;
                    break;
            }
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (ucSubList1.RowsCount > 0);

            if (_GetUserIDFromList() == clsGlobal.CurrentUser.UserID)
            {
                tsmDeleteUser.Enabled = false;
            }
        }

        private void frmListUsers_Load(object sender, System.EventArgs e)
        {
            _RefreshUsersList();

            _CheckPermissions(clsUser.enPermissions.UpdateUser);
            _CheckPermissions(clsUser.enPermissions.DeleteUser);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void tsmShowUserDetails_Click(object sender, System.EventArgs e)
        {
            frmShowUserInfo showUserInfo = new frmShowUserInfo(_GetUserIDFromList());
            showUserInfo.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void tsmEditUser_Click(object sender, System.EventArgs e)
        {
            bool allowToEditPermissions = clsGlobal.CurrentUser?.Permissions == -1;

            frmAddEditUser editUser = new frmAddEditUser(_GetUserIDFromList(), allowToEditPermissions);
            editUser.ShowDialog();

            frmListUsers_Load(null, null);
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
