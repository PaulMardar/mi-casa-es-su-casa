using System;
using iQuest.Geometrix.NoOcp.ShapeModel;

namespace iQuest.Geometrix.NoOcp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                GeometricShapes geometricShapes = new GeometricShapes
                {
                    new Rectangle { Height = 4, Width = 5 },
                    new Circle { Radius = 2 },
                    new Triangle{ Side1=3, Side2=4, Side3=5 }
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
