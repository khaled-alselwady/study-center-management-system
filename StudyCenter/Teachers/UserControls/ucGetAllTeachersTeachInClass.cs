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

        private void _RefreshAllTeachersTeachInClassList()
        {
            dgvTeachersList.DataSource =
                clsClass.AllTeachersTeachInClass(_classID);

            lblNumberOfRecords.Text = dgvTeachersList.Rows.Count.ToString();

            if (dgvTeachersList.Rows.Count > 0)
            {
                dgvTeachersList.Columns[0].HeaderText = "Teacher ID";
                dgvTeachersList.Columns[0].Width = 110;

                dgvTeachersList.Columns[1].HeaderText = "Full Name";
                dgvTeachersList.Columns[1].Width = 300;

                dgvTeachersList.Columns[2].HeaderText = "Class ID";
                dgvTeachersList.Columns[2].Width = 120;

                dgvTeachersList.Columns[3].HeaderText = "Group ID";
                dgvTeachersList.Columns[3].Width = 120;

                dgvTeachersList.Columns[4].HeaderText = "Group Name";
                dgvTeachersList.Columns[4].Width = 160;

                dgvTeachersList.Columns[5].HeaderText = "Subject Name";
                dgvTeachersList.Columns[5].Width = 150;

                dgvTeachersList.Columns[6].HeaderText = "Grade Name";
                dgvTeachersList.Columns[6].Width = 120;
            }
        }

        private int? _GetIDFromDGV(string entityName = "TeacherID")
        {
            return (int?)dgvTeachersList.CurrentRow.Cells[entityName].Value;
        }

        public void LoadAllTeachersTeachSubject(int? classID)
        {
            _classID = classID;

            _RefreshAllTeachersTeachInClassList();
        }

        private void ShowTeacherDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowTeacherInfo teacherInfo = new frmShowTeacherInfo(_GetIDFromDGV());
            teacherInfo.ShowDialog();

            _RefreshAllTeachersTeachInClassList();
        }

        private void ShowClassDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowClassInfo classInfo = new frmShowClassInfo(_GetIDFromDGV("ClassID"));
            classInfo.ShowDialog();

            _RefreshAllTeachersTeachInClassList();
        }

        private void ShowGroupDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowGroupInfo groupInfo = new frmShowGroupInfo(_GetIDFromDGV("GroupID"));
            groupInfo.ShowDialog();

            _RefreshAllTeachersTeachInClassList();
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvTeachersList.Rows.Count > 0);
        }

        private void dgvTeachersList_DoubleClick(object sender, System.EventArgs e)
        {
            frmShowTeacherInfo teacherInfo = new frmShowTeacherInfo(_GetIDFromDGV());
            teacherInfo.ShowDialog();

            _RefreshAllTeachersTeachInClassList();
        }
    }
}
