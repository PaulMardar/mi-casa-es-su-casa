using System;

namespace rt
{
    public class Sphere : Geometry
    {
        private Vector Center { get; set; }
        private double Radius { get; set; }

        public Sphere(Vector center, double radius, Material material, CustomRGBColor color) : base(material, color)
        {
            Center = center;
            Radius = radius;
        }

        public override Intersection GetIntersection(Line line, double minDist, double maxDist)
        {
            // ADD CODE HERE: Calculate the intersection between the given line and this sphere
            var o = line.X0;
            var u = line.Dx;

            var a = u * u;
            var b = 2 * (u * (o - this.Center));
            var c = (o - this.Center) * (o - this.Center) - this.Radius * this.Radius;

            var delta = b * b - 4 * a * c;
            bool visibility;
            if (delta < 0)
                return new Intersection();
            else
                if (delta == 0)
            {
                if ((-b) / (2 * a) >= minDist && (-b) / (2 * a) <= maxDist)
                    visibility = true;
                else
                    visibility = false;
                return new Intersection(true, visibility, this, line, (-b) / (2 * a));
            }

            if ((-b - Math.Sqrt(delta)) / (2 * a) >= minDist && (-b - Math.Sqrt(delta)) / (2 * a) <= maxDist)
                return new Intersection(true, true, this, line, (-b - Math.Sqrt(delta)) / (2 * a));
            else
                   if ((-b + Math.Sqrt(delta)) / (2 * a) >= minDist && (-b + Math.Sqrt(delta)) / (2 * a) <= maxDist)
                return new Intersection(true, true, this, line, (-b + Math.Sqrt(delta)) / (2 * a));
            else
                return new Intersection(true, false, this, line, (-b - Math.Sqrt(delta)) / (2 * a));

        }

        public override Vector Normal(Vector v)
        {
            var n = v - Center;
            n.Normalize();
            return n;
        }
    }
}