using StudyCenter_Business;
using System.Windows.Forms;

namespace StudyCenter.SubjectsAndGradeLevels.userControls
{
    public partial class ucGetAllSubjectsTaughtByTeacher : UserControl
    {
        private int? _teacherID = null;

        public ucGetAllSubjectsTaughtByTeacher()
        {
            InitializeComponent();
        }

        private void _RefreshSubjectsTaughtByTeacherList()
        {
            dgvSubjectsTaughtByTeacherList.DataSource =
                clsSubjectTeacher.AllSubjectsTaughtByTeacher(_teacherID);
            lblNumberOfRecords.Text = dgvSubjectsTaughtByTeacherList.Rows.Count.ToString();

            if (dgvSubjectsTaughtByTeacherList.Rows.Count > 0)
            {
                dgvSubjectsTaughtByTeacherList.Columns[0].HeaderText = "Subject Teacher ID";
                dgvSubjectsTaughtByTeacherList.Columns[0].Width = 180;

                dgvSubjectsTaughtByTeacherList.Columns[1].HeaderText = "Teacher ID";
                dgvSubjectsTaughtByTeacherList.Columns[1].Width = 120;

                dgvSubjectsTaughtByTeacherList.Columns[2].HeaderText = "Subject Grade-Level ID";
                dgvSubjectsTaughtByTeacherList.Columns[2].Width = 200;

                dgvSubjectsTaughtByTeacherList.Columns[3].HeaderText = "Subject Name";
                dgvSubjectsTaughtByTeacherList.Columns[3].Width = 200;

                dgvSubjectsTaughtByTeacherList.Columns[4].HeaderText = "Grade Name";
                dgvSubjectsTaughtByTeacherList.Columns[4].Width = 120;

                dgvSubjectsTaughtByTeacherList.Columns[5].HeaderText = "Assignment Date";
                dgvSubjectsTaughtByTeacherList.Columns[5].Width = 160;

                dgvSubjectsTaughtByTeacherList.Columns[6].HeaderText = "Is Active";
                dgvSubjectsTaughtByTeacherList.Columns[6].Width = 110;
            }
        }

        private int? _GetSubjectTeacherIDFromDGV()
        {
            return (int?)dgvSubjectsTaughtByTeacherList.CurrentRow.Cells["SubjectTeacherID"].Value;
        }

        public void LoadSubjectsInfoTaughtByTeacher(int? teacherID)
        {
            _teacherID = teacherID;

            _RefreshSubjectsTaughtByTeacherList();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This features is not implemented yet!");
        }
    }
}
