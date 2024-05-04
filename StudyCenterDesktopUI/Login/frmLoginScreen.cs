using Guna.UI2.WinForms;
using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using StudyCenterDesktopUI.MainMenu;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Login
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsStandardMessages.ShowValidationErrorMessage();
                return;
            }

            string hashedPassword = clsGlobal.ComputeHash(txtPassword.Text.Trim());

            if (!clsUser.Exist(txtUsername.Text.Trim(), hashedPassword))
            {
                txtUsername.Focus();
                clsStandardMessages.ShowWrongCredentials();

                return;
            }

            clsUser User = clsUser.FindBy(txtUsername.Text.Trim(), hashedPassword);

            if (User == null)
            {
                txtUsername.Focus();
                clsStandardMessages.ShowWrongCredentials();

                return;
            }

            if (chkRememberMe.Checked)
            {
                //store username and password
                clsGlobal.RememberUsernameAndPassword
                    (txtUsername.Text.Trim(), clsGlobal.Encrypt(txtPassword.Text.Trim()));
            }
            else
            {
                //remove username and password
                clsGlobal.RemoveStoredCredential();
            }

            if (!User.IsActive)
            {
                txtUsername.Focus();

                MessageBox.Show("Your account is not Active, Contact Admin.",
                    "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsGlobal.CurrentUser = User;
            this.Hide();
            frmMainMenu OpenMainMenu = new frmMainMenu(this);
            OpenMainMenu.ShowDialog();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void ValidatingOfTextBoxes(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Guna2TextBox)sender).Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(((Guna2TextBox)sender), "This field is required!");
            }
            else
            {
                errorProvider1.SetError(((Guna2TextBox)sender), null);
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((Guna2TextBox)sender).BorderColor = Color.FromArgb(26, 83, 92);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            ((Guna2TextBox)sender).BorderColor = Color.Silver;
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUsername.Text = UserName;
                txtPassword.Text = clsGlobal.Decrypt(Password);
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }

        private void llOpenMyProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify the URL you want to open
            string url = "https://github.com/dev-khaled-yousef";

            // Open the URL in the default web browser
            System.Diagnostics.Process.Start(url);
        }
    }
}
