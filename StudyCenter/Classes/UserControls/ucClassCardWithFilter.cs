using StudyCenter_Business;
using System;
using System.Windows.Forms;
using static StudyCenter.GeneralUserControls.ucFilter;

namespace StudyCenter.Classes.UserControls
{
    public partial class ucClassCardWithFilter : UserControl
    {
        #region Declare Event
        public class ClassSelectedEventArgs : EventArgs
        {
            public int? ClassID { get; }

            public ClassSelectedEventArgs(int? classID)
            {
                ClassID = classID;
            }
        }

        public event EventHandler<ClassSelectedEventArgs> OnClassSelected;

        public void RaiseOnClassSelected(int? classID)
        {
            RaiseOnClassSelected(new ClassSelectedEventArgs(classID));
        }

        protected void RaiseOnClassSelected(ClassSelectedEventArgs e)
        {
            OnClassSelected?.Invoke(this, e);
        }
        #endregion

        public int? ClassID => ucClassCard1.ClassID;
        public clsClass ClassInfo => ucClassCard1.ClassInfo;

        public ucClassCardWithFilter()
        {
            InitializeComponent();

            // add the items that you want to search in the combo box 
            ucFilter1.ItemsInComboBox(new[] { ("Class ID", true) });
        }

        public void LoadClassInfo(int? classID)
        {
            ucFilter1.TextSearch = classID?.ToString();
            ucClassCard1.LoadClassInfo(classID);

            if (OnClassSelected != null)
                RaiseOnClassSelected(ucClassCard1?.ClassID);
        }

        public void Clear() => ucClassCard1.Reset();

        public void FilterFocus() => ucFilter1.FilterFocus();

        private void ucClassCard1_Load(object sender, EventArgs e)
        {
            ucFilter1.FilterFocus();
        }

        private void ucFilter1_OnFindNumericClick(object sender, FindNumericClickEventArgs e)
        {
            switch (e?.FieldName)
            {
                case "Class ID":
                    LoadClassInfo(e?.Value);
                    break;
            }
        }

        private void ucFilter1_OnAddClick(object sender, EventArgs e)
        {
            frmAddEditClass addClass = new frmAddEditClass();
            addClass.ClassIDBack += LoadClassInfo;
            addClass.ShowDialog();
        }
    }
}
