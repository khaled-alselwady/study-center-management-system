using StudyCenter.Groups;
using StudyCenter.Students;
using StudyCenter_Business;
using System.Windows.Forms;

namespace StudyCenter.Classes.UserControls
{
    public partial class ucGetAllActiveGroupsInClass : UserControl
    {

        private int? _classID = null;

        public ucGetAllActiveGroupsInClass()
        {
            InitializeComponent();
        }

        private int? _GetGroupIDFromDGV()
        {
            return (int?)ucSubList1.GetIDFromDGV("GroupID");
        }

        private string _GetGroupNameFromDGV()
        {
            return (string)ucSubList1.GetIDFromDGV("GroupName");
        }

        public void LoadAllActiveGroupsInClass(int? classID)
        {
            _classID = classID;

            object dataSource = clsClass.AllActiveGroupsInClass(_classID);

            var columnsInfo = new[] { ("Group ID", 110),
                                     ("Group Name", 300),
                                     ("Class Name", 300),
                                     ("Teacher Name", 300),
                                     ("Subject Name", 300),
                                     ("Grade Name", 300),
                                     ("Start Time", 120),
                                     ("End Time", 120),
                                     ("Meeting Days", 120),
                                     ("Students Count", 130),
                                     ("Is Active", 60)
                                    };

            ucSubList1.LoadInfo(_classID, dataSource, columnsInfo);

            ucSubList1.Title = "Active Groups in a Class";
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (ucSubList1.RowsCount > 0);
        }

        private void tsmShowGroupDetails_Click(object sender, System.EventArgs e)
        {
            frmShowGroupInfo showGroupInfo = new frmShowGroupInfo(_GetGroupIDFromDGV());
            showGroupInfo.ShowDialog();

            LoadAllActiveGroupsInClass(_classID);
        }

        private void tsmEditGroup_Click(object sender, System.EventArgs e)
        {
            frmAddEditGroup editGroup = new frmAddEditGroup(_GetGroupIDFromDGV(), frmAddEditGroup.enEntityType.GroupID);
            editGroup.ShowDialog();

            LoadAllActiveGroupsInClass(_classID);
        }

        private void temDeleteGroup_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }

        private void ShowAllStudentsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmGetAllStudentsInGroup getAllStudentsInGroup = new frmGetAllStudentsInGroup(_GetGroupIDFromDGV(), _GetGroupNameFromDGV());
            getAllStudentsInGroup.ShowDialog();

            LoadAllActiveGroupsInClass(_classID);
        }

        private void AddStudentToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmAddEditAssignStudentToGroup addStudentToGroup = new frmAddEditAssignStudentToGroup(_GetGroupIDFromDGV(), frmAddEditAssignStudentToGroup.enEntityType.GroupID);
            addStudentToGroup.ShowDialog();

            LoadAllActiveGroupsInClass(_classID);
        }
    }
}
