using StudyCenter_Business;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudyCenter.Teachers.UserControls
{
    public partial class ucGetAllTeachersTeachSubject : UserControl
    {
        private int? _subjectGradeLevelID = null;

        public ucGetAllTeachersTeachSubject()
        {
            InitializeComponent();
        }

        private void _RefreshAllTeachersTeachSubjectList()
        {
            dgvTeachersList.DataSource =
                clsSubjectGradeLevel.AllTeachersTeachSubject(_subjectGradeLevelID);

            lblNumberOfRecords.Text = dgvTeachersList.Rows.Count.ToString();

            if (dgvTeachersList.Rows.Count > 0)
            {
                dgvTeachersList.Columns[0].HeaderText = "Teacher ID";
                dgvTeachersList.Columns[0].Width = 110;

                dgvTeachersList.Columns[1].HeaderText = "Full Name";
                dgvTeachersList.Columns[1].Width = 300;

                dgvTeachersList.Columns[2].HeaderText = "Gender";
                dgvTeachersList.Columns[2].Width = 120;

                dgvTeachersList.Columns[3].HeaderText = "Date Of Birth";
                dgvTeachersList.Columns[3].Width = 120;

                dgvTeachersList.Columns[4].HeaderText = "Education Level";
                dgvTeachersList.Columns[4].Width = 160;

                dgvTeachersList.Columns[5].HeaderText = "Age";
                dgvTeachersList.Columns[5].Width = 60;
            }
        }

        private int? _GetTeacherIDFromDGV()
        {
            return (int?)dgvTeachersList.CurrentRow.Cells["TeacherID"].Value;
        }

        public void LoadAllTeachersTeachSubject(int? subjectGradeLevelID)
        {
            _subjectGradeLevelID = subjectGradeLevelID;

            _RefreshAllTeachersTeachSubjectList();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowTeacherInfo showTeacherInfo = new frmShowTeacherInfo(_GetTeacherIDFromDGV());
            showTeacherInfo.ShowDialog();

            _RefreshAllTeachersTeachSubjectList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvTeachersList.Rows.Count > 0);
        }

        private void dgvTeachersList_DoubleClick(object sender, System.EventArgs e)
        {
            frmShowTeacherInfo showTeacherInfo = new frmShowTeacherInfo(_GetTeacherIDFromDGV());
            showTeacherInfo.ShowDialog();

            _RefreshAllTeachersTeachSubjectList();
        }
    }
}
