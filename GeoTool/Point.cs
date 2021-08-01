
using System;
using System.Drawing;

namespace GeoTool
{
    public class Point
    {
        public double x;
        public double y;
        Color color = Color.Black;
        int contour = 0;
        int idTriangle = 0;

        public Color Color
        { 
            get { return color; }
            set { color = value; }
        }

        public int Contour
        {
            get { return contour; }
            set { contour = value; }
        }
        
        public int IdTriangle
        {
            get { return idTriangle; }
            set { idTriangle = value; }
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static int ComparePointsByContour(Point p1, Point p2)
        {
            return p1.contour.CompareTo(p2.contour);
        }

        public static int ComparePointsByX(Point p1, Point p2)
        {
            return p1.x.CompareTo(p2.x);
        }
    }
}
