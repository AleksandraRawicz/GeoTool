

using System.Drawing;

namespace GeoTool
{
    public class Plane
    {
        public double dipDirection;
        public double dip;

        public double a;
        public double b;

        public Color color = Color.RoyalBlue;

        public Plane(double dir, double dip, Color c)
        {
            dipDirection = dir;
            this.dip = dip;

            a = ChangeAsimuthToMatematical(dipDirection +90);
            b = ChangeAsimuthToMatematical(dipDirection -90);

            if (b<a)
            {
                double help = a;
                a = b;
                b = help;
            }

            this.color = c;
        }

        public static double ChangeAsimuthToMatematical(double asimuth)
        {
            if (asimuth < 0)
                asimuth = 360 + asimuth;
            else if (asimuth > 360)
                asimuth = asimuth - 360;
            return asimuth;
        }

    }
}
