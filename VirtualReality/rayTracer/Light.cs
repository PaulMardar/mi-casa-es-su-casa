namespace rt
{
    public class Light
    {
        public Vector Position { get; set; }
        public CustomRGBColor Ambient { get; set; }
        public CustomRGBColor Diffuse { get; set; }
        public CustomRGBColor Specular { get; set; }
        public double Intensity { get; set; }

        public Light(Vector position, CustomRGBColor ambient, CustomRGBColor diffuse, CustomRGBColor specular, double intensity)
        {
            Position = new Vector(position);
            Ambient = new CustomRGBColor(ambient);
            Diffuse = new CustomRGBColor(diffuse);
            Specular = new CustomRGBColor(specular);
            Intensity = intensity;
        }
    }
}