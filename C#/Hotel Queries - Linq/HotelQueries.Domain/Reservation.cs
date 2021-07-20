using System;

namespace iQuest.HotelQueries.Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Room Room { get; set; }
        public int NoOfPersons { get; set; }

        public Reservation()
        {
        }

        public Reservation(int id, Customer customer, DateTime startDate, DateTime endDate, Room room)
        {
            if (endDate < startDate)
                throw new ArgumentException("The endDate value must be greater than startDate.", nameof(endDate));

            Id = id;
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Room = room ?? throw new ArgumentNullException(nameof(room));
            StartDate = startDate.Date;
            EndDate = endDate.Date;
        }

        public bool ConflictsWith(Reservation reservation)
        {
            return Room.Number == reservation.Room.Number &&
                   StartDate < reservation.EndDate &&
                   EndDate > reservation.StartDate &&
                   Id != reservation.Id;
        }

        public bool ConflictsWith(DateTime startDate, DateTime endDate)
        {
            return StartDate < endDate && EndDate > startDate;
        }
    }
}