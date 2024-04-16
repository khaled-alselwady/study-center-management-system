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

        public void LoadAllTeachersTeachSubject(int? subjectGradeLevelID)
        {
            _subjectGradeLevelID = subjectGradeLevelID;

            object dataSource = clsSubjectGradeLevel.AllTeachersTeachSubject(_subjectGradeLevelID);

            var columnsInfo = new[] { ("Teacher ID", 110),
                                     ("Full Name", 300),
                                     ("Gender", 120),
                                     ("Date Of Birth", 120),
                                     ("Education Level", 160),
                                     ("Age", 60)
                                    };

            ucSubList1.LoadInfo(_subjectGradeLevelID, dataSource, columnsInfo);

            ucSubList1.Title = $"Teachers are teaching {clsSubject.GetSubjectNameBySubjectGradeLevelID(_subjectGradeLevelID)}";
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmShowTeacherInfo showTeacherInfo = new frmShowTeacherInfo(ucSubList1.GetIDFromDGV("TeacherID"));
            showTeacherInfo.ShowDialog();

            LoadAllTeachersTeachSubject(_subjectGradeLevelID);
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (ucSubList1.RowsCount > 0);
        }
    }
}
