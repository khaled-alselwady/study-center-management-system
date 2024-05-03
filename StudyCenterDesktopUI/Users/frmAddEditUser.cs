using Guna.UI2.WinForms;
using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using StudyCenterDesktopUI.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using static StudyCenterDesktopUI.People.UserControls.ucPersonCardWithFilter;

namespace StudyCenterDesktopUI.Users
{
    public partial class frmAddEditUser : Form
    {
        public Action<int?> UserIDBack;

        private enum _enMode { AddNew, Update };
        private _enMode _mode = _enMode.AddNew;

        private int? _userID = null;
        private clsUser _user = null;

        private int? _selectedPersonID = null;

        public frmAddEditUser()
        {
            InitializeComponent();

            _mode = _enMode.AddNew;
        }

        public frmAddEditUser(int? userID)
        {
            InitializeComponent();

            _userID = userID;
            _mode = _enMode.Update;
        }

        private bool _IsAllItemIsChecked()
        {
            foreach (var item in gbPermissions.Controls)
            {
                if (item is CheckBox chk)
                {
                    if (chk.Tag.ToString() != "-1")
                    {
                        if (!chk.Checked)
                        {
                            return false;
                        }
                    }
                }

            }

            return true;
        }

        private bool _DoesNotSelectAnyPermission()
        {
            // return true if there is no permissions selected, otherwise false

            foreach (var item in gbPermissions.Controls)
            {
                if (item is CheckBox chk)
                {
                    if (chk.Checked)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void _ResetFields()
        {
            ucPersonCardWithFilter1.Reset();

            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            lblUserID.Text = "[????]";
            chkActiveUser.Checked = true;

            pbIsActive.Image = Resources.question_mark;
        }

        private int _CountPermissions()
        {
            int Permissions = 0;

            if (chkAdmin.Checked)
                return -1;

            if (chkAddUser.Checked)
                Permissions += (int)clsUser.enPermissions.AddUser;

            if (chkUpdateUser.Checked)
                Permissions += (int)clsUser.enPermissions.UpdateUser;

            if (chkListUsers.Checked)
                Permissions += (int)clsUser.enPermissions.ListUsers;

            return Permissions;
        }

        private void _ResetDefaultValues()
        {
            if (_mode == _enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                _user = new clsUser();

                tpUserData.Enabled = false;
                ucPersonCardWithFilter1.FilterFocus();

                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update User";
            }

            this.Text = lblTitle.Text;
        }

        private void _LoadData()
        {
            _user = clsUser.FindBy(_userID, clsUser.enFindBy.UserID);
            ucPersonCardWithFilter1.FilterEnabled = false;

            if (_user == null)
            {
                clsStandardMessages.ShowMissingDataMessage("user", _userID);

                this.Close();

                return;
            }

            lblUserID.Text = _user.UserID.ToString();
            txtUsername.Text = _user.Username;
            txtPassword.Text = _user.Password;
            txtConfirmPassword.Text = _user.Password;
            chkActiveUser.Checked = _user.IsActive;
            ucPersonCardWithFilter1.LoadPersonInfo(_user.PersonID);

            // in update mode, I show the change password link label to allow the user to change his password
            panelPassword.Visible = false;
            chkActiveUser.Location = new System.Drawing.Point(210, 165);
            pbIsActive.Location = new System.Drawing.Point(165, 163);
            llChangePassword.Location = new System.Drawing.Point(165, 216);
            llChangePassword.Visible = true;

            _FillCheckBoxPermissions();
        }

        private void _FillCheckBoxPermissions()
        {
            if (_user.Permissions == -1)
            {
                chkAdmin.Checked = true;
                return;
            }

            foreach (var item in gbPermissions.Controls)
            {
                if (item is CheckBox chk)
                {
                    if (chk.Tag.ToString() != "-1")
                    {
                        if (((Convert.ToInt32(chk.Tag)) & _user.Permissions) == (Convert.ToInt32(chk.Tag)))
                        {
                            chk.Checked = true;
                        }
                    }
                }
            }

        }

        private void _FillUserObjectWithFieldsData()
        {
            _user.Username = txtUsername.Text.Trim();
            _user.PersonID = _selectedPersonID;
            _user.IsActive = chkActiveUser.Checked;
            _user.Permissions = _CountPermissions();

            if (_mode == _enMode.AddNew)
            {
                _user.Password = clsGlobal.ComputeHash(txtPassword.Text.Trim());
            }
        }

        private void _SaveUser()
        {
            _FillUserObjectWithFieldsData();

            if (_user.Save())
            {
                lblTitle.Text = "Update User";
                this.Text = lblTitle.Text;
                lblUserID.Text = _user.UserID.ToString();

                // change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("User");

                // Trigger the event to send data back to the caller form
                UserIDBack?.Invoke(_user.UserID);
            }
            else
            {
                clsStandardMessages.ShowError("user");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ucPersonCardWithFilter1_OnPersonSelected(object sender, PersonSelectedEventArgs e)
        {
            if (!e.PersonID.HasValue)
            {
                tpUserData.Enabled = false;
                btnSave.Enabled = false;

                return;
            }

            if (_mode == _enMode.AddNew && ucPersonCardWithFilter1.PersonInfo.IsUser)
            {
                MessageBox.Show("Selected Person already has a user, choose another one.",
                            "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ucPersonCardWithFilter1.FilterFocus();

                tpUserData.Enabled = false;
                btnSave.Enabled = false;

                return;
            }

            _selectedPersonID = e.PersonID;

            tpUserData.Enabled = true;
            btnSave.Enabled = true;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_mode == _enMode.Update)
                _LoadData();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }


            if (txtUsername.Text.Trim().ToLower() != _user.Username.ToLower() &&
                clsUser.Exist(txtUsername.Text.Trim(), clsUser.enFindBy.Username))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "username is used by another user");
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!panelPassword.Visible)
                return;

            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!panelPassword.Visible)
                return;

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

            if ((!string.IsNullOrWhiteSpace(txtConfirmPassword.Text.Trim())
                && !string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
                && (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword,
                    "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void frmAddEditUser_Activated(object sender, EventArgs e)
        {
            ucPersonCardWithFilter1.FilterFocus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsStandardMessages.ShowValidationErrorMessage();
                return;
            }

            if (_DoesNotSelectAnyPermission())
            {
                MessageBox.Show("You have to select permissions for the user!",
                       "Permissions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SaveUser();
        }

        private void txtPasswordAndConfirm_TextChanged(object sender, EventArgs e)
        {
            ((Guna2TextBox)sender).UseSystemPasswordChar = true;
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked)
            {
                foreach (var item in gbPermissions.Controls)
                {
                    if (item is CheckBox chk)
                    {
                        chk.Checked = true;
                    }
                }
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked)
            {
                chkAdmin.Checked = false;
                return;
            }

            chkAdmin.Checked = _IsAllItemIsChecked();
        }

        private void llChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(_userID);
            changePassword.ShowDialog();
        }
    }
}
