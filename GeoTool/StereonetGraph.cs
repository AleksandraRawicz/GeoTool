using System.Drawing;
using System.Collections.Generic;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GeoTool
{
    public class StereonetGraph:Graph
    {
        public float radius_div9;
        public Pen myColourPen = new Pen(Color.RoyalBlue, 2);        
        public List<Plane> planes = new List<Plane>();
        public List<Line> lines = new List<Line>();
        public Line myLine;
        public Plane myPlane;
        public int netDiv = 10;
        public Bitmap currentGraph;
        public StereonetGraph(int width, int margin) : base(width, margin)
        {            
            radius_div9 = radius / 9;
            currentGraph = new Bitmap(width, width);
        }
        public override void ChangeParameters(int width)
        {
            base.ChangeParameters(width);
            radius_div9 = radius / 9;
            currentGraph = new Bitmap(width, width);
        }
        public Color MyPen
        {
            get { return myColourPen.Color; }
            set { myColourPen.Color = value; myBrush.Color = value; }
        }
        public void DrawShmidtNet()
        {
            using (Graphics g = Graphics.FromImage(graph))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.High;

                Pen thickPen = new Pen(Color.DarkGray,0.5f);                
                Pen thinPen = new Pen(Color.LightGray,0.1f);
                                
                int counter = 9 * 10 / netDiv - 1;
                float arcWidth = width - 2 * margin;
                float arcSpace = radius_div9 * netDiv/10;
                for (int i = 0; i < counter; i++)
                {
                    if(netDiv == 2 && (i + 1) % 5 == 0)
                        g.DrawArc(thickPen, margin + (1 + i) * arcSpace, margin, arcWidth - (i * 2 + 2) * arcSpace, arcWidth, 0, 360);
                    else
                        g.DrawArc(thinPen, margin + (1 + i) * arcSpace, margin, arcWidth - (i * 2 + 2) * arcSpace, arcWidth, 0, 360);
                }

                double h1 = center.y - arcSpace;
                double h2 = center.y + arcSpace;
                Point p = new Point(0,0); Point p2 = new Point(0, 0);

                for (int i = 0; i < counter; i++)
                {
                    p = PointFromCircle(center.x, center.y, radius, 180 - netDiv * (i + 1));
                    p2 = PointFromCircle(center.x, center.y, radius, netDiv * (i + 1)); 
                    if(netDiv == 2 && (i + 1) % 5 == 0)
                        g.DrawArc(thickPen, (float)(p.x), (float)(h1 - 2 * (p.y - h2)), (float)(p2.x - p.x), (float)((p.y - h2) * 2), 0, 180);
                    else
                        g.DrawArc(thinPen, (float)(p.x), (float)(h1 - 2 * (p.y - h2)), (float)(p2.x - p.x), (float)((p.y - h2) * 2), 0, 180);
                    h1 -= arcSpace; h2 += arcSpace;
                }

                h1 = center.y + arcSpace;
                h2 = center.y - arcSpace;

                for (int i = 0; i < counter; i++)
                {
                    p = PointFromCircle(center.x, center.y, radius, 180 + netDiv * (i + 1));
                    p2 = PointFromCircle(center.x, center.y, radius, 360 - netDiv * (i + 1));
                    if (netDiv == 2 && (i + 1) % 5 == 0)
                        g.DrawArc(thickPen, (float)(p.x), (float)(h1), (float)(p2.x - p.x), (float)((h2 - p.y) * 2), 180, 180);
                    else
                        g.DrawArc(thinPen, (float)(p.x), (float)(h1), (float)(p2.x - p.x), (float)((h2 - p.y) * 2), 180, 180);
                    h1 += arcSpace; h2 -= arcSpace;
                }
                g.DrawEllipse(myPen, margin, margin, width - 2 * margin, width - 2 * margin);
            }
            currentGraph = new Bitmap(graph);

            foreach (Plane p in planes)
            {
                DrawPlane(p);
            }
            foreach (Line l in lines)
            {
                DrawLine(l);
            }
            graph = new Bitmap(currentGraph);
        }
        public void DrawLine(Line line)
        {
            double r = (90 - line.dip) / 90 * radius;
            Point p = PointFromCircle(center.x, center.y, r, 360 - ChangeAngle(line.dipDirection));

            using (Graphics g = Graphics.FromImage(currentGraph))
            {
                g.FillEllipse(new SolidBrush(line.color), (float)(p.x - 2), (float)(p.y - 2), 4, 4);
            }
        }
        public void DrawPlane(Plane plane)
        {
            double p1, p2, dip, azymut;
            dip = radius_div9 * (90 - plane.dip) / 10;
            p1 = ChangeAngle(plane.a);
            p2 = ChangeAngle(plane.b);
            azymut = ChangeAngle(plane.dipDirection);

            Point a = PointFromCircle(center.x, center.y, radius, (360 - p1));
            Point b = PointFromCircle(center.x, center.y, radius, (360 - p2));
            Point c = PointFromCircle(center.x, center.y, dip, (360 - azymut));

            double alfa = 0, beta = 0;

            double lenAB = SectionLen(a.x, a.y, b.x, b.y);
            double lenBC = SectionLen(c.x, c.y, b.x, b.y);
            double lenCA = SectionLen(a.x, a.y, c.x, c.y);

            double R = 1 / (4 * TriangleArea(lenAB, lenBC, lenCA)) * lenAB * lenBC * lenCA;

            Point vectorCS = new Point(center.x - c.x, center.y - c.y);
            double vectorLen = Math.Sqrt(vectorCS.x * vectorCS.x + vectorCS.y * vectorCS.y);
            vectorCS.x /= vectorLen;
            vectorCS.y /= vectorLen;
            Point S = new Point(R * vectorCS.x + c.x, R* vectorCS.y + c.y);            

            if (dip == 0)
            {
                using (Graphics g = Graphics.FromImage(currentGraph))
                {g.DrawLine(myColourPen, (float)(a.x), (float)(a.y), (float)(b.x), (float)(b.y));}
                return;
            }
            else
            {
                alfa = FindAngle(a, R, S.x, S.y);
                beta = FindAngle(b, R, S.x, S.y);

                if (alfa < beta && (beta - alfa) <= 180)
                    Arc(S.x, S.y, R, alfa, (beta - alfa), plane.color);
                else if (beta < alfa && (alfa - beta) <= 180)
                    Arc(S.x, S.y, R, beta, (alfa - beta), plane.color);
                else
                {
                    if (alfa < beta)
                    {
                        Arc(S.x, S.y, R, 0, alfa, plane.color);
                        Arc(S.x, S.y, R, beta, 360 - beta, plane.color);
                    }
                    else
                    {
                        Arc(S.x, S.y, R, 0, beta, plane.color);
                        Arc(S.x, S.y, R, alfa, (360 - alfa), plane.color);
                    }
                }
            }}
        void Arc(double SX, double SY, double R, double alfa, double beta, Color c)
        {
            using (Graphics g = Graphics.FromImage(currentGraph))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.High;
                g.DrawArc(new Pen(c,myColourPen.Width), (float)(SX - R), (float)(SY - R), (float)(2 * R), (float)(2 * R), (float)(alfa), (float)(beta));
            }            
        }
        public static double SectionLen(double x1, double y1, double x2, double y2)
        {
            double len = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return len;
        }
        double TriangleArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double pole = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return pole;
        }
        public static double FindAngle(Point a, double R, double newSX, double newSY)
        {
            double theta = (Math.Atan2(a.y - newSY, a.x - newSX)) * 180 / Math.PI;
            if (theta < 0)
                theta = 360+theta;
            return theta;
        }
        Point PointFromCircle(double Sx, double Sy, double R, double angle)
        {
            Point P = new Point(Sx + R * Math.Cos(angle * Math.PI / 180), Sy + R * Math.Sin(angle * Math.PI / 180));
            return P;
        }
        public double ChangeAngle(double angle)
        {
            if (angle < 90)
                angle = 90 - angle;
            else
                angle = 360 + 90 - angle;
            return angle;
        }
    }
}
