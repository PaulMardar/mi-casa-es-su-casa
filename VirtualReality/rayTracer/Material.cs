namespace rt
{
    public class Material
    {
        public CustomRGBColor Ambient { get; set; }
        public CustomRGBColor Diffuse { get; set; }
        public CustomRGBColor Specular { get; set; }
        public int Shininess { get; set; }

        public Material(CustomRGBColor ambient, CustomRGBColor diffuse, CustomRGBColor specular, int shininess)
        {
            Ambient = new CustomRGBColor(ambient);
            Diffuse = new CustomRGBColor(diffuse);
            Specular = new CustomRGBColor(specular);
            Shininess = shininess;
        }
    }
}