using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.Terra.Tests.CountryTests
{
    [TestClass]
    public class EqualityTests
    {
        [TestMethod]
        public void HavingOneCountry_WhenComparedToNull_IsNotEqual()
        {
            Country country = new Country("Romania", "Bucharest");

            bool actual = country.Equals(null);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void HavingOneCountry_WhenComparedToItself_IsEqual()
        {
            Country country = new Country("Romania", "Bucharest");

            bool actual = country.Equals(country);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HavingOneCountry_WhenComparedToAnotherObject_IsNotEqual()
        {
            Country country = new Country("Romania", "Bucharest");
            object o = new object();

            bool actual = country.Equals(o);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void HavingTwoCountriesWithSameValues_WhenCompared_AreEqual()
        {
            Country country1 = new Country("Romania", "Bucharest");
            Country country2 = new Country("Romania", "Bucharest");

            bool actual = country1.Equals(country2);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HavingTwoCountriesWithDifferentValues_WhenCompared_AreNotEqual()
        {
            Country country1 = new Country("Romania", "Bucharest");
            Country country2 = new Country("France", "Paris");

            bool actual = country1.Equals(country2);

            Assert.IsFalse(actual);
        }
    }
}