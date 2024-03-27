using StudyCenter_Business;
using System;
using System.Windows.Forms;

namespace StudyCenter.People.UserControls
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

        private bool _showAddPersonButton = true;
        public bool ShowAddPersonButton
        {
            get => _showAddPersonButton;
            set => btnAddNewPerson.Visible = _showAddPersonButton = value;
        }

        private bool _filterEnable = true;
        public bool FilterEnabled
        {
            get => _filterEnable;
            set => gbFilter.Enabled = _filterEnable = value;
        }

        public int? PersonID => ucPersonCard1.PersonID;
        public clsPerson PersonInfo => ucPersonCard1.PersonInfo;

        public ucPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int? personID)
        {
            txtSearch.Text = personID.ToString();
            ucPersonCard1.LoadPersonInfo(personID);

            if (OnPersonSelected != null)
                RaiseOnPersonSelected(ucPersonCard1?.PersonID);
        }

        public void FilterFocus() => txtSearch.Focus();

        public void Clear() => ucPersonCard1.Reset();

        private void txtSearch_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSearch, "This field cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtSearch, null);
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadPersonInfo(int.Parse(txtSearch.Text.Trim()));
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
                btnFindPerson.PerformClick();

            // to make sure that the user can enter only numbers in case searching by Person ID
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ucPersonCard1_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }
    }
}
