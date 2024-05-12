using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Teachers
{
    public partial class frmFindTeacher : Form
    {
        public Action<int?> TeacherIDBack;
        private bool _closingMode = false;

        public frmFindTeacher()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _closingMode = true;
            TeacherIDBack?.Invoke(ucTeacherCardWithFilter1.TeacherID);
            Close();
        }

        private void frmFindTeacher_Activated(object sender, EventArgs e)
        {
            ucTeacherCardWithFilter1.FilterFocus();
        }

        private void frmFindTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_closingMode)
            {
                TeacherIDBack?.Invoke(ucTeacherCardWithFilter1.TeacherID);
            }
        }
    }
}
