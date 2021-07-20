using System.Collections.Generic;
using System.Linq;
using iQuest.HotelQueries.DataAccess;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries.Tests
{
    public class HotelBuilder
    {
        public static Hotel CreateHotel()
        {
            RoomsRepository roomsRepository = new RoomsRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            ReservationRepository reservationRepository = new ReservationRepository();

            List<Room> rooms = roomsRepository.GetAll().ToList();
            List<Customer> customers = customerRepository.GetAll().ToList();
            List<Reservation> reservations = reservationRepository.GetAll(customers, rooms).ToList();

            return new Hotel
            {
                Rooms = rooms,
                Customers = customers,
                Reservations = reservations
            };
        }
    }
}