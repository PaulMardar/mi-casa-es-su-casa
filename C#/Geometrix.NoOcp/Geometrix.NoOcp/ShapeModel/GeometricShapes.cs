using System;
using System.Collections.ObjectModel;

namespace iQuest.Geometrix.NoOcp.ShapeModel
{
    internal class GeometricShapes : Collection<object>
    {
        public double CalculateArea()
        {
            double area = 0;

            foreach (object shape in Items)
            {
                switch (shape)
                {
                    case Rectangle rectangle:
                        area += rectangle.Width * rectangle.Height;
                        break;
                    case Circle circle:
                        area += circle.Radius * circle.Radius * Math.PI;
                        break;
                    case Triangle triangle:
                        var semiperimeter = (float)(triangle.Side1 + triangle.Side2 + triangle.Side3) / 2;
                        area += Math.Sqrt(semiperimeter * (semiperimeter - triangle.Side1) * (semiperimeter - triangle.Side2) * (semiperimeter - triangle.Side3));
                        break;
                    default:
                        throw new Exception("Unknown shape.");
                }
            }

            return area;
        }
    }
}