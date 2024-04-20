using StudyCenterUI.Groups;
using StudyCenterUI.Students;
using StudyCenterBusiness;
using System.Windows.Forms;

namespace StudyCenterUI.Classes.UserControls
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
                                     ("Group Name", 160),
                                     ("Class Name", 160),
                                     ("Teacher Name", 200),
                                     ("Subject Name", 200),
                                     ("Grade Name", 200),
                                     ("Start Time", 150),
                                     ("End Time", 150),
                                     ("Meeting Days", 150),
                                     ("Students Count", 150),
                                     ("Is Active", 100)
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
