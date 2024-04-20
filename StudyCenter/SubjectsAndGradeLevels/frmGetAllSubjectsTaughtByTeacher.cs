using System;
using System.Windows.Forms;

namespace StudyCenterUI.SubjectsAndGradeLevels
{
    public partial class frmGetAllSubjectsTaughtByTeacher : Form
    {
        public frmGetAllSubjectsTaughtByTeacher(int? teacherID)
        {
            InitializeComponent();

            ucTeacherCard1.LoadTeacherInfoByTeacherID(teacherID);
            ucGetAllSubjectsTaughtByTeacher1.LoadAllSubjectsInfoTaughtByTeacher(teacherID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
