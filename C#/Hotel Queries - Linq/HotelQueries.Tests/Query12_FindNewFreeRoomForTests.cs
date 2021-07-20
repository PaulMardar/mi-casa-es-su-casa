using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query12_FindNewFreeRoomForTests
    {
        private static Hotel hotel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            hotel = HotelBuilder.CreateHotel();
        }

        [TestMethod]
        public void Reservation23()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 23);
            PerformTest(reservationWithConflicts, new[] { 13, 19, 25 });
        }

        [TestMethod]
        public void Reservation160()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 160);
            PerformTest(reservationWithConflicts, null);
        }

        [TestMethod]
        public void Reservation167()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 167);
            PerformTest(reservationWithConflicts, new[] { 11, 14, 18, 30 });
        }

        [TestMethod]
        public void Reservation112()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 112);
            PerformTest(reservationWithConflicts, null);
        }

        [TestMethod]
        public void Reservation194()
        {
            Reservation reservationWithConflicts = hotel.Reservations.Single(x => x.Id == 194);
            PerformTest(reservationWithConflicts, null);
        }

        private static void PerformTest(Reservation reservationWithConflicts, int[] expectedRoomNumbers)
        {
            Room actualRoom = hotel.FindNewFreeRoomFor(reservationWithConflicts);

            Trace.WriteLine("Actual proposed room number: " + (actualRoom?.Number.ToString() ?? "<null>"));

            if (expectedRoomNumbers == null || expectedRoomNumbers.Length == 0)
            {
                Assert.IsNull(actualRoom);
            }
            else
            {
                Assert.IsNotNull(actualRoom);
                CollectionAssert.Contains(expectedRoomNumbers, actualRoom.Number);
            }
        }
    }
}