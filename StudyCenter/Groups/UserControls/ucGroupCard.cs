using StudyCenterBusiness;
using StudyCenterUI.Classes;
using StudyCenterUI.GlobalClasses;
using StudyCenterUI.Properties;
using StudyCenterUI.SubjectsAndGradeLevels;
using StudyCenterUI.Teachers;
using System.Windows.Forms;

namespace StudyCenterUI.Groups.UserControls
{
    public partial class ucGroupCard : UserControl
    {
        private int? _groupID = null;
        private clsGroup _group = null;

        public int? groupID => _groupID;
        public clsGroup groupInfo => _group;

        public ucGroupCard()
        {
            InitializeComponent();
        }

        private void _FillStudentData()
        {
            llShowClassInfo.Enabled = true;
            llShowTeacherInfo.Enabled = true;
            llShowSubjectGradeLevelInfo.Enabled = true;

            lblGroupID.Text = _group.GroupID.ToString();
            lblTeacherID.Text = _group.TeacherID.ToString();
            lblClassID.Text = _group.ClassID.ToString();
            lblSubjectGradeLevelID.Text = _group.SubjectTeacherInfo?.SubjectGradeLevelID.ToString();
            lblGroupName.Text = _group.GroupName;
            lblMeetingTime.Text = _group.MeetingTimeInfo.MeetingTimeText();
            lblStudentsCount.Text = _group.GetStudentCount();
            lblCreatedByUsername.Text = _group.CreatedByUserInfo.Username;
            lblCreationDate.Text = clsFormat.DateToShort(_group.CreationDate);
            lblIsActive.Text = (_group.IsActive) ? "Yes" : "No";
            pbIsActive.Image = (_group.IsActive) ? Resources.confirm_32 : Resources.close_48;
        }

        public void Reset()
        {
            _groupID = null;
            _group = null;

            lblGroupID.Text = "[????]";
            lblTeacherID.Text = "[????]";
            lblClassID.Text = "[????]";
            lblSubjectGradeLevelID.Text = "[????]";
            lblGroupName.Text = "[????]";
            lblMeetingTime.Text = "[????]";
            lblStudentsCount.Text = "[????]";
            lblCreatedByUsername.Text = "[????]";
            lblCreationDate.Text = "[????]";
            lblIsActive.Text = "[????]";

            llShowClassInfo.Enabled = false;
            llShowTeacherInfo.Enabled = false;
            llShowSubjectGradeLevelInfo.Enabled = false;
        }

        public void LoadGroupInfo(int? groupID)
        {
            _groupID = groupID;

            if (!_groupID.HasValue)
            {
                clsStandardMessages.ShowMissingDataMessage("group", _groupID);

                Reset();

                return;
            }

            _group = clsGroup.Find(_groupID);

            if (_group == null)
            {
                clsStandardMessages.ShowMissingDataMessage("group", _groupID);

                Reset();

                return;
            }

            _FillStudentData();
        }

        private void llShowClassInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowClassInfo showClassInfo = new frmShowClassInfo(_group?.ClassID);
            showClassInfo.ShowDialog();

            LoadGroupInfo(_groupID);
        }

        private void llShowTeacherInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTeacherInfo showTeacherInfo = new frmShowTeacherInfo(_group?.TeacherID);
            showTeacherInfo.ShowDialog();

            LoadGroupInfo(_groupID);
        }

        private void llShowSubjectGradeLevelInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowSubjectGradeLevelInfo showSubjectGradeLevelInfo = new frmShowSubjectGradeLevelInfo(_group?.SubjectTeacherInfo.SubjectGradeLevelID);
            showSubjectGradeLevelInfo.ShowDialog();

            LoadGroupInfo(_groupID);
        }
    }
}
