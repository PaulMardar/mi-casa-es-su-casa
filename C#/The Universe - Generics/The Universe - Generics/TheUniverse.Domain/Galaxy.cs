using System;
using System.Collections.Generic;

namespace iQuest.TheUniverse.Domain
{
    public class Galaxy
    {
        private readonly HashSet<string> stars = new HashSet<string>();

        public string Name { get; }

        public Galaxy(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public bool AddStar(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            return stars.Add(name);
        }

        public IEnumerable<string> EnumerateStars()
        {
            return stars;
        }
    }
}