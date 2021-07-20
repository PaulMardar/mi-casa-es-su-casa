using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query02_FindCustomerByNameTests
    {
        private static Hotel hotel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            hotel = HotelBuilder.CreateHotel();
        }

        [TestMethod]
        public void TestBert()
        {
            int[] expectedCustomerIds = { 35, 42, 94, 127, 189, 264, 265, 351, 583, 690, 694, 775, 1142, 1273 };
            PerformTest("bert", expectedCustomerIds);
        }

        [TestMethod]
        public void TestSte()
        {
            int[] expectedCustomerIds = { 13, 67, 70, 85, 96, 98, 99, 108, 165, 203, 228, 320, 329, 343, 351, 476, 482, 517, 523, 576, 717, 759, 774, 778, 828, 836, 855, 858, 906, 927, 1087, 1187, 1365 };
            PerformTest("Ste", expectedCustomerIds);
        }

        [TestMethod]
        public void TestMyr()
        {
            int[] expectedCustomerIds = { 315, 696 };
            PerformTest("mYr", expectedCustomerIds);
        }

        private static void PerformTest(string text, int[] expectedCustomerIds)
        {
            IEnumerable<Customer> customers = hotel.FindCustomerByName(text);
            int[] actualCustomerIds = customers.Select(x => x.Id).ToArray();

            Trace.WriteLine("Actual ids: ");
            Trace.WriteLine(string.Join(",", actualCustomerIds));

            CollectionAssert.AreEquivalent(expectedCustomerIds, actualCustomerIds);
        }
    }
}