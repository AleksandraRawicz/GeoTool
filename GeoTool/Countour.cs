using System.Collections.Generic;
using System.Drawing;

namespace GeoTool
{
    public class Countour
    {
        public List<Point> points;
        public int value;
        public List<Polygon> polygons;
        Color color = Color.White;

        public Color Col
        {
            get { return color; }
            set { color = value; }
        }

        public Countour(int value)
        {
            points = new List<Point>();
            this.value = value;
            this.polygons = new List<Polygon>();
        }
    }
}
