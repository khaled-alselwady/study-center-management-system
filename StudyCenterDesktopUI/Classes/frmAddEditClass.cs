using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using System;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Classes
{
    public partial class frmAddEditClass : Form
    {
        public Action<int?> ClassIDBack;

        private enum _enMode { Add, Update };
        private _enMode _mode = _enMode.Add;

        private int? _classID = null;
        private clsClass _class = null;

        public frmAddEditClass()
        {
            InitializeComponent();

            _mode = _enMode.Add;
        }

        public frmAddEditClass(int? classID)
        {
            InitializeComponent();

            _classID = classID;
            _mode = _enMode.Update;
        }

        private void _ResetFields()
        {
            txtClassName.Clear();
            numaricCapacity.Value = 1;
            txtDescription.Clear();
        }

        private void _ResetDefaultValues()
        {
            if (_mode == _enMode.Add)
            {
                lblTitle.Text = "Add New Class";
                _class = new clsClass();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Class";
            }

            this.Text = lblTitle.Text;
        }

        private void _FillFieldsWithClassInfo()
        {
            lblClassID.Text = _class.ClassID.ToString();
            txtClassName.Text = _class.ClassName;
            numaricCapacity.Value = _class.Capacity;
            txtDescription.Text = _class.Description ?? "N/A";
        }

        private void _LoadData()
        {
            _class = clsClass.Find(_classID);

            if (_class == null)
            {
                clsStandardMessages.ShowMissingDataMessage("class", _classID);

                this.Close();
                return;
            }

            _FillFieldsWithClassInfo();
        }

        private void _FillClassObjectWithFieldsData()
        {
            _class.ClassName = txtClassName.Text.Trim();
            _class.Capacity = (byte)numaricCapacity.Value;
            _class.Description = txtDescription.Text.Trim();
        }

        private void _SaveClass()
        {
            _FillClassObjectWithFieldsData();

            if (_class.Save())
            {
                lblTitle.Text = "Update Class";
                this.Text = lblTitle.Text;
                lblClassID.Text = _class.ClassID.ToString();

                // change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("Class");

                // Trigger the event to send data back to the caller form
                ClassIDBack?.Invoke(_class?.ClassID);
            }
            else
            {
                clsStandardMessages.ShowError("class");
            }
        }

        private void frmAddEditClass_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_mode == _enMode.Update)
                _LoadData();

            txtDescription.BorderRadius = 17;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                clsStandardMessages.ShowValidationErrorMessage();
                return;
            }

            _SaveClass();
        }

        private void txtClassName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClassName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtClassName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtClassName, null);
            }

            if ((_class?.ClassName.ToLower() != txtClassName.Text.Trim().ToLower()) &&
                clsClass.Exists(txtClassName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtClassName, "This class already exists! choose another one.");
            }
            else
            {
                errorProvider1.SetError(txtClassName, null);
            }
        }

        private void frmAddEditClass_Activated(object sender, EventArgs e)
        {
            txtClassName.Focus();
        }
    }
}
