using System.Windows.Forms;

namespace StudyCenterUI.GeneralUserControls
{
    public partial class ucSubList : UserControl
    {
        private int? _value = null;

        public string Title
        {
            get => gbList.Text;
            set => gbList.Text = value;
        }

        public int RowsCount => dgvList.Rows.Count;

        public ucSubList()
        {
            InitializeComponent();
        }

        private void _RefreshAllTeachersTeachSubjectList(object dataSource,
            (string columnName, int width)[] columns = null)
        {
            dgvList.DataSource = dataSource;

            lblNumberOfRecords.Text = dgvList.Rows.Count.ToString();

            if (columns == null || dgvList.Rows.Count == 0)
                return;

            for (int i = 0; i < columns.Length; i++)
            {
                dgvList.Columns[i].HeaderText = columns[i].columnName;
                dgvList.Columns[i].Width = columns[i].width;
            }
        }

        public object GetIDFromDGV(string entityName)
        {
            return dgvList.CurrentRow.Cells[entityName].Value;
        }

        public void LoadInfo(int? value, object dataSource)
        {
            _value = value;

            _RefreshAllTeachersTeachSubjectList(dataSource);
        }

        public void LoadInfo(int? value, object dataSource, (string columnName, int width)[] columns)
        {
            _value = value;

            _RefreshAllTeachersTeachSubjectList(dataSource, columns);
        }

        public void Clear()
        {
            dgvList.DataSource = null;
        }
    }
}
