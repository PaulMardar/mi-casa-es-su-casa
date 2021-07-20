using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query06_GetPageOfRoomsOrderedBySurfaceTests
    {
        private static Hotel hotel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            hotel = HotelBuilder.CreateHotel();
        }

        [TestMethod]
        public void TestPage0With10Items()
        {
            int[] expectedRoomNumbers = { 5, 3, 22, 14, 13, 28, 18, 12, 25, 11 };
            PerformTest(0, 10, expectedRoomNumbers);
        }

        [TestMethod]
        public void TestPage1With10Items()
        {
            int[] expectedRoomNumbers = { 23, 26, 2, 8, 32, 29, 31, 10, 1, 24 };
            PerformTest(1, 10, expectedRoomNumbers);
        }

        [TestMethod]
        public void TestPage2With10Items()
        {
            int[] expectedRoomNumbers = { 17, 21, 20, 7, 9, 19, 16, 15, 30, 27 };
            PerformTest(2, 10, expectedRoomNumbers);
        }

        [TestMethod]
        public void TestPage3With10Items()
        {
            int[] expectedRoomNumbers = { 6, 4 };
            PerformTest(3, 10, expectedRoomNumbers);
        }

        [TestMethod]
        public void TestPage4With10Items()
        {
            int[] expectedRoomNumbers = new int[0];
            PerformTest(4, 10, expectedRoomNumbers);
        }

        [TestMethod]
        public void TestPage2With7Items()
        {
            int[] expectedRoomNumbers = { 32, 29, 31, 10, 1, 24, 17 };
            PerformTest(2, 7, expectedRoomNumbers);
        }

        private static void PerformTest(int pageindex, int pageSize, int[] expectedRoomNumbers)
        {
            IEnumerable<Room> rooms = hotel.GetPageOfRoomsOrderedBySurface(pageindex, pageSize);
            int[] actualRoomNumbers = rooms.Select(x => x.Number).ToArray();

            Trace.WriteLine("Actual room numbers: ");
            Trace.WriteLine(string.Join(",", actualRoomNumbers));

            CollectionAssert.AreEqual(expectedRoomNumbers, actualRoomNumbers);
        }
    }
}