using System;
using System.Windows.Forms;

namespace StudyCenterUI.Teachers
{
    public partial class frmGetAllTeachersTeachInClass : Form
    {
        public frmGetAllTeachersTeachInClass(int? classID)
        {
            InitializeComponent();

            ucGetAllTeachersTeachInClass1.LoadAllTeachersTeachSubject(classID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
