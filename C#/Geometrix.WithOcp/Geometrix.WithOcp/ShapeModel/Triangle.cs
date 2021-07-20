using System;

namespace iQuest.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public double Side1 { get; set; }

        public double Side2 { get; set; }

        public double Side3 { get; set; }

        public double CalculateArea()
        {
            var semiperimeter = (float)(this.Side1 + this.Side2 + this.Side3) / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - this.Side1) * (semiperimeter - this.Side2) * (semiperimeter - this.Side3));
        }
    }
}
