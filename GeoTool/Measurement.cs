using System;

namespace GeoTool
{
    public class Measurement
    {
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;
        public int Strike { get; set; }
        public int Dip { get; set; }
        public string Type { get; set; }
        public string Age { get; set; }

        public Measurement()
        { }

        public Measurement(double x, double y, int strike, int dip, string structure, string age)
        {
            this.Age = age;
            this.Latitude = (x);
            this.Longitude = (y);
            this.Strike = strike;
            this.Dip = dip;
            this.Type = structure;
        }
    }
}
