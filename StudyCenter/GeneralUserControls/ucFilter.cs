using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudyCenterUI.GeneralUserControls
{
    public partial class ucFilter : UserControl
    {
        #region Declare OnFindClick Event
        public class FindNumericClickEventArgs : EventArgs
        {
            public int Value { get; }
            public string FieldName { get; }

            public FindNumericClickEventArgs(int value, string fieldName)
            {
                Value = value;
                FieldName = fieldName;
            }
        }

        public class FindStringClickEventArgs : EventArgs
        {
            public string Value { get; }
            public string FieldName { get; }

            public FindStringClickEventArgs(string value, string fieldName)
            {
                Value = value;
                FieldName = fieldName;
            }
        }

        public event EventHandler<FindNumericClickEventArgs> OnFindNumericClick;

        public event EventHandler<FindStringClickEventArgs> OnFindStringClick;

        public void RaiseOnFindClick<T>(T value, string fieldName)
        {
            switch (value)
            {
                case int intValue:
                    OnFindNumericClick?.Invoke(this, new FindNumericClickEventArgs(intValue, fieldName));
                    break;
                case string stringValue:
                    OnFindStringClick?.Invoke(this, new FindStringClickEventArgs(stringValue, fieldName));
                    break;
                default:
                    throw new ArgumentException("Unsupported type for RaiseOnFindClick");
            }
        }
        #endregion

        #region Declare OnAddClick Event        
        public event EventHandler OnAddClick;

        public void RaiseAddClick()
        {
            OnAddClick?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        private readonly Dictionary<string, bool> _filters = new Dictionary<string, bool>();

        private bool _showAddPersonButton = true;
        public bool ShowAddPersonButton
        {
            get => _showAddPersonButton;
            set => btnAdd.Visible = _showAddPersonButton = value;
        }

        private bool _filterEnable = true;
        public bool FilterEnabled
        {
            get => _filterEnable;
            set => gbFilter.Enabled = _filterEnable = value;
        }

        public string TextSearch
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public ucFilter()
        {
            InitializeComponent();
        }

        public void ItemsInComboBox((string name, bool isNumeric)[] items)
        {
            if (items == null || items.Length == 0)
                return;

            foreach (var (name, isNumeric) in items)
            {
                cbFindBy.Items.Add(name);
                _filters.Add(name, isNumeric);
            }

            if (cbFindBy.Items.Count > 0)
                cbFindBy.SelectedIndex = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields contain invalid data. Please correct the errors indicated by the red icons.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                string.IsNullOrWhiteSpace(cbFindBy.Text))
                return;

            if (_filters.TryGetValue(cbFindBy.Text, out bool isNumeric))
            {
                if (isNumeric)
                {
                    if (int.TryParse(txtSearch.Text, out int value))
                        RaiseOnFindClick(value, cbFindBy.Text);
                }
                else
                    RaiseOnFindClick(txtSearch.Text, cbFindBy.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddClick?.Invoke(sender, e);
        }

        public void FilterFocus() => txtSearch.Focus();

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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();

            if (_filters.TryGetValue(cbFindBy.Text, out bool isNumeric))
                e.Handled = isNumeric && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }
    }
}
