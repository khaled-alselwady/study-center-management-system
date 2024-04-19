using StudyCenter.Teachers;
using StudyCenter_Business;
using System.Windows.Forms;

namespace StudyCenter.Classes.UserControls
{
    public partial class ucClassesAreTaughtByTeacher : UserControl
    {
        private int? _teacherID = null;

        public ucClassesAreTaughtByTeacher()
        {
            InitializeComponent();
        }

        private void _ShowTeacherNameAsTitle(int? teacherID)
        {
            clsTeacher teacherInfo = clsTeacher.FindByTeacherID(teacherID);

            if (teacherInfo != null)
            {
                string prefix = teacherInfo.PersonInfo.Gender == clsPerson.enGender.Male ? "Mr." : "Ms.";
                ucSubList1.Title = $"Classes that are taught by {prefix} {teacherInfo.PersonInfo.FullName}";
            }
        }

        public void LoadAllGroupsAreTaughtByTeacher(int? teacherID)
        {
            _teacherID = teacherID;

            object dataSource = clsClass.AllClassesAreTaughtByTeacher(_teacherID);

            var columnsInfo = new[] { ("Class ID", 110),
                                     ("Teacher ID", 120),
                                     ("Teacher Name", 300),
                                     ("Subject Name", 165),
                                     ("Grade Name", 137)
                                    };

            ucSubList1.LoadInfo(_teacherID, dataSource, columnsInfo);

            _ShowTeacherNameAsTitle(_teacherID);
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (ucSubList1.RowsCount > 0);
        }

        private void ShowTeacherDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowTeacherInfo teacherInfo = new frmShowTeacherInfo(ucSubList1.GetIDFromDGV("TeacherID"));
            teacherInfo.ShowDialog();

            LoadAllGroupsAreTaughtByTeacher(_teacherID);
        }

        private void ShowClassDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowClassInfo classInfo = new frmShowClassInfo(ucSubList1.GetIDFromDGV("ClassID"));
            classInfo.ShowDialog();

            LoadAllGroupsAreTaughtByTeacher(_teacherID);
        }
    }
}
