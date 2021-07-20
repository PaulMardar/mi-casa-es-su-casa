using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iQuest.HotelQueries.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQuest.HotelQueries.Tests
{
    [TestClass]
    public class Query04_FindWomenTests
    {
        private static Hotel hotel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            hotel = HotelBuilder.CreateHotel();
        }

        [TestMethod]
        public void TestYear2015()
        {
            int[] expectedCustomerIds = { 15, 29, 40, 54, 66, 81, 96, 108, 125, 174, 180, 192, 212, 281, 352, 353, 356, 382, 394, 411, 416, 427, 431, 435, 471, 497, 502, 511, 529, 591, 629, 647, 650, 683, 695, 701, 729, 751, 766, 803, 833, 864, 892, 897, 902, 922, 934, 938, 944, 946, 950, 953, 962 };
            DateTime startTime = new DateTime(2015, 01, 01);
            DateTime endTime = new DateTime(2015, 12, 31, 23, 59, 29);
            PerformTest(startTime, endTime, expectedCustomerIds);
        }

        [TestMethod]
        public void TestYear2016()
        {
            int[] expectedCustomerIds = { 5, 7, 48, 50, 83, 129, 149, 156, 163, 164, 243, 246, 280, 301, 305, 312, 314, 320, 324, 350, 351, 387, 439, 449, 457, 487, 517, 554, 575, 596, 599, 615, 661, 680, 702, 716, 752, 788, 832, 845, 865, 913, 915, 916, 939, 943, 965, 971, 978, 990 };
            DateTime startTime = new DateTime(2016, 01, 01);
            DateTime endTime = new DateTime(2016, 12, 31, 23, 59, 29);
            PerformTest(startTime, endTime, expectedCustomerIds);
        }

        [TestMethod]
        public void TestYear2017()
        {
            int[] expectedCustomerIds = { 32, 42, 58, 80, 93, 118, 124, 147, 193, 207, 208, 236, 256, 268, 289, 293, 328, 335, 389, 398, 404, 425, 496, 501, 504, 530, 536, 540, 543, 547, 558, 570, 592, 621, 648, 660, 709, 721, 776, 805, 818, 819, 823, 835, 839, 847, 848, 855, 868, 908, 924, 947, 961, 963, 993, 997 };
            DateTime startTime = new DateTime(2017, 01, 01);
            DateTime endTime = new DateTime(2017, 12, 31, 23, 59, 29);
            PerformTest(startTime, endTime, expectedCustomerIds);
        }

        [TestMethod]
        public void TestYear2018()
        {
            int[] expectedCustomerIds = { 4, 46, 77, 119, 155, 275, 489, 571, 664, 689, 723, 785, 790, 793, 882, 929, 935, 979 };
            DateTime startTime = new DateTime(2018, 01, 01);
            DateTime endTime = new DateTime(2018, 12, 31, 23, 59, 29);
            PerformTest(startTime, endTime, expectedCustomerIds);
        }

        [TestMethod]
        public void TestYear2019()
        {
            int[] expectedCustomerIds = new int[0];
            DateTime startTime = new DateTime(2019, 01, 01);
            DateTime endTime = new DateTime(2019, 12, 31, 23, 59, 29);
            PerformTest(startTime, endTime, expectedCustomerIds);
        }

        private static void PerformTest(DateTime startTime, DateTime endTime, int[] expectedCustomerIds)
        {
            IEnumerable<Customer> customers = hotel.FindWomen(startTime, endTime);
            int[] actualCustomerIds = customers.Select(x => x.Id).ToArray();

            Trace.WriteLine("Actual ids: ");
            Trace.WriteLine(string.Join(",", actualCustomerIds));

            CollectionAssert.AreEquivalent(expectedCustomerIds, actualCustomerIds);
        }
    }
}