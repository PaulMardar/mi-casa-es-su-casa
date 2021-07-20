using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries.DataAccess.CsvModel
{
    internal class ReservationCsvRecord
    {
        private readonly string idRaw;
        private readonly string clientIdRaw;
        private readonly string roomNumberRaw;
        private readonly string startDateRaw;
        private readonly string endDateRaw;
        private readonly string noOfPersonsRaw;

        public ReservationCsvRecord(string text)
        {
            string[] items = text.Split(',');

            idRaw = items[0];
            clientIdRaw = items[1];
            roomNumberRaw = items[2];
            startDateRaw = items[3];
            endDateRaw = items[4];
            noOfPersonsRaw = items[5];
        }

        public ReservationCsvRecord(Reservation reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));

            idRaw = reservation.Id.ToString();
            clientIdRaw = reservation.Customer.Id.ToString();
            roomNumberRaw = reservation.Room.Number.ToString();
            startDateRaw = reservation.StartDate.ToString("M/d/yyyy");
            endDateRaw = reservation.EndDate.ToString("M/d/yyyy");
            noOfPersonsRaw = reservation.NoOfPersons.ToString();
        }

        public Reservation ToReservation(IEnumerable<Customer> customers, IEnumerable<Room> rooms)
        {
            int clientId = int.Parse(clientIdRaw);
            int roomNumber = int.Parse(roomNumberRaw);

            return new Reservation
            {
                Id = int.Parse(idRaw),
                Customer = customers.FirstOrDefault(x => x.Id == clientId),
                Room = rooms.FirstOrDefault(x => x.Number == roomNumber),
                StartDate = DateTime.Parse(startDateRaw, new CultureInfo("en-US")),
                EndDate = DateTime.Parse(endDateRaw, new CultureInfo("en-US")),
                NoOfPersons = int.Parse(noOfPersonsRaw)
            };
        }

        public override string ToString()
        {
            return $"{idRaw},{clientIdRaw},{roomNumberRaw},{startDateRaw},{endDateRaw},{noOfPersonsRaw}";
        }
    }
}