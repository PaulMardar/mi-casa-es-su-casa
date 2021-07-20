using System.Collections;
using System.Collections.Generic;
using System.Linq;
using iQuest.Terra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.TerraPlus.Tests.ContinentPlusTests
{
    [TestClass]
    public class EnumerateCountriesByNameTests
    {
        [TestMethod]
        public void HavingAnEmptyContinent_WhenEnumeratingCountries_ListIsEmpty()
        {
            ContinentPlus continentPlus = new ContinentPlus();

            List<Country> expected = new List<Country>();

            PerformTest(continentPlus, expected);
        }

        [TestMethod]
        public void HavingAContinentWithOneCountry_WhenEnumeratingCountries_ListContainsTheCountry()
        {
            ContinentPlus continentPlus = new ContinentPlus(new List<Country>
            {
                new Country("Romania", "Bucharest")
            });

            List<Country> expected = new List<Country>
            {
                new Country("Romania", "Bucharest")
            };

            PerformTest(continentPlus, expected);
        }

        [TestMethod]
        public void HavingAContinentWithTwoCountriesInOrder_WhenEnumeratingCountries_ListContainsTheCountryInOrder()
        {
            ContinentPlus continentPlus = new ContinentPlus(new List<Country>
            {
                new Country("France", "Paris"),
                new Country("Romania", "Bucharest")
            });

            List<Country> expected = new List<Country>
            {
                new Country("France", "Paris"),
                new Country("Romania", "Bucharest")
            };

            PerformTest(continentPlus, expected);
        }

        [TestMethod]
        public void HavingAContinentWithTwoCountriesOutOfOrder_WhenEnumeratingCountries_ListContainsTheCountryInOrder()
        {
            ContinentPlus continentPlus = new ContinentPlus(new List<Country>
            {
                new Country("Romania", "Bucharest"),
                new Country("France", "Paris")
            });

            List<Country> expected = new List<Country>
            {
                new Country("France", "Paris"),
                new Country("Romania", "Bucharest")
            };

            PerformTest(continentPlus, expected);
        }

        [TestMethod]
        public void HavingAContinentWithOneNullAndTwoCountries_WhenEnumeratingCountries_ListContainsTheNullBeforeCountries()
        {
            ContinentPlus continentPlus = new ContinentPlus(new List<Country>
            {
                null,
                new Country("Romania", "Bucharest"),
                new Country("France", "Paris")
            });

            List<Country> expected = new List<Country>
            {
                null,
                new Country("France", "Paris"),
                new Country("Romania", "Bucharest")
            };

            PerformTest(continentPlus, expected);
        }

        [TestMethod]
        public void HavingAContinentWithCountryNullCountry_WhenEnumeratingCountries_ListContainsTheNullBeforeCountries()
        {
            ContinentPlus continentPlus = new ContinentPlus(new List<Country>
            {
                new Country("Romania", "Bucharest"),
                null,
                new Country("France", "Paris")
            });

            List<Country> expected = new List<Country>
            {
                null,
                new Country("France", "Paris"),
                new Country("Romania", "Bucharest")
            };

            PerformTest(continentPlus, expected);
        }

        [TestMethod]
        public void HavingAContinentWithTwoCountriesAndANull_WhenEnumeratingCountries_ListContainsTheNullBeforeCountries()
        {
            ContinentPlus continentPlus = new ContinentPlus(new List<Country>
            {
                new Country("Romania", "Bucharest"),
                new Country("France", "Paris"),
                null
            });

            List<Country> expected = new List<Country>
            {
                null,
                new Country("France", "Paris"),
                new Country("Romania", "Bucharest")
            };

            PerformTest(continentPlus, expected);
        }

        private static void PerformTest(ContinentPlus continentPlus, ICollection expected)
        {
            List<Country> actual = continentPlus.EnumerateCountriesByName().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}