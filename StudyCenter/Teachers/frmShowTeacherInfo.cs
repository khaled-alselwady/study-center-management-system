using System;
using System.Windows.Forms;

namespace StudyCenter.Teachers
{
    public partial class frmShowTeacherInfo : Form
    {
        public frmShowTeacherInfo(int? teacherID)
        {
            InitializeComponent();

            ucTeacherCard1.LoadTeacherInfoByTeacherID(teacherID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
