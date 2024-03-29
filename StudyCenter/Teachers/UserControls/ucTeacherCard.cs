﻿using StudyCenter.GlobalClasses;
using StudyCenter_Business;
using System.Windows.Forms;

namespace StudyCenter.Teachers.UserControls
{
    public partial class ucTeacherCard : UserControl
    {
        private int? _teacherID = null;
        private clsTeacher _teacher = null;

        public int? TeacherID => _teacherID;
        public clsTeacher TeacherInfo => _teacher;

        public int? PersonID => ucPersonCard1.PersonID;
        public clsPerson PersonInfo => ucPersonCard1.PersonInfo;

        public ucTeacherCard()
        {
            InitializeComponent();
        }

        private void _FillTeacherData()
        {
            ucPersonCard1.LoadPersonInfo(_teacher.PersonID);

            lblTeacherID.Text = _teacher.TeacherID.ToString();
            lblCertifications.Text = _teacher.Certifications;
            lblEducationLevel.Text = _teacher.EducationLevel;
            lblTeachingExperience.Text = _teacher.TeachingExperience.ToString() + PrintYearOrYears();
            lblCreatedByUser.Text = _teacher.CreatedByUserInfo.Username;
            lblCreationDate.Text = clsFormat.DateToShort(_teacher.CreationDate);

            llEditTeacherInfo.Enabled = true;
        }

        private string PrintYearOrYears()
        {
            return ((_teacher?.TeachingExperience == 1) ? " Year" : " Years");
        }

        public void Reset()
        {
            _teacherID = null;
            _teacher = null;

            ucPersonCard1.Reset();

            lblTeacherID.Text = "[????]";
            lblTeachingExperience.Text = "[????]";
            lblCertifications.Text = "[????]";
            lblEducationLevel.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblCreationDate.Text = "[????]";

            llEditTeacherInfo.Enabled = false;
        }

        public void LoadTeacherInfoByTeacherID(int? teacherID)
        {
            _teacherID = teacherID;

            if (!_teacherID.HasValue)
            {
                MessageBox.Show("There is no a teacher!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _teacher = clsTeacher.FindByTeacherID(_teacherID);

            if (_teacher == null)
            {
                MessageBox.Show($"There is no a teacher with ID = {_teacherID} !",
                    "Missing teacher", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillTeacherData();
        }

        public void LoadTeacherInfoByPersonID(int? personID)
        {
            if (!personID.HasValue)
            {
                MessageBox.Show("There is no a teacher!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _teacher = clsTeacher.FindByPersonID(personID);

            if (_teacher == null)
            {
                MessageBox.Show($"There is no a teacher with Person ID = {personID} !",
                    "Missing teacher", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillTeacherData();
        }
    }
}
