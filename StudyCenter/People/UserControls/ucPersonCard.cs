using StudyCenterUI.GlobalClasses;
using StudyCenterUI.Properties;
using StudyCenterBusiness;
using System;
using System.Windows.Forms;

namespace StudyCenterUI.People.UserControls
{
    public partial class ucPersonCard : UserControl
    {
        private int? _personID = null;
        private clsPerson _person = null;

        public int? PersonID => _personID;
        public clsPerson PersonInfo => _person;

        public ucPersonCard()
        {
            InitializeComponent();
        }

        private void _FillPersonData()
        {
            lblPersonID.Text = _person.PersonID.ToString();
            lblFullName.Text = _person.FullName;
            lblGender.Text = _person.GenderName;
            lblEmail.Text = _person.Email ?? "N/A";
            lblPhone.Text = _person.PhoneNumber;
            lblDateOfBirth.Text = clsFormat.DateToShort(_person.DateOfBirth);
            lblAddress.Text = _person.Address;
            lblAge.Text = (DateTime.Now.Year - _person.DateOfBirth.Year).ToString();

            pbGender.Image = (_person.Gender == clsPerson.enGender.Male) ?
                              Resources.gender_male : Resources.gender_female;

            llEditPersonInfo.Enabled = true;
        }

        public void Reset()
        {
            _personID = null;
            _person = null;

            lblPersonID.Text = "[????]";
            lblFullName.Text = "[????]";
            pbGender.Image = Resources.gender_male;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblAge.Text = "[????]";
            lblAddress.Text = "[????]";

            llEditPersonInfo.Enabled = false;
        }

        public void LoadPersonInfo(int? personID)
        {
            _personID = personID;

            if (!_personID.HasValue)
            {
                clsStandardMessages.ShowMissingDataMessage("person", _personID);

                Reset();

                return;
            }

            _person = clsPerson.Find(_personID);

            if (_person == null)
            {
                clsStandardMessages.ShowMissingDataMessage("person", _personID);

                Reset();

                return;
            }

            _FillPersonData();
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson editPerson = new frmAddEditPerson(_personID);
            editPerson.ShowDialog();

            // Refresh
            LoadPersonInfo(_personID);
        }
    }
}
