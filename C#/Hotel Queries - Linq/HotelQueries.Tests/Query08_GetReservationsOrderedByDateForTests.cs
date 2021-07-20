using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query08_GetReservationsOrderedByDateForTests
    {
        private static Hotel hotel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            hotel = HotelBuilder.CreateHotel();
        }

        [TestMethod]
        public void Customer828()
        {
            int[] expectedReservationIds = { 5, 106 };
            PerformTest(828, expectedReservationIds);
        }

        [TestMethod]
        public void Customer1020()
        {
            int[] expectedReservationIds = { 23, 69 };
            PerformTest(1020, expectedReservationIds);
        }

        [TestMethod]
        public void Customer561()
        {
            int[] expectedReservationIds = { 31, 152 };
            PerformTest(561, expectedReservationIds);
        }

        [TestMethod]
        public void Customer784()
        {
            int[] expectedReservationIds = { 50, 45 };
            PerformTest(784, expectedReservationIds);
        }

        [TestMethod]
        public void Customer1311()
        {
            int[] expectedReservationIds = { 57, 92 };
            PerformTest(1311, expectedReservationIds);
        }

        [TestMethod]
        public void Customer835()
        {
            int[] expectedReservationIds = { 83, 133 };
            PerformTest(835, expectedReservationIds);
        }

        [TestMethod]
        public void Customer1219()
        {
            int[] expectedReservationIds = { 118, 183 };
            PerformTest(1219, expectedReservationIds);
        }

        [TestMethod]
        public void Customer153()
        {
            int[] expectedReservationIds = { 161, 166 };
            PerformTest(153, expectedReservationIds);
        }

        [TestMethod]
        public void Customer1040()
        {
            int[] expectedReservationIds = { 12 };
            PerformTest(1040, expectedReservationIds);
        }

        private static void PerformTest(int customerId, int[] expectedReservationIds)
        {
            IEnumerable<Reservation> reservations = hotel.GetReservationsOrderedByDateFor(customerId);
            int[] actualReservationIds = reservations.Select(x => x.Id).ToArray();

            Trace.WriteLine("Actual ids: ");
            Trace.WriteLine(string.Join(",", actualReservationIds));

            CollectionAssert.AreEqual(expectedReservationIds, actualReservationIds);
        }
    }
}