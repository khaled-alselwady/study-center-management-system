using StudyCenterDesktopUI.Users;
using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMainMenu());
            Application.Run(new frmListUsers());
        }
    }
}
