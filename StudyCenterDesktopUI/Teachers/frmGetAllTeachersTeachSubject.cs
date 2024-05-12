using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Teachers
{
    public partial class frmGetAllTeachersTeachSubject : Form
    {
        private int? _subjectGradeLevelID = null;
        private int? _selectedTeacherID = null;
        private clsSubjectTeacher _subjectTeacher = null;

        public frmGetAllTeachersTeachSubject(int? subjectGradeLevelID)
        {
            InitializeComponent();

            _subjectGradeLevelID = subjectGradeLevelID;

            ucGetAllTeachersTeachSubject1.LoadAllTeachersTeachSubject(subjectGradeLevelID);
        }

        private void _FillSubjectTeacherObjectWithFieldsData()
        {
            _subjectTeacher = new clsSubjectTeacher();
            _subjectTeacher.TeacherID = _selectedTeacherID;
            _subjectTeacher.SubjectGradeLevelID = _subjectGradeLevelID;
            _subjectTeacher.IsActive = true;
        }

        private void _SaveSubjectTeacher()
        {
            _FillSubjectTeacherObjectWithFieldsData();

            if (_subjectTeacher.Save())
            {
                clsStandardMessages.ShowSuccess("Subject Teacher");
            }
            else
            {
                clsStandardMessages.ShowError("Subject Teacher");
            }
        }

        private void _GetTeacherIDFromFindTeacherForm(int? teacherID)
        {
            _selectedTeacherID = teacherID;

            if (clsSubjectTeacher.IsTeachingSubject(_selectedTeacherID, _subjectGradeLevelID))
            {
                MessageBox.Show("This teacher is currently teaching the specified subject. Choose another one.",
                    "Teacher Subject Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _SaveSubjectTeacher();

                // Refresh
                ucGetAllTeachersTeachSubject1.LoadAllTeachersTeachSubject(_subjectGradeLevelID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            frmFindTeacher findTeacher = new frmFindTeacher();
            findTeacher.TeacherIDBack += _GetTeacherIDFromFindTeacherForm;
            findTeacher.ShowDialog();
        }
    }
}
