using System;
using System.Windows.Forms;

namespace GeoTool
{
    public partial class RosePanel : Form
    {
        RoseGraph rose = new RoseGraph(440, 40);
        
        string command = "select * from Point";
        public RosePanel()
        {
            InitializeComponent();
            Draw();
            panel5.Hide();
            panel6.Hide();
            LoadFilters();
            SetLegendCBox.Items.Add(legendType.horizontal);
            SetLegendCBox.Items.Add(legendType.vertical);
            SetLegendCBox.Items.Add(legendType.none);
            trackBar1.Value = 400;
        }          
        public void Draw()
        {
            rose.DrawRoseGraph(command);
            graphArea.Image = rose.graph;
        }
        private void ChangeColourBtn_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                rose.SetColor(MyDialog.Color);
                Draw();
            }
        }
        private void FilterPanelBtn_Click(object sender, EventArgs e)
        {
            if (panel5.Visible)
                panel5.Hide();
            else
                panel5.Show();
        }
        public void LoadFilters()
        {
            comboBox1.DataSource = SQLiteAccess.LoadTypes();
            comboBox2.DataSource = SQLiteAccess.LoadAges();
        }
        private void FilterBtn_Click(object sender, EventArgs e)
        {
            string condition1 = "";
            string condition2 = "";
            command = "select * from Point ";

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

            if (DirectRadioBtn.Checked)
                rose.type = graphType.directional;
            else if (BidirectRadioBtn.Checked)
                rose.type = graphType.bidirectional;

            if (comboBox3.SelectedIndex > -1)
            {
                rose.angle = Convert.ToInt32(comboBox3.Text);
                rose.groups = new double[360 / rose.angle];
            }
            Draw();
        }
        private void CustomizePanelBtn_Click(object sender, EventArgs e)
        {
            if (panel6.Visible)
                panel6.Hide();
            else
                panel6.Show();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            rose.ChangeParameters(Convert.ToInt32(trackBar1.Value));
            Draw();
        }
        private void SetLegendCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rose.legendType = (legendType)SetLegendCBox.SelectedItem;
            Draw();
        }
    }
}
