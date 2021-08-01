using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GeoTool
{
    class CountourGraph : StereonetGraph
    {
        int[,] points = new int[31, 31];
        List<Point> elements;
        float r10;
        List<Triangle> triangles;
        List<Countour> contours;
        Countour current;
        double max = 0;
        List<Color> colors = new List<Color> { Color.FromArgb(44, 3, 252), Color.FromArgb(87, 76, 245), Color.FromArgb(92, 168, 219), Color.FromArgb(92, 206, 219), Color.FromArgb(24, 241, 229), Color.FromArgb(73, 240, 150), Color.FromArgb(39, 241, 98), Color.FromArgb(34, 255, 0), Color.FromArgb(132, 255, 71), Color.FromArgb(198, 255, 24), Color.FromArgb(255, 229, 44), Color.FromArgb(255, 188, 0), Color.FromArgb(255, 118, 4), Color.FromArgb(252, 68, 15), Color.FromArgb(255, 21, 21), Color.FromArgb(180, 14, 14) };
        public Bitmap legend;
        public CountourGraph(int width, int margin) : base(width, margin)
        {
            this.r10 = radius / 10;
            this.triangles = new List<Triangle>();
            this.contours = new List<Countour>();
            legend = new Bitmap(50, width);
        }
        public void DrawContourGraph(string command)
        {
            DrawGraph();
            LoadDataToGraph(command);
            FillTable();
            SetTriangles();

            double rel = max / colors.Count;
            if (rel <= 1)
            {
                for (int i = 1; i < max; i++)
                {
                    Color color = colors[i];
                    SetCharacteristics(i, color);
                }
            }
            else
            {
                int j = Convert.ToInt32(Math.Ceiling(rel));
                int cnt = 0;
                for (int i = 1; i < max; i++)
                {
                    if (i % j == 0)
                    {
                        Color color = colors[cnt];
                        SetCharacteristics(i, color);
                        cnt++;
                    }
                }
            }

            using (Graphics g = Graphics.FromImage(graph))
            {
                g.FillEllipse(new SolidBrush(colors[0]), margin, margin, width - 2 * margin, width - 2 * margin);
            }

            SetPolygons(1);
            ConnectPoints();
            Legend();
        }
        void Legend()
        {
            using (Graphics g = Graphics.FromImage(legend))
            {
                g.Clear(Color.White);

                float start = width - 50;
                g.DrawRectangle(new Pen(Brushes.Black), 5, start - 1 - width / 2, 10, width / 2);
                double rel = Math.Ceiling(max / colors.Count);
                int[] tab = new int[colors.Count];
                int cnt = 0;

                for (int i = 0; i < max; i++)
                {
                    if (i % rel == 0)
                    {
                        tab[cnt] = i;
                        cnt++;
                    }
                }
                float len = width / (2f * cnt);

                for (int i = 0; i < cnt; i++)
                {
                    g.FillRectangle(new SolidBrush(colors[i]), 6, start - (i + 1) * len, 9, len);
                    //if (i % 2 == 0)
                        g.DrawString(Math.Round((double)(tab[i] / (float)(elements.Count) * 100f)) + " %", new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, 15, start - (i) * len);
                }
            }

            DrawShmidtNet();
            using (Graphics g = Graphics.FromImage(graph))
            {
                g.DrawLine(new Pen(Color.LightGray), (float)(center.x), (float)(margin), (float)(center.x), (float)(width - margin));
                g.DrawLine(new Pen(Color.LightGray), (float)(margin), (float)(center.y), (float)(width - margin), (float)(center.y));
            }

        }
        void LoadDataToGraph(string command)
        {
            data = LoadData(command);
            elements = new List<Point>();
            foreach (var d in data)
            {
                double r = (90 - d.Dip);
                r *= radius/90;
                Point p = PointFromCircle(center.x, center.y, r, 360 - ChangeAngle(d.Strike));
                elements.Add(p);
            }
        }
        Point PointFromCircle(double Sx, double Sy, double R, double angle)
        {
            Point P = new Point(Sx + R * Math.Cos(angle * Math.PI / 180), Sy + R * Math.Sin(angle * Math.PI / 180));
            return P;
        }
        void FillTable()
        {
            Point currentPoint = new Point(margin, margin);
            int z = points.GetLength(1);
            float step = r10 * 2 / 3f;
            for (int i = 0; i < z; i++)
            {
                currentPoint.x = margin;
                for (int j = 0; j < z; j++)
                {
                    points[i, j] = CountPoints(currentPoint);

                    double cond = SectionLen(center.x, center.y, currentPoint.x, currentPoint.y);
                    if (cond > step * 14.5 && cond < step * 15.5)
                    {
                        int ile = CountPoints(new Point(center.x + (15 - j) * step, center.y + (15 - i) * step));
                        if (CountPoints(new Point(center.x + (15 - j) * step, center.y + (15 - i) * step)) > 0)
                        {
                            points[i, j] = points[i, j] + ile;     
                        }
                    }

                    if (points[i, j] > max)
                        max = points[i, j];

                    currentPoint.x += step;
                }
                currentPoint.y += step;
            }
        }
        void SetTriangles()
        {
            int z = points.GetLength(1);
            int idCounter = 0;
            for (int i = 0; i < z-1; i++)
            {
                for (int j = 0; j < z-1; j++)
                {                   
                    Vertex v1 = new Vertex(new Point(margin+j*r10 * 2 / 3f, margin+i*r10 * 2 / 3f),points[i,j]);
                    Vertex v2 = new Vertex(new Point(margin + (j+1) * r10 * 2 / 3f, margin + i * r10 * 2 / 3f), points[i, j+1]);
                    Vertex v3 = new Vertex(new Point(margin + (j+1) * r10 * 2 / 3f, margin + (i+1)* r10 * 2 / 3f), points[i+1, j+1]);
                    Triangle tri = new Triangle(v1,v2, v3, idCounter);

                    triangles.Add(tri);
                    idCounter++;

                    Vertex v1_ = new Vertex(new Point(margin + j * r10 * 2 / 3f, margin + i * r10 * 2 / 3f), points[i, j]);
                    Vertex v2_ = new Vertex(new Point(margin + (j + 1) * r10 * 2 / 3f, margin + (i+1) * r10 * 2 / 3f), points[i + 1, j+1]);
                    Vertex v3_ = new Vertex(new Point(margin + j * r10 * 2 / 3f, margin + (i + 1) * r10 * 2 / 3f), points[i+1, j]);
                    Triangle tri_ = new Triangle(v1_, v2_, v3_, idCounter);

                    triangles.Add(tri_);
                    idCounter++;
                }
            }
        }
        int CountPoints(Point p)
        {
            int counts = 0;
            foreach (var e in elements)
            {
                if (((e.x - p.x) * (e.x - p.x) + (e.y - p.y) * (e.y - p.y)) <= r10 * r10)
                {
                    counts++;
                }
            }
            return counts;
        }
        bool InsideCircle(Point p)
        {
            return ((p.x - center.x) * (p.x - center.x) + (p.y - center.y) * (p.y - center.y)) <= radius * radius;
        }
        void SetCharacteristics(int c, Color color)
        {
            current = new Countour(c);
            current.Col = color;
            foreach(var t in triangles)
            {
                Condition(t,t.s1, c, color);
                Condition(t,t.s2, c, color);
                Condition(t,t.s3, c, color);
            }
            contours.Add(current);
        }
        void Condition(Triangle t, Side s, int c, Color color)
        {           
            double condition = (s.a.value - c) * (s.b.value - c);
                      
            if (condition < 0)
            {
                Point p = LinearInterpolation(s.a, s.b, c);
                p.Color = color;
                p.Contour = c;
                p.IdTriangle = t.id;

                if (!InsideCircle(p))
                    p = ProjectOnCircle(p);

                s.characteristic = p;
                t.characteristics.Add(s.characteristic);
                current.points.Add(p);
            }
            else if (condition == 0)
            {
                if (s.a.value - c == 0)
                {
                    s.a.value -= 0.5;
                }
                if (s.b.value - c == 0)
                {
                    s.b.value -= 0.5;
                }
                Condition(t, s, c, color);
            }
        }
        Point LinearInterpolation(Vertex a, Vertex b, double c)
        {
            double xc = Math.Round( b.point.x + (a.point.x - b.point.x) / (a.value - b.value) * (c-b.value),4);
            double yc = Math.Round( b.point.y + (a.point.y - b.point.y) / (a.value - b.value) * (c-b.value),4);
            return new Point(xc,yc);
        }       
        void SetPolygons(int c)
        {
            foreach (var contour in contours)
            {
                    if (contour.points.Count > 0)
                    {
                        Point start = contour.points[0];
                        Polygon polygon = new Polygon();
                        polygon.verticies.Add(start);
                        contour.points.Remove(start);
                        bool go = true;
                        int cnt = 1;

                        while (go)
                        {
                            Point next = triangles[start.IdTriangle].characteristics.Find(p => (p.Contour == start.Contour && (p.x != start.x || p.y != start.y)));

                            if (next.x == polygon.verticies[0].x && next.y == polygon.verticies[0].y)
                            {
                                contour.points.Remove(next);
                                contour.polygons.Add(polygon);
                                polygon = new Polygon();
                                if (contour.points.Count != 0)
                                {
                                    start = contour.points[0];
                                    polygon.verticies.Add(start); cnt++;
                                    contour.points.Remove(start);
                                }
                                else
                                {
                                    go = false;
                                }
                            }
                            else
                            {
                                polygon.verticies.Add(next);
                                contour.points.Remove(next);
                                cnt++;
                                start = contour.points.Find(p => (p.IdTriangle != next.IdTriangle && (p.x == next.x && p.y == next.y)));
                                contour.points.Remove(start);
                            }
                        }
                    }                
            }
        }
        void ConnectPoints()
        {
            SolidBrush brush = new SolidBrush(Color.Red);

            foreach (var c in contours)
            {
                brush.Color = c.Col;
                foreach(var p in c.polygons)
                {
                    SmoothPolygon(p);
                    SmoothPolygon(p);
                    SmoothPolygon(p);
              
                    using (Graphics g = Graphics.FromImage(graph))
                    {
                       ColourPolygon(p,c.Col);  
                    }
                }
            }
        }
        bool CheckIfLineOnYIntersectsSide(Point a, Point b, double y)
        {
            if ((y > b.y && y <= a.y) && (b.y<=a.y))
                return true;
            else if ((y <= b.y && y > a.y) && (a.y <= b.y))
                return true;
            else
                return false;
        }
        Point PointOnLine(Point p1, Point p2, double y)
        {
            double a, b, c;
            a = (p2.y - p1.y);
            b = (p1.x - p2.x);
            c = a * p1.x + b * p1.y;

            if (a != 0)
            {
                if (b == 0)
                    return new Point(p1.x,y);
                double x = (c - b * y) / a;
                return new Point(x, y);
            }
            else
            {
                if (p1.x < p2.x)
                    return new Point(p1.x, y);
                else
                    return new Point(p2.x, y);
            }
        }
        void ColourPolygon(Polygon p, Color color)
        {
            double miny =p.verticies[0].y, maxy = p.verticies[0].y;
            for(int i = 0; i < p.verticies.Count; i ++)
            {
                if (miny > p.verticies[i].y)
                    miny = p.verticies[i].y;
                if (maxy < p.verticies[i].y)
                    maxy = p.verticies[i].y;
            }

            for (int j = (int)(miny); j < (int)(maxy); j++)
            {
                List<Point> verts = new List<Point>();
                for (int i = 0; i < p.verticies.Count - 1; i++)
                {
                    if (CheckIfLineOnYIntersectsSide(p.verticies[i], p.verticies[i + 1], j))
                    {
                        verts.Add(PointOnLine(p.verticies[i],p.verticies[i+1],j));                       
                    }
                }
                if (CheckIfLineOnYIntersectsSide(p.verticies[p.verticies.Count-1], p.verticies[0], j))
                {
                    verts.Add(PointOnLine(p.verticies[p.verticies.Count-1], p.verticies[0], j));
                }

                verts.Sort((Point p1, Point p2) => p1.x.CompareTo(p2.x));
                               
                for (int i = 0; i < verts.Count - 1; i += 2)
                {
                    using (Graphics g = Graphics.FromImage(graph))
                    {
                        g.DrawLine(new Pen(color), (float)(verts[i].x), (float)(verts[i].y), (float)(verts[i + 1].x), (float)(verts[i + 1].y));
                    }
                }
            }
        }
        void SmoothPolygon(Polygon p)
        {
            List<Point> verticies2 = new List<Point>();

            for(int i=0; i<p.verticies.Count-1;i++)
            {
                verticies2 = AddMidVerticies(p.verticies[i], p.verticies[i + 1], verticies2);              
            }
            verticies2 = AddMidVerticies(p.verticies[p.verticies.Count-1], p.verticies[0], verticies2);
            p.verticies.Clear();
            p.verticies = verticies2;
        }
        private List<Point> AddMidVerticies(Point a, Point b, List<Point> verticies2)
        {
            verticies2.Add(new Point(3/4f*a.x + 1/4f*b.x, 3/4f * a.y + 1 / 4f * b.y));
            verticies2.Add(new Point(3/4f*b.x + 1/4f*a.x, 3/4f * b.y + 1 / 4f * a.y));
            return verticies2;
        }
        private Point ProjectOnCircle(Point p)
        {
            double theta = Math.Atan2(p.y-center.y, p.x - center.x);

            p.x = center.x + radius * Math.Cos(theta);
            p.y = center.y + radius * Math.Sin(theta);
            return p;
        }
    }
}
