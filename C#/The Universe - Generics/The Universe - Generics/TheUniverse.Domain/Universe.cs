using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.TheUniverse.Domain
{
    public class Universe
    {
        private static Universe instance;

        public static Universe Instance
        {
            get
            {
                if (instance == null)
                    instance = new Universe();

                return instance;
            }
        }

        private readonly HashSet<Galaxy> galaxies = new HashSet<Galaxy>();

        public bool AddGalaxy(string galaxyName)
        {
            if (galaxyName == null) throw new ArgumentNullException(nameof(galaxyName));

            bool galaxyExists = galaxies.Any(x => x.Name == galaxyName);

            if (galaxyExists)
                return false;

            Galaxy galaxy = new Galaxy(galaxyName);
            return galaxies.Add(galaxy);
        }

        public bool AddStar(string starName, string galaxyName)
        {
            Galaxy galaxy = galaxies.FirstOrDefault(x => x.Name == galaxyName);

            if (galaxy == null)
                throw new Exception($"Galaxy '{galaxyName}' does not exist.");

            return galaxy.AddStar(starName);
        }

        public IEnumerable<Galaxy> EnumerateGalaxies()
        {
            return galaxies;
        }
    }
}