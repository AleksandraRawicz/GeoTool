using System;
using System.Windows.Forms;
using System.Data;

namespace GeoTool
{
    public partial class MeasurementsPanel : Form
    {
        DataSet measurements;
        public MeasurementsPanel()
        {
            InitializeComponent();

            LoadDataList();
        }

        private void LoadDataList()
        {
            measurements = SQLiteAccess.LoadData();
            dataGridView1.DataSource = measurements.Tables[0];
            dataGridView1.ScrollBars = ScrollBars.Both;
        }     
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value.ToString());
            SQLiteAccess.DeleteData(id);
            LoadDataList();
        }
    }
}
