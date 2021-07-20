using System.Collections.ObjectModel;

namespace iQuest.Geometrix.WithOcp.ShapeModel
{
    internal class GeometricShapes : Collection<IShape>
    {
        public double CalculateArea()
        {
            double area = 0;

            foreach (IShape shape in Items)
                area += shape.CalculateArea();

            return area;
        }
    }
}