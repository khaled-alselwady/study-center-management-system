using StudyCenterBusiness;
using System;
using System.Windows.Forms;
using static StudyCenterUI.GeneralUserControls.ucFilter;

namespace StudyCenterUI.People.UserControls
{
    public partial class ucPersonCardWithFilter : UserControl
    {
        #region Declare Event
        public class PersonSelectedEventArgs : EventArgs
        {
            public int? PersonID { get; }

            public PersonSelectedEventArgs(int? personID)
            {
                PersonID = personID;
            }
        }

        public event EventHandler<PersonSelectedEventArgs> OnPersonSelected;

        public void RaiseOnPersonSelected(int? personID)
        {
            RaiseOnPersonSelected(new PersonSelectedEventArgs(personID));
        }

        protected void RaiseOnPersonSelected(PersonSelectedEventArgs e)
        {
            OnPersonSelected?.Invoke(this, e);
        }
        #endregion

        public int? PersonID => ucPersonCard1.PersonID;
        public clsPerson PersonInfo => ucPersonCard1.PersonInfo;

        public bool FilterEnabled
        {
            get => ucFilter1.FilterEnabled;
            set => ucFilter1.FilterEnabled = value;
        }


        public ucPersonCardWithFilter()
        {
            InitializeComponent();

            ucFilter1.ItemsInComboBox(new[] { ("Person ID", true) });
        }

        public void LoadPersonInfo(int? personID)
        {
            ucFilter1.TextSearch = personID.ToString();
            ucPersonCard1.LoadPersonInfo(personID);

            if (OnPersonSelected != null)
                RaiseOnPersonSelected(ucPersonCard1?.PersonID);
        }

        public void FilterFocus() => ucFilter1.FilterFocus();

        public void Reset() => ucPersonCard1.Reset();

        private void ucPersonCard1_Load(object sender, EventArgs e)
        {
            ucFilter1.FilterFocus();
        }

        private void ucFilter1_OnFindNumericClick(object sender, FindNumericClickEventArgs e)
        {
            switch (e?.FieldName)
            {
                case "Person ID":
                    LoadPersonInfo(e?.Value);
                    break;
            }
        }

        private void ucFilter1_OnAddClick(object sender, EventArgs e)
        {
            frmAddEditPerson addPerson = new frmAddEditPerson();
            addPerson.PersonIDBack += LoadPersonInfo;
            addPerson.ShowDialog();
        }
    }
}
