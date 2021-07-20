using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query10_CalculateAverageReservationsPerMonthTests
    {
        [TestMethod]
        public void Test()
        {
            Hotel hotel = HotelBuilder.CreateHotel();

            double actual = hotel.CalculateAverageReservationsPerMonth();

            Trace.WriteLine("Actual value: " + actual);

            Assert.AreEqual(64.66, actual, 0.01);
        }
    }
}