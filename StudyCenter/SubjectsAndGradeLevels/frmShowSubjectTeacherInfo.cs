using System;
using System.Windows.Forms;

namespace StudyCenter.SubjectsAndGradeLevels
{
    public partial class frmShowSubjectTeacherInfo : Form
    {
        public frmShowSubjectTeacherInfo(int? subjectTeacherID)
        {
            InitializeComponent();

            ucSubjectTeacherCard1.LoadSubjectsTeacherInfo(subjectTeacherID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
