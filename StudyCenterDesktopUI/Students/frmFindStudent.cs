using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Students
{
    public partial class frmFindStudent : Form
    {
        public Action<int?> StudentIDBack;
        private bool _closingMode = false;

        public frmFindStudent()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _closingMode = true;
            StudentIDBack?.Invoke(ucStudentCardWithFilter1.StudentID);
            Close();
        }

        private void frmFindStudent_Activated(object sender, EventArgs e)
        {
            ucStudentCardWithFilter1.FilterFocus();
        }

        private void frmFindStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_closingMode)
            {
                StudentIDBack?.Invoke(ucStudentCardWithFilter1.StudentID);
            }
        }
    }
}
