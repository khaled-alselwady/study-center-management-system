﻿using StudyCenter_Business;
using System;
using System.Windows.Forms;

namespace StudyCenter.Teachers.UserControls
{
    public partial class ucTeacherCardWithFilter : UserControl
    {
        #region Declare Event
        public class TeacherSelectedEventArgs : EventArgs
        {
            public int? TeacherID { get; }

            public TeacherSelectedEventArgs(int? teacherID)
            {
                TeacherID = teacherID;
            }
        }

        public event EventHandler<TeacherSelectedEventArgs> OnTeacherSelected;

        public void RaiseOnTeacherSelected(int? teacherID)
        {
            RaiseOnTeacherSelected(new TeacherSelectedEventArgs(teacherID));
        }

        protected void RaiseOnTeacherSelected(TeacherSelectedEventArgs e)
        {
            OnTeacherSelected?.Invoke(this, e);
        }
        #endregion

        public int? Teacher => ucTeacherCard1.TeacherID;
        public clsTeacher TeacherInfo => ucTeacherCard1.TeacherInfo;

        public ucTeacherCardWithFilter()
        {
            InitializeComponent();

            // add the items that you want to search in the combo box 
            ucFilter1.ItemsInComboBox(new[] { ("Teacher ID", true), ("Person ID", true) });
        }

        public void LoadTeacherInfoByTeacherID(int? teacherID)
        {
            ucFilter1.TextSearch = teacherID?.ToString();
            ucTeacherCard1.LoadTeacherInfoByTeacherID(teacherID);

            if (OnTeacherSelected != null)
                RaiseOnTeacherSelected(ucTeacherCard1?.TeacherID);
        }

        public void LoadTeacherInfoByPersonID(int? personID)
        {
            ucFilter1.TextSearch = personID?.ToString();
            ucTeacherCard1.LoadTeacherInfoByPersonID(personID);

            if (OnTeacherSelected != null)
                RaiseOnTeacherSelected(ucTeacherCard1?.TeacherID);
        }

        public void Clear() => ucTeacherCard1.Reset();

        public void FilterFocus() => ucFilter1.FilterFocus();

        private void ucTeacherCard1_Load(object sender, EventArgs e)
        {
            ucFilter1.FilterFocus();
        }

        private void ucFilter1_OnAddClick(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }

        private void ucFilter1_OnFindNumericClick(object sender, GeneralUserControls.ucFilter.FindNumericClickEventArgs e)
        {
            switch (e?.FieldName)
            {
                case "Teacher ID":
                    LoadTeacherInfoByTeacherID(e?.Value);
                    break;

                case "Person ID":
                    LoadTeacherInfoByPersonID(e?.Value);
                    break;
            }
        }
    }
}
