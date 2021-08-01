using System;


namespace GeoTool
{
    public class Vertex
    {
        public Point point;
        public Double value;

        public Vertex(Point point, double value)
        {
            this.point = point;
            this.value = value;
        }
    }
}
