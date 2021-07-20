using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace iQuest.Terra.Tests.CountryTests
{
    [TestClass]
    public class ComparableTests
    {
        [TestMethod]
        public void HavingOneCountry_WhenComparedToNull_ReturnsPositive()
        {
            Country country = new Country("Romania", "Bucharest");

            int actual = country.CompareTo(null);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void HavingOneCountry_WhenComparedToItself_ReturnsZero()
        {
            Country country = new Country("Romania", "Bucharest");

            int actual = country.CompareTo(country);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void HavingOneCountry_WhenComparedToAnotherObject_Throws()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Country country = new Country("Romania", "Bucharest");
                object o = new object();

                country.CompareTo(o);
            });
        }

        [TestMethod]
        public void HavingTwoCountriesWithSameValues_WhenCompared_ReturnsZero()
        {
            Country country1 = new Country("Romania", "Bucharest");
            Country country2 = new Country("Romania", "Bucharest");

            int actual = country1.CompareTo(country2);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void HavingFirstCountryLessThanSecondCountry_WhenCompared_ReturnsNegative()
        {
            Country country1 = new Country("France", "Paris");
            Country country2 = new Country("Romania", "Bucharest");

            int actual = country1.CompareTo(country2);

            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void HavingFirstCountryGraterThanSecondCountry_WhenCompared_ReturnsPositive()
        {
            Country country1 = new Country("Romania", "Bucharest");
            Country country2 = new Country("France", "Paris");

            int actual = country1.CompareTo(country2);

            Assert.AreEqual(1, actual);
        }
    }
}