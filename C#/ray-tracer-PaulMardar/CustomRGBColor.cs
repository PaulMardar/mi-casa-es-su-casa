using System;

namespace rt
{
    public class CustomRGBColor
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }
        public double Alpha { get; set; }

        public CustomRGBColor()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            Alpha = 0;
        }

        public CustomRGBColor(double red, double green, double blue, double alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public CustomRGBColor(CustomRGBColor c)
        {
            Red = c.Red;
            Green = c.Green;
            Blue = c.Blue;
            Alpha = c.Alpha;
        }

        public System.Drawing.Color ToSystemColor()
        {
            var r = Math.Min((int)Math.Ceiling(Red * 255), 255);
            var g = Math.Min((int)Math.Ceiling(Green * 255), 255);
            var b = Math.Min((int)Math.Ceiling(Blue * 255), 255);
            var a = Math.Min((int)Math.Ceiling(Alpha * 255), 255);

            return System.Drawing.Color.FromArgb(a, r, g, b);
        }

        public static CustomRGBColor operator +(CustomRGBColor a, CustomRGBColor b)
        {
            return new CustomRGBColor(a.Red + b.Red, a.Green + b.Green, a.Blue + b.Blue, a.Alpha + b.Alpha);
        }

        public static CustomRGBColor operator -(CustomRGBColor a, CustomRGBColor b)
        {
            return new CustomRGBColor(a.Red - b.Red, a.Green - b.Green, a.Blue - b.Blue, a.Alpha - b.Alpha);
        }

        public static CustomRGBColor operator *(CustomRGBColor a, CustomRGBColor b)
        {
            return new CustomRGBColor(a.Red * b.Red, a.Green * b.Green, a.Blue * b.Blue, a.Alpha * b.Alpha);
        }

        public static CustomRGBColor operator /(CustomRGBColor a, CustomRGBColor b)
        {
            return new CustomRGBColor(a.Red / b.Red, a.Green / b.Green, a.Blue / b.Blue, a.Alpha / b.Alpha);
        }

        public static CustomRGBColor operator *(CustomRGBColor c, double k)
        {
            return new CustomRGBColor(c.Red * k, c.Green * k, c.Blue * k, c.Alpha * k);
        }

        public static CustomRGBColor operator /(CustomRGBColor c, double k)
        {
            return new CustomRGBColor(c.Red / k, c.Green / k, c.Blue / k, c.Alpha / k);
        }
    }
}