using StudyCenter_Business;
using System;
using System.Windows.Forms;
using static StudyCenter.GeneralUserControls.ucFilter;

namespace StudyCenter.Students.UserControls
{
    public partial class ucStudentCardWithFilter : UserControl
    {
        #region Declare Event
        public class StudentSelectedEventArgs : EventArgs
        {
            public int? StudentID { get; }

            public StudentSelectedEventArgs(int? studentID)
            {
                StudentID = studentID;
            }
        }

        public event EventHandler<StudentSelectedEventArgs> OnStudentSelected;

        public void RaiseOnStudentSelected(int? studentID)
        {
            RaiseOnStudentSelected(new StudentSelectedEventArgs(studentID));
        }

        protected void RaiseOnStudentSelected(StudentSelectedEventArgs e)
        {
            OnStudentSelected?.Invoke(this, e);
        }
        #endregion

        public int? StudentID => ucStudentCard1.StudentID;
        public clsStudent StudentInfo => ucStudentCard1.StudentInfo;

        public ucStudentCardWithFilter()
        {
            InitializeComponent();

            // add the items that you want to search in the combo box 
            ucFilter1.ItemsInComboBox(new[] { ("Student ID", true), ("Person ID", true) });
            //ucFilter1.ItemsInComboBox(new[] { ("Person ID", true) });
        }

        public void LoadStudentInfoByStudentID(int? studentID)
        {
            ucFilter1.TextSearch = studentID?.ToString();
            ucStudentCard1.LoadStudentInfoByStudentID(studentID);

            if (OnStudentSelected != null)
                RaiseOnStudentSelected(ucStudentCard1?.StudentID);
        }

        public void LoadStudentInfoByPersonID(int? personID)
        {
            ucFilter1.TextSearch = personID?.ToString();
            ucStudentCard1.LoadStudentInfoByPersonID(personID);

            if (OnStudentSelected != null)
                RaiseOnStudentSelected(ucStudentCard1?.StudentID);
        }

        public void Clear() => ucStudentCard1.Reset();

        public void FilterFocus() => ucFilter1.FilterFocus();

        private void ucStudentCard1_Load(object sender, EventArgs e)
        {
            ucFilter1.FilterFocus();
        }

        private void ucFilter1_OnAddClick(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }

        private void ucFilter1_OnFindNumericClick(object sender, FindNumericClickEventArgs e)
        {
            switch (e?.FieldName)
            {
                case "Student ID":
                    LoadStudentInfoByStudentID(e?.Value);
                    break;

                case "Person ID":
                    LoadStudentInfoByPersonID(e?.Value);
                    break;
            }

        }
    }
}
