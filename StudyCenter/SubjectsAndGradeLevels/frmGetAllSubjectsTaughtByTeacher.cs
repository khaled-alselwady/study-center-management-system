using System;
using System.Windows.Forms;

namespace StudyCenter.SubjectsAndGradeLevels
{
    public partial class frmGetAllSubjectsTaughtByTeacher : Form
    {
        public frmGetAllSubjectsTaughtByTeacher(int? teacherID)
        {
            InitializeComponent();

            ucTeacherCard1.LoadTeacherInfoByTeacherID(teacherID);
            ucGetAllSubjectsTaughtByTeacher1.LoadSubjectsInfoTaughtByTeacher(teacherID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
