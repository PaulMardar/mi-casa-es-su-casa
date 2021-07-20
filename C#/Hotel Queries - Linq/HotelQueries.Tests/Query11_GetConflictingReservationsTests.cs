using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query11_GetConflictingReservationsTests
    {
        private static Hotel hotel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            hotel = HotelBuilder.CreateHotel();
        }

        [TestMethod]
        public void Test()
        {
            Dictionary<int, int[]> expectedCustomerIds = new Dictionary<int, int[]>
            {
                { 1, new[] { 151 } },
                { 3, new[] { 20 } },
                { 6, new[] { 16 } },
                { 16, new[] { 6 } },
                { 20, new[] { 3 } },
                { 21, new[] { 167 } },
                { 23, new[] { 74 } },
                { 29, new[] { 60, 86 } },
                { 40, new[] { 112, 192 } },
                { 43, new[] { 199 } },
                { 48, new[] { 170 } },
                { 50, new[] { 129 } },
                { 60, new[] { 29, 86 } },
                { 61, new[] { 126, 176 } },
                { 66, new[] { 190 } },
                { 67, new[] { 90 } },
                { 70, new[] { 79 } },
                { 74, new[] { 23 } },
                { 79, new[] { 70 } },
                { 86, new[] { 29, 60 } },
                { 90, new[] { 67 } },
                { 91, new[] { 119 } },
                { 92, new[] { 138 } },
                { 96, new[] { 177 } },
                { 112, new[] { 40, 192 } },
                { 113, new[] { 161 } },
                { 115, new[] { 163, 172 } },
                { 116, new[] { 186 } },
                { 119, new[] { 91 } },
                { 125, new[] { 168 } },
                { 126, new[] { 61, 176 } },
                { 129, new[] { 50 } },
                { 134, new[] { 160 } },
                { 138, new[] { 92 } },
                { 151, new[] { 1 } },
                { 154, new[] { 165 } },
                { 160, new[] { 134 } },
                { 161, new[] { 113 } },
                { 163, new[] { 115, 172 } },
                { 165, new[] { 154 } },
                { 167, new[] { 21 } },
                { 168, new[] { 125 } },
                { 170, new[] { 48 } },
                { 172, new[] { 115, 163 } },
                { 176, new[] { 61, 126 } },
                { 177, new[] { 96 } },
                { 179, new[] { 196 } },
                { 180, new[] { 194 } },
                { 186, new[] { 116 } },
                { 190, new[] { 66 } },
                { 192, new[] { 40, 112 } },
                { 194, new[] { 180 } },
                { 196, new[] { 179 } },
                { 199, new[] { 43 } }
            };
            PerformTest(expectedCustomerIds);
        }

        private static void PerformTest(IDictionary<int, int[]> expectedReservationIds)
        {
            IDictionary<Reservation, List<Reservation>> actualReservations = hotel.GetConflictingReservations();

            foreach (KeyValuePair<Reservation, List<Reservation>> keyValuePair in actualReservations)
            {
                int actualId = keyValuePair.Key.Id;
                int[] actualIds = keyValuePair.Value
                    .Select(x => x.Id)
                    .ToArray();

                Trace.WriteLine(string.Empty);
                Trace.WriteLine("Actual reservation id: " + actualId);
                Trace.WriteLine("Actual conflicting ids: " + string.Join(",", actualIds));
            }

            int[] actualReservationsWithConflicts = actualReservations
                .Select(x => x.Key.Id)
                .ToArray();

            int[] expectedReservationsWithConflicts = expectedReservationIds
                .Select(x => x.Key)
                .ToArray();

            CollectionAssert.AreEquivalent(expectedReservationsWithConflicts, actualReservationsWithConflicts);

            foreach (KeyValuePair<Reservation, List<Reservation>> keyValuePair in actualReservations)
            {
                int[] actualIds = keyValuePair.Value
                    .Select(x => x.Id)
                    .ToArray();

                int[] expectedIds = expectedReservationIds[keyValuePair.Key.Id];

                CollectionAssert.AreEquivalent(expectedIds, actualIds);
            }
        }
    }
}