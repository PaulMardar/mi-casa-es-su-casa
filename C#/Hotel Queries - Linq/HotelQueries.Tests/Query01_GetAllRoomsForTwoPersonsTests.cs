using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query01_GetAllRoomsForTwoPersonsTests
    {
        [TestMethod]
        public void Test()
        {
            Hotel hotel = HotelBuilder.CreateHotel();

            IEnumerable<Room> rooms = hotel.GetAllRoomsForTwoPersons();
            int[] actualRoomNumbers = rooms.Select(x => x.Number).ToArray();

            Trace.WriteLine("Actual room numbers: ");
            Trace.WriteLine(string.Join(",", actualRoomNumbers));

            int[] expectedRoomNumbers = { 1, 3, 4, 5, 6, 12, 14, 25, 26, 27, 28, 29 };
            CollectionAssert.AreEquivalent(expectedRoomNumbers, actualRoomNumbers);
        }
    }
}