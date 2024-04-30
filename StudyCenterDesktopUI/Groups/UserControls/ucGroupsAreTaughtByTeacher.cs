using StudyCenterDesktopUI.Classes;
using StudyCenterDesktopUI.Teachers;
using StudyCenterBusiness;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Groups.UserControls
{
    public partial class ucGroupsAreTaughtByTeacher : UserControl
    {
        private int? _teacherID = null;

        public ucGroupsAreTaughtByTeacher()
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

            object dataSource = clsGroup.AllGroupsAreTaughtByTeacher(_teacherID);

            var columnsInfo = new[] { ("Teacher ID", 110),
                                     ("Full Name", 300),
                                     ("Class ID", 120),
                                     ("Group ID", 120),
                                     ("Group Name", 160),
                                     ("Subject Name", 150),
                                     ("Grade Name", 120)
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
            frmShowTeacherInfo teacherInfo = new frmShowTeacherInfo((int?)ucSubList1.GetIDFromDGV("TeacherID"));
            teacherInfo.ShowDialog();

            LoadAllGroupsAreTaughtByTeacher(_teacherID);
        }

        private void ShowClassDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowClassInfo classInfo = new frmShowClassInfo((int?)ucSubList1.GetIDFromDGV("ClassID"));
            classInfo.ShowDialog();

            LoadAllGroupsAreTaughtByTeacher(_teacherID);
        }

        private void ShowGroupDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowGroupInfo groupInfo = new frmShowGroupInfo((int?)ucSubList1.GetIDFromDGV("GroupID"));
            groupInfo.ShowDialog();

            LoadAllGroupsAreTaughtByTeacher(_teacherID);
        }
    }
}
