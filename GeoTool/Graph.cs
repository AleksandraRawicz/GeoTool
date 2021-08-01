using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GeoTool
{
    public abstract class Graph
    {
        public int width;
        public int margin;
        public float radius;
        public Bitmap graph;
        public Point center;
        public Pen myPen = new Pen(Color.Black, 1);
        public Font myFont = new Font(FontFamily.GenericSansSerif, 10);
        public SolidBrush myBrush = new SolidBrush(Color.RoyalBlue);
        public List<Measurement> data;

        public Graph(int width, int margin)
        {
            this.width = width;
            this.margin = margin;
            graph = new Bitmap(width, width);
            center = new Point(width / 2, width / 2);
            radius = width / 2 - margin;
        }
        public virtual void ChangeParameters(int width)
        {
            this.width = width;
            radius = width / 2 - margin;
            graph = new Bitmap(width, width);
            center = new Point(width / 2, width / 2);
        }
        public List<Measurement> LoadData(string command)
        {
            data = SQLiteAccess.LoadList(command);
            return data;
        }
        public virtual void DrawGraph()
        {
            using (Graphics g = Graphics.FromImage(graph))
            {
                g.SmoothingMode =  SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.High;

                g.Clear(Color.White);
                g.DrawEllipse(myPen, margin, margin, width - 2 * margin, width - 2 * margin);
                g.DrawLine(myPen, (float)(center.x), (float)(margin), (float)(center.x), (float)(width - margin));
                g.DrawLine(myPen, (float)(margin), (float)(center.y), (float)(width - margin), (float)(center.y));

                g.DrawString("N", myFont, Brushes.Black, width / 2 - 5, 20);
                g.DrawString("S", myFont, Brushes.Black, width / 2 - 5, width - margin + 3);
                g.DrawString("W", myFont, Brushes.Black, 20, width / 2 - 5);
                g.DrawString("E", myFont, Brushes.Black, width - margin + 3, width / 2 - 5);
            }
        }
    }
}
