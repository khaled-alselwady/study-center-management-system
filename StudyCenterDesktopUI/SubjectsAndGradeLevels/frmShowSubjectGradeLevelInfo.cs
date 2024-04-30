using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.SubjectsAndGradeLevels
{
    public partial class frmShowSubjectGradeLevelInfo : Form
    {
        public frmShowSubjectGradeLevelInfo(int? subjectGradeLevelID)
        {
            InitializeComponent();

            ucSubjectGradeLevelCard1.LoadSubjectGradeLevelInfo(subjectGradeLevelID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
