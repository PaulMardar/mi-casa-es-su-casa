using System;

namespace iQuest.TheUniverse.Presentation
{
    public class ApplicationHeader
    {
        public void Display()
        {
            Console.WriteLine("GenericsExercise");
            Console.WriteLine(new string('=', 79));
            Console.WriteLine();

            DisplayHelp();
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("add-galaxy    - Add a new galaxy to the universe.");
            Console.WriteLine("add-star      - Add a new star to an existing galaxy.");
            Console.WriteLine("display-stars - Show all the stars existing in the current universe.");
            Console.WriteLine("exit          - Exits the application.");
        }
    }
}