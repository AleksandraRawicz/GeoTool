using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GeoTool
{
    public partial class StereonetPanel : Form
    {       
        StereonetGraph stereonet;

        public StereonetPanel()
        {
            InitializeComponent();
            GraphArea.Width = 440;
            GraphArea.Height = 440;
            trackBar1.Value = 440;

            stereonet = new StereonetGraph(440, 40);
            stereonet.DrawGraph();
            stereonet.DrawShmidtNet();
            GraphArea.Image = stereonet.currentGraph;
        
            LoadFilters();
            panel5.Hide();
            panel4.Hide();
            panel6.Hide();
        }

        public void LoadFilters()
        {
            comboBox1.DataSource = SQLiteAccess.LoadTypes();
            comboBox2.DataSource = SQLiteAccess.LoadAges();
        }
        public void GetData()
        {
            stereonet.myPlane = new Plane(0,45,Color.Blue);
            if (double.TryParse(textBox1.Text, out stereonet.myPlane.dipDirection) && double.TryParse(textBox2.Text, out stereonet.myPlane.dip))
            {
                if (stereonet.myPlane.dipDirection < 0 || stereonet.myPlane.dipDirection > 360 || stereonet.myPlane.dip <= 0 || stereonet.myPlane.dip > 90)
                {
                    MessageBox.Show("wrong data");
                    return;
                }
                stereonet.myPlane = new Plane(stereonet.myPlane.dipDirection, stereonet.myPlane.dip,stereonet.MyPen);
            }
        }
        private void DrawBtn_Click(object sender, EventArgs e)
        {
            GetData();
            if (radioButton1.Checked)
            {
                stereonet.DrawPlane(stereonet.myPlane);
                stereonet.planes.Add(stereonet.myPlane);
            }
            else if (radioButton2.Checked)
            {
                Line l = new Line(stereonet.myPlane.dipDirection, stereonet.myPlane.dip, stereonet.MyPen);
                stereonet.DrawLine(l);
                stereonet.lines.Add(l);
            }
            stereonet.DrawGraph();
            stereonet.DrawShmidtNet();
            GraphArea.Image = stereonet.currentGraph;
        }        
        private void FilterPanelBtn_Click(object sender, EventArgs e)
        {
            if (panel4.Visible)
                panel4.Hide();
            else
                panel4.Show();
        }
        private void SetData(Object o)
        {
            if (o is Plane)
            {
                foreach (var p in stereonet.data)
                {                   
                    Plane plane = new Plane(p.Strike, p.Dip,stereonet.MyPen);
                    stereonet.DrawPlane(plane);
                    stereonet.planes.Add(plane);
                }
            }
            else if (o is Line)
            {
                foreach (var p in stereonet.data)
                {
                    Line line = new Line(p.Strike, p.Dip, stereonet.MyPen);
                    stereonet.DrawLine(line);
                    stereonet.lines.Add(line);
                }
            }
            GraphArea.Image = stereonet.currentGraph;
        }
        private void GraphArea_MouseMove(object sender, MouseEventArgs e)
        {
            stereonet.currentGraph = new Bitmap(stereonet.graph);

            double r = StereonetGraph.SectionLen(stereonet.center.x, stereonet.center.y, e.X, e.Y);
            if (r <= stereonet.radius)
            {
                if (e.X == stereonet.center.x && e.Y == stereonet.center.y)
                    return;
                double lineDir = Math.Round(StereonetGraph.FindAngle(new Point(e.X, e.Y), r, stereonet.center.x, stereonet.center.y));
                double lineDip = 90 - Math.Round(r / stereonet.radius * 90);
                if (lineDir <= 270)
                    lineDir += 90;
                else
                    lineDir -= 270;

                double planeDir = lineDir;

                if (lineDir <= 180)
                    planeDir = lineDir + 180;
                else
                    planeDir = lineDir - 180;

                stereonet.myLine = new Line(lineDir, lineDip, stereonet.MyPen);
                stereonet.myPlane = new Plane(planeDir, 90 - lineDip, stereonet.MyPen);

                label3.Text = "Line : " + lineDir + " / " + lineDip;
                label4.Text = "Plane : " + stereonet.myPlane.dipDirection + " / " + stereonet.myPlane.dip;
                stereonet.DrawPlane(stereonet.myPlane);
                GraphArea.Image = stereonet.currentGraph;
            }
            else
            {
                label3.Text = "Line : ";
                label4.Text = "Plane : ";
            }
        }        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            stereonet.ChangeParameters(Convert.ToInt32(trackBar1.Value));
            GraphArea.Width = Convert.ToInt32(trackBar1.Value);
            GraphArea.Height = Convert.ToInt32(trackBar1.Value);
            //SetGraphLocation();
            stereonet.DrawGraph();
            stereonet.DrawShmidtNet();
            GraphArea.Image = stereonet.graph;
        }
        private void FilterBtn_Click(object sender, EventArgs e)
        {
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

            stereonet.data = stereonet.LoadData(command);
            
            if (radioButton3.Checked)
                SetData(new Line(45, 45, stereonet.MyPen));
            else if (radioButton4.Checked)
                SetData(new Plane(45, 45, stereonet.MyPen));

            stereonet.DrawGraph();
            stereonet.DrawShmidtNet();
        }
        private void CustomizePanelBtn_Click(object sender, EventArgs e)
        {
            if (panel6.Visible)
                panel6.Hide();
            else
                panel6.Show();
        }
        private void AddPanelBtn_Click(object sender, EventArgs e)
        {
            if (panel5.Visible)
                panel5.Hide();
            else
                panel5.Show();
        }
        private void GraphArea_MouseDown(object sender, MouseEventArgs e)
        {
            double r = StereonetGraph.SectionLen(stereonet.center.x, stereonet.center.y, e.X, e.Y);
            if (r <= stereonet.radius)
            {
                if (e.Button == MouseButtons.Left)
                    stereonet.planes.Add(stereonet.myPlane);
                else if (e.Button == MouseButtons.Right)
                    stereonet.lines.Add(stereonet.myLine);
                stereonet.DrawGraph();
                stereonet.DrawShmidtNet();
                GraphArea.Image = stereonet.currentGraph;
            }
        }
        private void SetColourBtn_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                stereonet.MyPen = MyDialog.Color;
            }
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            stereonet.planes = new List<Plane>();
            stereonet.lines = new List<Line>();
            stereonet.DrawGraph();
            stereonet.DrawShmidtNet();
            GraphArea.Image = stereonet.currentGraph;
        }
        private void SetSettingsBtn_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                stereonet.myColourPen.Width = 2;
            }
            else if(radioButton6.Checked)
            {
                stereonet.myColourPen.Width = 1;
            }

            if (radioButton7.Checked)
            {
                stereonet.netDiv = 10;    
            }
            else if (radioButton8.Checked)
            {
                stereonet.netDiv = 2;
            }

            stereonet.DrawGraph();
            stereonet.DrawShmidtNet();
            GraphArea.Image = stereonet.currentGraph;
        }

        
    }
}
