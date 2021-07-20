using System;
using iQuest.Geometrix.WithOcp.ShapeModel;

namespace iQuest.Geometrix.WithOcp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                GeometricShapes geometricShapes = new GeometricShapes
                {
                    new Rectangle { Height = 4, Width = 7 },
                    new Circle { Radius = 5 },
                    new Triangle{ Side1=2,Side2=3,Side3=4}
                };

                double area = geometricShapes.CalculateArea();
                Console.WriteLine($"Area: {area}");

                Pause();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        private static void DisplayError(Exception exception)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(exception.ToString());
            Console.ForegroundColor = oldColor;
        }
    }
}