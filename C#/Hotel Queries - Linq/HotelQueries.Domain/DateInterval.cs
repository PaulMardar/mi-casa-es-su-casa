using System;

namespace iQuest.HotelQueries.Domain
{
    public struct DateInterval
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public DateInterval(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException("The endDate value must be grater than startDate.", nameof(endDate));

            StartDate = startDate.Date;
            EndDate = endDate.Date;
        }

        public override string ToString()
        {
            return $"{StartDate:d} - {EndDate:d}";
        }
    }
}