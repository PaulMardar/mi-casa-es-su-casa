namespace iQuest.Geometrix.WithOcp.ShapeModel
{
    internal class Rectangle : IShape
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }
}