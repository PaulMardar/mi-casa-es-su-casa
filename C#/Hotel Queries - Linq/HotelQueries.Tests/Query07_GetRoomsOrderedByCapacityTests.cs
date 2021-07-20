using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query07_GetRoomsOrderedByCapacityTests
    {
        [TestMethod]
        public void Test()
        {
            Hotel hotel = HotelBuilder.CreateHotel();

            IEnumerable<Room> rooms = hotel.GetRoomsOrderedByCapacity();
            int[] actualRoomNumbers = rooms.Select(x => x.Number).ToArray();

            Trace.WriteLine("Actual room numbers: ");
            Trace.WriteLine(string.Join(",", actualRoomNumbers));

            int[] expectedRoomNumbers = { 7, 8, 13, 15, 17, 18, 20, 21, 23, 24, 1, 3, 4, 5, 6, 12, 14, 25, 26, 27, 28, 29, 2, 9, 10, 11, 16, 19, 22, 30, 31, 32 };
            CollectionAssert.AreEqual(expectedRoomNumbers, actualRoomNumbers);
        }
    }
}