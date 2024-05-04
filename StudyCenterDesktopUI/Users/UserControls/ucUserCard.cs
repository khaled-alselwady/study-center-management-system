using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using StudyCenterDesktopUI.Properties;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Users.UserControls
{
    public partial class ucUserCard : UserControl
    {
        private int? _userID = null;
        private clsUser _user = null;

        public int? UserID => _userID;
        public clsUser UserInfo => _user;

        public int? PersonID => ucPersonCard1.PersonID;
        public clsPerson PersonInfo => ucPersonCard1.PersonInfo;

        public ucUserCard()
        {
            InitializeComponent();
        }

        private void _ShowPermissionsText()
        {
            List<string> permissions = _user.PermissionsText();

            if (permissions == null || permissions.Count == 0)
            {
                lblPermissions.Text = "N/A";
                return;
            }

            lblPermissions.Text = string.Join(", ", permissions);
        }

        private void _FillUserData()
        {
            ucPersonCard1.LoadPersonInfo(_user.PersonID);

            lblUserID.Text = _user.UserID.ToString();
            lblUsername.Text = _user.Username;
            lblIsActive.Text = _user.IsActive ? "Yes" : "No";
            pbIsActive.Image = _user.IsActive ? Resources.active_user : Resources.inactive_user;

            _ShowPermissionsText();

            llEditUserInfo.Enabled = true;
        }

        public void Reset()
        {
            _userID = null;
            _user = null;

            ucPersonCard1.Reset();

            lblUserID.Text = "[????]";
            lblUsername.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblPermissions.Text = "[????]";

            llEditUserInfo.Enabled = false;
        }

        public void LoadUserInfoByUserID(int? userID)
        {
            _userID = userID;

            if (!_userID.HasValue)
            {
                clsStandardMessages.ShowMissingDataMessage("user", userID);

                Reset();

                return;
            }

            _user = clsUser.FindBy(userID, clsUser.enFindBy.UserID);

            if (_user == null)
            {
                clsStandardMessages.ShowMissingDataMessage("user", userID);

                Reset();

                return;
            }

            _FillUserData();
        }

        public void LoadUserInfoByPersonID(int? personID)
        {
            if (!personID.HasValue)
            {
                MessageBox.Show("There is no a user!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _user = clsUser.FindBy(personID, clsUser.enFindBy.PersonID);

            if (_user == null)
            {
                MessageBox.Show($"There is no a user with Person ID = {personID} !",
                    "Missing user", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillUserData();
        }

        private void llEditUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool allowToEditPermissions = clsGlobal.CurrentUser?.Permissions == -1;

            frmAddEditUser editUser = new frmAddEditUser(_userID, allowToEditPermissions);
            editUser.ShowDialog();

            // refresh
            LoadUserInfoByUserID(_userID);
        }
    }
}
