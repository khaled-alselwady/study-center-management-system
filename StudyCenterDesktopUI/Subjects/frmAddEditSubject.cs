using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.Subjects
{
    public partial class frmAddEditSubject : Form
    {
        public Action<int?> SubjectIDBack;

        private enum _enMode { Add, Update };
        private _enMode _mode = _enMode.Add;

        private int? _subjectID = null;
        private clsSubject _subject = null;

        public frmAddEditSubject()
        {
            InitializeComponent();

            _mode = _enMode.Add;
        }

        public frmAddEditSubject(int? subjectID)
        {
            InitializeComponent();

            _subjectID = subjectID;
            _mode = _enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if (_mode == _enMode.Add)
            {
                lblTitle.Text = "Add New Subject";
                _subject = new clsSubject();
                txtSubjectName.Clear();
            }
            else
            {
                lblTitle.Text = "Update Subject";
            }

            this.Text = lblTitle.Text;
        }

        private void _FillFieldsWithSubjectInfo()
        {
            lblSubjectID.Text = _subject.SubjectID.ToString();
            txtSubjectName.Text = _subject.SubjectName;
        }

        private void _LoadData()
        {
            _subject = clsSubject.Find(_subjectID);

            if (_subject == null)
            {
                clsStandardMessages.ShowMissingDataMessage("subject", _subjectID);

                this.Close();
                return;
            }

            _FillFieldsWithSubjectInfo();
        }

        private void _FillSubjectObjectWithFieldsData()
        {
            _subject.SubjectName = txtSubjectName.Text.Trim();
        }

        private void _SaveSubject()
        {
            _FillSubjectObjectWithFieldsData();

            if (_subject.Save())
            {
                lblTitle.Text = "Update Subject";
                this.Text = lblTitle.Text;
                lblSubjectID.Text = _subject.SubjectID.ToString();

                // change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("Subject");

                // Trigger the event to send data back to the caller form
                SubjectIDBack?.Invoke(_subject?.SubjectID);
            }
            else
            {
                clsStandardMessages.ShowError("subject");
            }
        }

        private void frmAddEditSubject_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_mode == _enMode.Update)
                _LoadData();
        }

        private void txtSubjectName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSubjectName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSubjectName, null);
            }

            if (_subject.SubjectName.ToLower() != txtSubjectName.Text.ToLower() && clsSubject.Exists(txtSubjectName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSubjectName, "This subject already exists! choose another one.");
            }
            else
            {
                errorProvider1.SetError(txtSubjectName, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                clsStandardMessages.ShowValidationErrorMessage();
                return;
            }

            _SaveSubject();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
