using System.Drawing;

namespace GeoTool
{
    public class Line
    {
        public double dipDirection;
        public double dip;

        public Color color=Color.RoyalBlue;
        public Line(double dipDirection, double dip, Color c)
        {
            this.dipDirection = dipDirection;
            this.dip = dip;
            this.color = c;
        }
    }
}
