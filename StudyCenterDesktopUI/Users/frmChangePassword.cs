using Guna.UI2.WinForms;
using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Users
{
    public partial class frmChangePassword : Form
    {
        private int? _userID = null;
        private clsUser _user = null;

        public frmChangePassword(int? userID)
        {
            InitializeComponent();

            _userID = userID;
        }

        private void _ResetFields()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();

            txtCurrentPassword.Focus();
        }

        private void _ChangePassword()
        {
            if (_user.ChangePassword(clsGlobal.ComputeHash(txtNewPassword.Text.Trim())))
            {
                MessageBox.Show("Password Changed Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _ResetFields();
            }
            else
            {
                MessageBox.Show("An Error Occurred, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _TextBox_TextChanged(object sender, EventArgs e)
        {
            ((Guna2TextBox)sender).UseSystemPasswordChar = true;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetFields();

            _user = clsUser.FindBy(_userID, clsUser.enFindBy.UserID);

            if (_user == null)
            {
                //Here we don't continue because the form is not valid
                clsStandardMessages.ShowMissingDataMessage("user", _userID);
                this.Close();

                return;

            }

            ucUserCard1.LoadUserInfoByUserID(_userID);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();

            // Check if the current password field is empty
            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "The current password cannot be blank. Please enter your current password.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

            // Validate the current password against the stored hash
            if (_user.Password != clsGlobal.ComputeHash(currentPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "The entered password is incorrect. Please try again.");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "The password field cannot be empty. Please enter a new password.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }

            if (clsGlobal.ComputeHash(newPassword) == _user.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "This password is the same as your current one. Please choose a different password.");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            if (confirmPassword != newPassword)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match. Please confirm your new password again.");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsStandardMessages.ShowValidationErrorMessage();
                return;
            }

            _ChangePassword();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
        }
    }
}
