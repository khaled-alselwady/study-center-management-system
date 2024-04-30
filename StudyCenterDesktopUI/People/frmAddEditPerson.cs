using Guna.UI2.WinForms;
using StudyCenterDesktopUI.GlobalClasses;
using StudyCenterDesktopUI.Properties;
using StudyCenterBusiness;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.People
{
    public partial class frmAddEditPerson : Form
    {
        public Action<int?> PersonIDBack;

        private enum _enMode { Add, Update };
        private _enMode _mode = _enMode.Add;

        private int? _personID = null;
        private clsPerson _person = null;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _mode = _enMode.Add;
        }

        public frmAddEditPerson(int? personID)
        {
            InitializeComponent();

            _personID = personID;
            _mode = _enMode.Update;
        }

        private void _ResetFields()
        {
            foreach (Control item in this.Controls)
            {
                if (item is Guna2TextBox txtGuna)
                    txtGuna.Clear();
            }

            rbMale.Checked = true;
            pbGender.Image = Resources.gender_male;
        }

        private void _ResetDefaultValues()
        {
            if (_mode == _enMode.Add)
            {
                lblTitle.Text = "Add New Person";
                _person = new clsPerson();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            this.Text = lblTitle.Text;

            //Determine the maximum and minimum age allowed in the system
            if (byte.TryParse(ConfigurationManager.AppSettings["MaxPersonAge"], out byte maxAge))
                dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-maxAge);
            else
                dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            if (byte.TryParse(ConfigurationManager.AppSettings["MinPersonAge"], out byte minAge))
                dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-minAge);
            else
                dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-10);
        }

        private void _FillFieldsWithPersonInfo()
        {
            lblPersonID.Text = _person.PersonID.ToString();
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtEmail.Text = _person.Email;
            txtAddress.Text = _person.Address;
            txtPhone.Text = _person.PhoneNumber;
            dtpDateOfBirth.Value = _person.DateOfBirth;

            if (_person.Gender == (byte)clsPerson.enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
        }

        private void _LoadData()
        {
            _person = clsPerson.Find(_personID);

            if (_person == null)
            {
                clsStandardMessages.ShowMissingDataMessage("person", _personID);

                this.Close();
                return;
            }

            _FillFieldsWithPersonInfo();
        }

        private void _ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Guna2TextBox)sender).Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(((Guna2TextBox)sender), "This field is required!");
            }
            else
            {
                errorProvider1.SetError(((Guna2TextBox)sender), null);
            }
        }

        private void _FillPersonObjectWithFieldsData()
        {
            _person.FirstName = txtFirstName.Text.Trim();
            _person.SecondName = txtSecondName.Text.Trim();
            _person.ThirdName = string.IsNullOrWhiteSpace(txtThirdName.Text.Trim()) ? null : txtThirdName.Text.Trim();
            _person.LastName = txtLastName.Text.Trim();
            _person.Email = string.IsNullOrWhiteSpace(txtEmail.Text.Trim()) ? null : txtEmail.Text.Trim();
            _person.Address = string.IsNullOrWhiteSpace(txtAddress.Text.Trim()) ? null : txtAddress.Text.Trim();
            _person.PhoneNumber = txtPhone.Text.Trim();
            _person.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _person.DateOfBirth = dtpDateOfBirth.Value;
        }

        private void _SavePerson()
        {
            _FillPersonObjectWithFieldsData();

            if (_person.Save())
            {
                lblTitle.Text = "Update Person";
                this.Text = lblTitle.Text;
                lblPersonID.Text = _person.PersonID.ToString();

                // change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("Person");

                // Trigger the event to send data back to the caller form
                PersonIDBack?.Invoke(_person?.PersonID);
            }
            else
            {
                clsStandardMessages.ShowError("person");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_mode == _enMode.Update)
                _LoadData();

            txtAddress.BorderRadius = 17;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }

            //validate email format
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbGender.Image = Resources.gender_female;
        }

        private void lblFemale_Click(object sender, EventArgs e)
        {
            rbFemale.Checked = true;
            pbGender.Image = Resources.gender_female;
        }

        private void lblMale_Click(object sender, EventArgs e)
        {
            rbMale.Checked = true;
            pbGender.Image = Resources.gender_male;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbGender.Image = Resources.gender_male;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                clsStandardMessages.ShowValidationErrorMessage();
                return;
            }

            _SavePerson();
        }

        private void frmAddEditPerson_Activated(object sender, EventArgs e)
        {
            txtFirstName.Focus();
        }
    }
}
