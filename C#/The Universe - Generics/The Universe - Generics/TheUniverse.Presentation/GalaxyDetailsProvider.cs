using System;
using iQuest.TheUniverse.Application.AddGalaxy;

namespace iQuest.TheUniverse.Presentation
{
    internal class GalaxyDetailsProvider : IGalaxyDetailsProvider
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
    }
}