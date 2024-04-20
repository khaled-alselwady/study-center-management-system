using StudyCenterUI.GlobalClasses;
using StudyCenterBusiness;
using System.Windows.Forms;

namespace StudyCenterUI.Students.UserControls
{
    public partial class ucGetAllStudentsInGroup : UserControl
    {
        private int? _groupID = null;
        private string _groupName = null;

        public ucGetAllStudentsInGroup()
        {
            InitializeComponent();
        }

        private void _LoadInfo(string title)
        {
            object dataSource = clsGroup.AllStudentsInGroup(_groupID);

            var columnsInfo = new[] { ("Student ID", 110),
                                     ("Full Name", 300),
                                     ("Gender", 120),
                                     ("Date Of Birth", 120),
                                     ("Grade", 130),
                                     ("Age", 60)
            };

            ucSubList1.LoadInfo(_groupID, dataSource, columnsInfo);
            ucSubList1.Title = title;
        }

        public void LoadAllStudentsInGroup(int? groupID)
        {
            _groupID = groupID;

            _LoadInfo("Students are in the group");
        }

        public void LoadAllStudentsInGroup(int? groupID, string groupName)
        {
            _groupID = groupID;
            _groupName = groupName;

            _LoadInfo($"Students are in the group {_groupName}");
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowStudentInfo showStudentInfo = new frmShowStudentInfo((int?)ucSubList1.GetIDFromDGV("StudentID"));
            showStudentInfo.ShowDialog();

            LoadAllStudentsInGroup(_groupID, _groupName);
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (ucSubList1.RowsCount > 0);
        }

        private void RemoveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (clsStandardMessages.ShowDeleteConfirmation("student from the group") == DialogResult.No)
                return;

            if (clsStudentGroup.Delete((int?)ucSubList1.GetIDFromDGV("StudentID"), _groupID))
            {
                clsStandardMessages.ShowDeletionSuccess("student");

                LoadAllStudentsInGroup(_groupID, _groupName);
            }
            else
                clsStandardMessages.ShowDeletionFailure("student",
                    "Please check your permissions and try again.");
        }
    }
}
