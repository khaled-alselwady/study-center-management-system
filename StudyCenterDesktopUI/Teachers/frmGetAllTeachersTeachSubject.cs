using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Teachers
{
    public partial class frmGetAllTeachersTeachSubject : Form
    {
        public frmGetAllTeachersTeachSubject(int? subjectGradeLevelID)
        {
            InitializeComponent();

            ucGetAllTeachersTeachSubject1.LoadAllTeachersTeachSubject(subjectGradeLevelID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
