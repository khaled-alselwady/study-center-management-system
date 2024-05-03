using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using StudyCenterDesktopUI.Users;
using System.Configuration;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Settings
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        private static string _PrintDuration(string value, float duration)
        {
            if (duration >= 2)
            {
                return $"{value}  Hours";
            }
            else
            {
                return $"{value}  Hour";
            }
        }

        private string _FixFormattingWhenPrintingDurations(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "N/A";
            }

            if (float.TryParse(value, out float duration))
            {
                return _PrintDuration(value, duration);
            }

            return $"{value}  Hour(s)";
        }

        private void _ShowSystemInfoFromAppConfig()
        {
            string maxPersonAge = ConfigurationManager.AppSettings["MaxPersonAge"];
            string minPersonAge = ConfigurationManager.AppSettings["MinPersonAge"];

            lblOpeningTime.Text = ConfigurationManager.AppSettings["StudyCenterOpeningTime"] ?? "N/A";
            lblClosingTime.Text = ConfigurationManager.AppSettings["StudyCenterClosingTime"] ?? "N/A";
            lblMaxPersonAge.Text = string.IsNullOrWhiteSpace(maxPersonAge) ? "N/A" : $"{maxPersonAge} Years";
            lblMinPersonAge.Text = string.IsNullOrWhiteSpace(minPersonAge) ? "N/A" : $"{minPersonAge} Years";
            lblDailyLectureDuration.Text = _FixFormattingWhenPrintingDurations(ConfigurationManager.AppSettings["DailyLectureDurationInHour"]);
            lblSTTLectureDuration.Text = _FixFormattingWhenPrintingDurations(ConfigurationManager.AppSettings["STTLectureDurationInHour"]);
            lblMWLectureDuration.Text = _FixFormattingWhenPrintingDurations(ConfigurationManager.AppSettings["MWLectureDurationInHour"]);
        }

        private void frmSettings_Load(object sender, System.EventArgs e)
        {
            _ShowSystemInfoFromAppConfig();

            _CheckPermissions(clsUser.enPermissions.AddUser);
            _CheckPermissions(clsUser.enPermissions.ListUsers);
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
            switch (entityPermissions)
            {
                case clsUser.enPermissions.AddUser:
                    llAddNewUser.Enabled = true;
                    break;

                case clsUser.enPermissions.ListUsers:
                    llListUsers.Enabled = true;
                    break;
            }
        }

        private void _DisableDependingOnUserPermissions(clsUser.enPermissions entityPermissions)
        {
            switch (entityPermissions)
            {
                case clsUser.enPermissions.AddUser:
                    llAddNewUser.Enabled = false;
                    break;

                case clsUser.enPermissions.ListUsers:
                    llListUsers.Enabled = false;
                    break;
            }
        }

        private void llAddNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditUser addUser = new frmAddEditUser();
            addUser.ShowDialog();

            // refresh
            frmSettings_Load(null, null);
        }

        private void llListUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmListUsers listUsers = new frmListUsers();
            listUsers.ShowDialog();

            // refresh
            frmSettings_Load(null, null);
        }
    }
}
