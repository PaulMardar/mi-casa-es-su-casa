using System;
using iQuest.TheUniverse.Application.AddStar;

namespace iQuest.TheUniverse.Presentation
{
    internal class StarDetailsProvider : IStarDetailsProvider
    {
        private const string DefaultGalaxyName = "Milky Way";

        public string GetGalaxyName()
        {
            Console.WriteLine();
            Console.Write("Galaxy name (" + DefaultGalaxyName + "): ");
            string galaxyName = Console.ReadLine();

            return string.IsNullOrWhiteSpace(galaxyName)
                ? DefaultGalaxyName
                : galaxyName;
        }

        public string GetStarName()
        {
            string starName;
            do
            {
                Console.WriteLine();
                Console.Write("Star name: ");
                starName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(starName));

            return starName;
        }
    }
}