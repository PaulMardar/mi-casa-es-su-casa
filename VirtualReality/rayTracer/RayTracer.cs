using System;

namespace rt
{
    class RayTracer
    {
        private Geometry[] geometries;
        private Light[] lights;

        public RayTracer(Geometry[] geometries, Light[] lights)
        {
            this.geometries = geometries;
            this.lights = lights;
        }

        private double ImageToViewPlane(int n, int imgSize, double viewPlaneSize)
        {
            var u = n * viewPlaneSize / imgSize;
            u -= viewPlaneSize / 2;
            return u;
        }

        private Intersection FindFirstIntersection(Line ray, double minDist, double maxDist)
        {
            var intersection = new Intersection();

            foreach (var geometry in geometries)
            {
                var intr = geometry.GetIntersection(ray, minDist, maxDist);

                if (!intr.Valid || !intr.Visible) continue;

                if (!intersection.Valid || !intersection.Visible)
                {
                    intersection = intr;
                }
                else if (intr.T < intersection.T)
                {
                    intersection = intr;
                }
            }

            return intersection;
        }

        private bool IsLit(Vector point, Light light)// ADD CODE HERE: Detect whether the given point has a clear line of sight to the given light
        {
            var distance = Math.Sqrt((light.Position - point) * (light.Position - point)); //meaby + 1 but the modulo is always positive tho 
            var line = new Line(point, light.Position);
            foreach (var g in geometries)
            {
                var intersection = g.GetIntersection(line, 0, distance); // change the 0 . 0 to not make it to show the point itself and meaby the light at some point 


                if (intersection.Visible && intersection.T > 0.001)
                    return false;
            }
            return true; // the tragedy of pelegius the darth when he hit the light
        }

        public void Render(Camera camera, int width, int height, string filename)
        {
            var image = new Image(width, height);
            var background = new CustomRGBColor(); // BONKED LINE!

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var up = camera.Up;
                    var parallel = (up ^ camera.Direction).Normalize();

                    var x0 = camera.Position;
                    var x1 = camera.Position + camera.Direction * camera.ViewPlaneDistance + parallel * ImageToViewPlane(i, width, camera.ViewPlaneWidth) + up * ImageToViewPlane(j, height, camera.ViewPlaneHeight);

                    var ray = new Line(x0, x1);

                    var first_intersection = FindFirstIntersection(ray, camera.FrontPlaneDistance, camera.BackPlaneDistance);



                    if (first_intersection.Valid && first_intersection.Visible)
                    {
                        var material = first_intersection.Geometry.Material;
                        var N = first_intersection.Geometry.Normal(first_intersection.Position);
                        var E = (camera.Position - first_intersection.Position).Normalize();

                        foreach (var l in lights)
                        {
                            var T = (l.Position - first_intersection.Position).Normalize();
                            var R = N * (N * T) * 2 - T;

                            var color = material.Ambient * l.Ambient;

                            if (IsLit(first_intersection.Position, l))
                            {
                                if (N * T > 0)
                                    color += material.Diffuse * l.Diffuse * (N * T);

                                if (E * R > 0)
                                    color += material.Specular * l.Specular * Math.Pow(E * R, material.Shininess);

                                color *= l.Intensity;
                            }

                            background += color;
                        }
                    }
                    else
                        background = new CustomRGBColor(0, 0, 0, 0);

                    image.SetPixel(i, j, background);
                }
            }

            image.Store(filename);
        }
    }
}



//islit meaby
/*
foreach (var g in geometries)
{
    var intersection = g.GetIntersection(line, 0, distance); // change the 0 . 0 to not make it to show the point itself and meaby the light at some point 
    // the tragedy of pelegius the darth when he hit the light

    if (intersection.Visible && intersection.T > e)
        return false;
}
return true; 
*/


/*var e = 0.001; // meaby 10^-5 or -6 ? 
var distance = Math.Sqrt((light.Position - point) * (light.Position - point));
var line = new Line(point, light.Position);
var intersection = FindFirstIntersection(line, 0.001, point.Length()); // or use meaby e ?
return !intersection.Valid;*/