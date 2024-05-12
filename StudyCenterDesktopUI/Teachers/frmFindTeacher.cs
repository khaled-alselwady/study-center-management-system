using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Teachers
{
    public partial class frmFindTeacher : Form
    {
        public Action<int?> TeacherIDBack;

        public frmFindTeacher()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            TeacherIDBack?.Invoke(ucTeacherCardWithFilter1.TeacherID);
            Close();
        }

        private void frmFindTeacher_Activated(object sender, EventArgs e)
        {
            ucTeacherCardWithFilter1.FilterFocus();
        }
    }
}
