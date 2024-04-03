using StudyCenter.GlobalClasses;
using StudyCenter_Business;
using System.Windows.Forms;

namespace StudyCenter.Classes.UserControls
{
    public partial class ucClassCard : UserControl
    {
        private int? _classID = null;
        private clsClass _class = null;

        public int? ClassID => _classID;
        public clsClass Class => _class;

        public ucClassCard()
        {
            InitializeComponent();
        }

        private void _FillStudentData()
        {
            lblClassID.Text = _class.ClassID.ToString();
            lblClassName.Text = _class.ClassName;
            lblCapacity.Text = _class.Capacity.ToString();

            lblDescription.Text = (string.IsNullOrWhiteSpace(_class.Description))
                                       ? "N/A" : _class.Description;

        }

        public void Reset()
        {
            _classID = null;
            _class = null;

            lblClassID.Text = "[????]";
            lblClassName.Text = "[????]";
            lblCapacity.Text = "[????]";
            lblDescription.Text = "[????]";
        }

        public void LoadClassInfo(int? classID)
        {
            _classID = classID;

            if (!_classID.HasValue)
            {
                clsStandardMessages.ShowMissingDataMessage("class", _classID);

                Reset();

                return;
            }

            _class = clsClass.Find(_classID);

            if (_class == null)
            {
                clsStandardMessages.ShowMissingDataMessage("class", _classID);

                Reset();

                return;
            }

            _FillStudentData();
        }
    }
}
