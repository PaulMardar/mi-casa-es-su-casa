namespace rt
{
    public abstract class Geometry
    {
        public CustomRGBColor Color { get; set; }
        public Material Material { get; set; }

        public Geometry(Material material, CustomRGBColor color)
        {
            Material = material;
            Color = color;
        }

        public abstract Intersection GetIntersection(Line line, double minDist, double maxDist);

        public abstract Vector Normal(Vector v);
    }
}