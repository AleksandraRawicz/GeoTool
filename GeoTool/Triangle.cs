
using System.Collections.Generic;


namespace GeoTool
{
    public class Triangle
    {
        public Vertex a, b, c;
        public Side s1, s2, s3;
        public List<Point> characteristics;
        public int id;

        public Triangle(Vertex a, Vertex b, Vertex c, int id)
        {
            this.id = id;
            this.a = a;
            this.b = b;
            this.c = c;
            s1 = new Side(a, b);
            s2 = new Side(b, c);
            s3 = new Side(c, a);
            this.characteristics = new List<Point>();
        }

    }


}
