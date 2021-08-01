
using System.Collections.Generic;


namespace GeoTool
{
    public class Side
    {
        public Vertex a;
        public Vertex b;


        public Point characteristic;

        public Side(Vertex a, Vertex b)
        {
            this.a = a;
            this.b = b;
            
        }
    }
}
