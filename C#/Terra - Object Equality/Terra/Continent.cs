using System;
using System.Collections.Generic;

namespace iQuest.Terra
{
    public class Continent
    {
        private readonly List<Country> countries = new List<Country>();

        public Continent()
        {
        }

        public Continent(IEnumerable<Country> countries)
        {
            if (countries == null) throw new ArgumentNullException(nameof(countries));

            this.countries.AddRange(countries);
        }

        public IEnumerable<Country> EnumerateCountriesByName()
        {
            countries.Sort();
            return countries;
        }
    }
}