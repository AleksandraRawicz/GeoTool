using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GeoTool
{
    public partial class ContourGraphPanel : Form
    {
        CountourGraph contourGraph;
        public List<Measurement> data = new List<Measurement>();
        public ContourGraphPanel()
        {
            InitializeComponent();
            LoadFilters();
            GraphArea.Width = 440;
            GraphArea.Height = 440;
            legendArea.Height = GraphArea.Height;
            legendArea.Location = new System.Drawing.Point(GraphArea.Location.X + GraphArea.Width, GraphArea.Location.Y);
        }

        public void LoadFilters()
        {
            comboBox1.DataSource = SQLiteAccess.LoadTypes();
            comboBox2.DataSource = SQLiteAccess.LoadAges();
        }
        private void FilterBtn_Click(object sender, EventArgs e)
        {
            contourGraph = new CountourGraph(440, 40);

            string condition1 = "";
            string condition2 = "";
            string command = "select * from Point ";

            if (comboBox1.Text != "")
            {
                condition1 = " Type = '" + comboBox1.Text + "'";
            }
            if (comboBox2.Text != "")
                condition2 = " Age = '" + comboBox2.Text + "'";

            if (condition1 != "" && condition2 != "")
                command += " where " + condition1 + " and " + condition2;
            else if (condition1 != "" || condition2 != "")
                command += " where " + condition1 + condition2;

            data = LoadData(command);

            contourGraph.DrawContourGraph(command);
            GraphArea.Image = contourGraph.graph;
            legendArea.Image = contourGraph.legend;
        }

        private List<Measurement> LoadData(string command)
        {
            List<Measurement> data = SQLiteAccess.LoadList(command);
            return data;
        }
   
    }
}
