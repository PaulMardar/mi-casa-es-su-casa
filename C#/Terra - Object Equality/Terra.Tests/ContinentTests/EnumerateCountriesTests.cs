using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.Terra.Tests.ContinentTests
{
    [TestClass]
    public class EnumerateCountriesTests
    {
        [TestMethod]
        public void HavingAnEmptyContinent_WhenEnumeratingCountries_ListIsEmpty()
        {
            Continent continent = new Continent();

            List<Country> expected = new List<Country>();

            PerformTest(continent, expected);
        }

        [TestMethod]
        public void HavingAContinentWithOneCountry_WhenEnumeratingCountries_ListContainsTheCountry()
        {
            Continent continent = new Continent(new List<Country>
            {
                new Country("Romania", "Bucharest")
            });

            List<Country> expected = new List<Country>
            {
                new Country("Romania", "Bucharest")
            };

            PerformTest(continent, expected);
        }

        [TestMethod]
        public void HavingAContinentWithTwoCountriesInOrder_WhenEnumeratingCountries_ListContainsTheCountryInOrder()
        {
            Continent continent = new Continent(new List<Country>
            {
                new Country("France", "Paris"),
                new Country("Romania", "Bucharest")
            });

            List<Country> expected = new List<Country>
            {
                new Country("France", "Paris"),
                new Country("Romania", "Bucharest")
            };

            PerformTest(continent, expected);
        }

        [TestMethod]
        public void HavingAContinentWithTwoCountriesOutOfOrder_WhenEnumeratingCountries_ListContainsTheCountryInOrder()
        {
            Continent continent = new Continent(new List<Country>
            {
                new Country("Romania", "Bucharest"),
                new Country("France", "Paris")
            });

            List<Country> expected = new List<Country>
            {
                new Country("France", "Paris"),
                new Country("Romania", "Bucharest")
            };

            PerformTest(continent, expected);
        }

        [TestMethod]
        public void HavingAContinentWithOneNullAndTwoCountries_WhenEnumeratingCountries_ListContainsTheNullBeforeCountries()
        {
            Continent continent = new Continent(new List<Country>
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

            PerformTest(continent, expected);
        }

        [TestMethod]
        public void HavingAContinentWithCountryNullCountry_WhenEnumeratingCountries_ListContainsTheNullBeforeCountries()
        {
            Continent continent = new Continent(new List<Country>
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

            PerformTest(continent, expected);
        }

        [TestMethod]
        public void HavingAContinentWithTwoCountriesAndANull_WhenEnumeratingCountries_ListContainsTheNullBeforeCountries()
        {
            Continent continent = new Continent(new List<Country>
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

            PerformTest(continent, expected);
        }

        private static void PerformTest(Continent continent, ICollection expected)
        {
            List<Country> actual = continent.EnumerateCountriesByName().ToList();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}