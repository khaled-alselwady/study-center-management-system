using StudyCenter.Classes;
using StudyCenter.Groups;
using StudyCenter_Business;
using System.Windows.Forms;

namespace StudyCenter.Teachers.UserControls
{
    public partial class ucGetAllTeachersTeachInClass : UserControl
    {
        private int? _classID = null;

        public ucGetAllTeachersTeachInClass()
        {
            InitializeComponent();
        }

        public void LoadAllTeachersTeachSubject(int? classID)
        {
            _classID = classID;

            object dataSource = clsClass.AllTeachersTeachInClass(_classID);

            var columnsInfo = new[] { ("Teacher ID", 110),
                                     ("Full Name", 300),
                                     ("Class ID", 120),
                                     ("Group ID", 120),
                                     ("Group Name", 160),
                                     ("Subject Name", 150),
                                     ("Grade Name", 120)
                                    };

            ucSubList1.LoadInfo(_classID, dataSource, columnsInfo);

            ucSubList1.Title = "Teachers are teaching in the class";
        }

        private void ShowTeacherDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowTeacherInfo teacherInfo = new frmShowTeacherInfo(ucSubList1.GetIDFromDGV("TeacherID"));
            teacherInfo.ShowDialog();

            LoadAllTeachersTeachSubject(_classID);
        }

        private void ShowClassDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowClassInfo classInfo = new frmShowClassInfo(ucSubList1.GetIDFromDGV("ClassID"));
            classInfo.ShowDialog();

            LoadAllTeachersTeachSubject(_classID);
        }

        private void ShowGroupDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowGroupInfo groupInfo = new frmShowGroupInfo(ucSubList1.GetIDFromDGV("GroupID"));
            groupInfo.ShowDialog();

            LoadAllTeachersTeachSubject(_classID);
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (ucSubList1.RowsCount > 0);
        }
    }
}
