using Guna.UI2.WinForms;
using StudyCenterDesktopUI.Classes;
using StudyCenterDesktopUI.Dashboard;
using StudyCenterDesktopUI.GlobalClasses;
using StudyCenterDesktopUI.Groups;
using StudyCenterDesktopUI.Login;
using StudyCenterDesktopUI.Payments;
using StudyCenterDesktopUI.Settings;
using StudyCenterDesktopUI.Students;
using StudyCenterDesktopUI.SubjectsAndGradeLevels;
using StudyCenterDesktopUI.Teachers;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.MainMenu
{
    public partial class frmMainMenu : Form
    {
        private Guna2Button _currentButton;
        private Form _activeForm;
        private frmLoginScreen _loginScreen;

        public frmMainMenu(frmLoginScreen loginScreen)
        {
            InitializeComponent();

            _loginScreen = loginScreen;
        }

        private void _ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_currentButton != (Guna2Button)btnSender)
                {
                    _DisableMenuButton();
                    _currentButton = (Guna2Button)btnSender;
                    _currentButton.BackColor = Color.White;
                    _currentButton.ForeColor = Color.FromArgb(53, 41, 123);
                    _currentButton.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void _DisableMenuButton()
        {
            Guna2Button gunaButton = new Guna2Button();

            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Guna2Button))
                {
                    gunaButton = (Guna2Button)previousBtn;

                    previousBtn.BackColor = Color.FromArgb(53, 41, 123);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private async void _OpenChildFormAsync(Form childForm, object btnSender)
        {
            await Task.Delay(100);

            _activeForm?.Close();

            _ActivateButton(btnSender);
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForms.Controls.Add(childForm);
            panelChildForms.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
                lblTitle.Text = childForm.Tag.ToString();

            else
                lblTitle.Text = childForm.Text;
        }

        private void _MoveImageSlide(object sender)
        {
            Guna2Button button1 = (Guna2Button)sender;

            pbImgaeSlide.Location = new Point(button1.Location.X + 184, button1.Location.Y - 20);
            pbImgaeSlide.SendToBack();
        }

        private void btn_CheckedChanged(object sender, EventArgs e)
        {
            _MoveImageSlide(sender);
        }

        private void btnDashboard_Click(object sender, System.EventArgs e)
        {
            _OpenChildFormAsync(new frmDashboard(), sender);
        }

        private void btnStudents_Click(object sender, System.EventArgs e)
        {
            _OpenChildFormAsync(new frmListStudents(), sender);
        }

        private void btnTeachers_Click(object sender, System.EventArgs e)
        {
            _OpenChildFormAsync(new frmListTeachers(), sender);
        }

        private void bntSubjects_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new frmListSubjectsGradeLevel(), sender);
        }

        private void btnClasses_Click(object sender, System.EventArgs e)
        {
            _OpenChildFormAsync(new frmListClasses(), sender);
        }

        private void btnGroups_Click(object sender, System.EventArgs e)
        {
            _OpenChildFormAsync(new frmListGroups(), sender);
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new frmListPayments(), sender);
        }

        private void btnSettings_Click(object sender, System.EventArgs e)
        {
            _OpenChildFormAsync(new frmSettings(), sender);
        }

        private void btnLogOut_Click(object sender, System.EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _loginScreen.Show();
            this.Close();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
        }
    }
}
