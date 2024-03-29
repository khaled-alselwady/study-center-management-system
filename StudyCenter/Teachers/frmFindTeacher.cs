using System;
using System.Windows.Forms;

namespace StudyCenter.Teachers
{
    public partial class frmFindTeacher : Form
    {
        public frmFindTeacher()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFindTeacher_Activated(object sender, EventArgs e)
        {
            ucTeacherCardWithFilter1.FilterFocus();
        }
    }
}
