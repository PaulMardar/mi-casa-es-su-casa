using iQuest.HotelQueries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.HotelQueries
{
    public class Hotel
    {
        public List<Room> Rooms { get; set; } = new List<Room>();

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        /// <summary>
        /// 1) Return a collection with all rooms that can accomodate exactly 2 persons.
        /// </summary>
        public IEnumerable<Room> GetAllRoomsForTwoPersons()
        {
            return Rooms.Where(room => room.MaxPersonCount == 2);
        }

        /// <summary>
        /// 2) Return all customers whose full name contains the specified searched text.
        /// The search must be case insensitive.
        /// </summary>
        public IEnumerable<Customer> FindCustomerByName(string text)
        {
            return Customers.Where(customer => customer.FullName.ToLower()
                            .Contains(text, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// 3) Return all reservations made by companies.
        /// </summary>
        public IEnumerable<Reservation> GetCompanyReservations()
        {
            return Reservations.Where(reservations => reservations.Customer is CompanyCustomer);
        }

        /// <summary>
        /// 4) Return all women customers that last checked in a specific period of time.
        /// </summary>
        public IEnumerable<Customer> FindWomen(DateTime startTime, DateTime endTime)
        {
            return Customers.OfType<PersonCustomer>()
                 .Where(women => women.Gender == PersonGender.Female)
                 .Where(women => women.LastAccommodation >= startTime && women.LastAccommodation <= endTime);
        }

        /// <summary>
        /// 5) Calculate how many persons can the hotel accomodate.
        /// </summary>
        public int CalculateHotelCapacity()
        {
            return Rooms.Sum(room => room.MaxPersonCount);
        }

        /// <summary>
        /// 6) Return a single page containing a number of exactly pageSize Rooms, ordered by surface.
        /// The pageNumber starts from 0.
        ///
        /// This is useful when paginating a large number of items in order to display them in a webpage.
        /// </summary>
        public IEnumerable<Room> GetPageOfRoomsOrderedBySurface(int pageNumber, int pageSize)
        {
            return Rooms.OrderBy(r => r.Surface).Skip(pageSize * pageNumber).Take(pageSize);
        }

        /// <summary>
        /// 7) Return the rooms sorted by <see cref="Room.MaxPersonCount"/> in a descending order.
        /// If two rooms have the same number of max persons, sort them further by <see cref="Room.Number"/> in ascending order.
        /// </summary>
        public IEnumerable<Room> GetRoomsOrderedByCapacity()
        {
            return Rooms.OrderByDescending(r => r.MaxPersonCount).ThenBy(r => r.Number);
        }

        /// <summary>
        /// 8) Return all reservations for the specified customer.
        /// The reservations must be ordered from the most recent one to the oldest one.
        /// </summary>
        public IEnumerable<Reservation> GetReservationsOrderedByDateFor(int customerId)
        {
            return Reservations.Where(r => r.Customer.Id == customerId)
                               .OrderByDescending(r => r.EndDate);
        }

        /// <summary>
        /// 9) Return a dictionary with the customers grouped by the last accommodation's year.
        /// The years must be enumerated in descending order.
        /// Customers must be ordered by full name.
        /// </summary>
        public List<KeyValuePair<int, Customer[]>> GetCustomersGroupedByYear()
        {
            return Customers
                .GroupBy(c => c.LastAccommodation.Year)
                .ToDictionary(λ => λ.Key, λ => { return λ.Where(x => x.LastAccommodation.Year == λ.Key).OrderBy(c => c.FullName).ToArray(); }).OrderByDescending(c => c.Key)
                .ToList<KeyValuePair<int, Customer[]>>();
        }

        /// <summary>
        /// 10) Calculate the average number of reservation per month.
        /// Consider the start date as the date of the reservation.
        /// </summary>
        public double CalculateAverageReservationsPerMonth()
        {
            return Reservations
                   .GroupBy(c => c.StartDate.Month)
                   .Average(x => x.Count());
        }

        public IDictionary<DateTime, Reservation[]> ReservationsByMonth()
        {
            return Reservations
                    .GroupBy(x => new DateTime(x.StartDate.Year, x.StartDate.Month, 1))
                    .ToDictionary(x => x.Key, x => x.ToArray());
        }

        /// <summary>
        /// 11) Find all reservations that have a conflict with other ones and return a dictionary containing the reservation as key
        /// and the list of conflicting reservations as value.
        /// The reservations that does not have conflicts should not be present in the dictionary.
        /// </summary>
        public IDictionary<Reservation, List<Reservation>> GetConflictingReservations()
        {
            return Reservations
            .Select(x => new
            {
                Reservation = x,
                Conflicts = Reservations.Where(x.ConflictsWith).ToList()
            })
            .Where(x => x.Conflicts.Count != 0)
            .ToDictionary(x => x.Reservation, x => x.Conflicts);
        }

        /// <summary>
        /// 12) We have a reservation for a room, but there is a conflict: there is another reservation for the same room.
        /// Your task is to propose another similar room for the reservation.
        /// 
        /// A similar room is a room that has the same number of maximum occupants or grater, has air conditioner if
        /// the original reserved room had, is disabled friendly if the original reserved room was and
        /// has balcony if the original reserved room had one.
        /// </summary>
        public Room FindNewFreeRoomFor(Reservation reservation)
        {
            return Rooms
                    .Where(x => x.MaxPersonCount >= reservation.Room.MaxPersonCount &&
                    x.HasAirConditioner == reservation.Room.HasAirConditioner &&
                    x.IsDisabledFriendly == reservation.Room.IsDisabledFriendly &&
                    x.HasBalcony == reservation.Room.HasBalcony)
                    .FirstOrDefault(x =>
                    {
                        bool existsConflicts = Reservations
                        .Where(r => r.Room.Equals(x))
                        .Any(r => r.ConflictsWith(reservation.StartDate, reservation.EndDate));
                        return !existsConflicts;
                    });


        }

    }
}