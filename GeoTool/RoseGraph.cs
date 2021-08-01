using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GeoTool
{
    public enum graphType {directional, bidirectional};
    public enum legendType { horizontal, vertical, none };
    public class RoseGraph : Graph
    {
        public double[] groups = new double[36];
        public int angle = 10;
        double max = 0;
        public graphType type = graphType.bidirectional;
        public legendType legendType = legendType.vertical;
        public RoseGraph(int width, int margin) : base(width, margin){ }
        public void SetColor(Color c)
        {
            myBrush = new SolidBrush(c);
        }
        public void DrawRoseGraph(string command)
        {
            DrawGraph();
            DrawGraphsNet();
            LoadAndDisplayData(command);
        }
        void DrawGraphsNet()
        {
            using (Graphics g = Graphics.FromImage(graph))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode =InterpolationMode.High;

                int group = Convert.ToInt32(360/angle);
                double angle2 = 0;
                for (int i = 0; i < group-1; i++)
                {
                    angle2 = Plane.ChangeAsimuthToMatematical(angle + i * angle-90);
                    if (angle2 % 90 != 0)
                    {
                        int x1 = (int)(center.x + radius * Math.Cos(angle2 * Math.PI / 180));
                        int y1 = (int)(center.y + radius * Math.Sin(angle2 * Math.PI / 180));

                        g.DrawLine(new Pen(Color.Gray, 0.5f), x1, y1, (float)(center.x), (float)(center.y));
                    }
                }
            }
        }
        void LoadAndDisplayData(string command)
        {
            data = LoadData(command);

            if (data.Count > 0)
            {
                for (int i = 0; i < groups.Length; i++)
                { groups[i] = 0; }

                foreach (Measurement p in data)
                {
                    for (int i = 0; i < groups.Length; i++)
                    {
                        if (p.Strike <= (i * angle + angle))
                        {
                            groups[i] += 1;
                            break;
                        }
                    }
                }

                for (int i = 0; i < groups.Length; i++)
                {
                    groups[i] /= data.Count;
                    groups[i] *= 100;
                    if (groups[i] > max)
                        max = groups[i];
                }

                using (Graphics g = Graphics.FromImage(graph))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.High;

                    max = Math.Ceiling(max / 10);
                    for (int i = 10; i < max * 10; i += 10)
                    {
                        g.DrawEllipse(new Pen(Color.Gray, 0.5f), (int)(center.x - (radius / max) * i / 10), (int)(center.y - (radius / max) * i / 10), (int)(2 * (radius / max) * i / 10), (int)(2 * (radius / max) * i / 10));
                    }

                    PointF a = new PointF((float)(center.x), (float)(center.y));
                    PointF b = new PointF(); PointF c = new PointF();

                    for (int i = 0; i < groups.Length; i++)
                    {
                        if (groups[i] > 0)
                        {
                            float r = (float)(groups[i] / 10 * radius / max);
                            double angle1 = ChangeAsimuthToMath(i * angle - 90);

                            if (type == graphType.directional)
                            {
                                b = PointFromCircle(angle1, r);
                                c = PointFromCircle(angle1 + angle, r);
                                Draw(new PointF[] { a, b, c }, g);
                            }
                            if (type == graphType.bidirectional)
                            {
                                angle1 = ChangeAsimuthToMath(angle1 - 90);
                                double angle2 = ChangeAsimuthToMath(i * angle);

                                b = PointFromCircle(angle1, r);
                                c = PointFromCircle(angle1 + angle, r);                               
                                Draw(new PointF[] { a, b, c }, g);

                                b = PointFromCircle(angle2, r);
                                c = PointFromCircle(angle2 + angle, r);
                                Draw(new PointF[] { a, b, c }, g);
                            }
                        }
                    }
                }
                if (legendType != legendType.none)
                    DrawLegend();
            }
        }
        double ChangeAsimuthToMath(double asimuth)
        {
            if (asimuth < 0)
                asimuth = 360 + asimuth;
            else if (asimuth > 360)
                asimuth = asimuth - 360;
            return asimuth;
        }
        PointF PointFromCircle(double angle, float r)
        {
            return new PointF((float)(center.x + r * Math.Cos(angle * Math.PI / 180)), (float)(center.y + r * Math.Sin(angle * Math.PI / 180)));
        }
        void Draw(PointF[] points, Graphics g)
        {
            g.DrawPolygon(new Pen(myBrush.Color, 1), points);
            g.FillPolygon(myBrush, points);
        }
        public void DrawLegend()
        {
            using (Graphics g = Graphics.FromImage(graph))
            {            
                int length = width / 2 - margin;
                int size = Convert.ToInt32(length / max / 4);
                if (size > 12)
                    size = 12;
                
                Font font = new Font(FontFamily.GenericSansSerif, size, FontStyle.Bold);
                float x, y;

                for (int i = 0; i <= max; i++)
                {
                    if (legendType == legendType.horizontal)
                    {
                        x = (float)(width / 2 - (length / max) * i - 7);
                        y = (float)(center.y + 5);
                    }
                    else
                    {
                        x = (float)(center.x + 5);
                        y = (float)(center.y - (length / max) * i - 5);
                    }

                    if (max > 5 && i % 2 == 0)
                    {
                        font = new Font(FontFamily.GenericSansSerif, size * 2);
                        g.DrawString(i * 10 + "%", font, Brushes.Black, x, y);
                    }
                    else if (max <= 5)
                        g.DrawString(i * 10 + "%", font, Brushes.Black, x, y);
                }
            }
        }                               
    }
}
