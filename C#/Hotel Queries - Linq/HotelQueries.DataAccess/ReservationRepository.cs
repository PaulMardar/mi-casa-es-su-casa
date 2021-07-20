using System.Collections.Generic;
using System.IO;
using iQuest.HotelQueries.DataAccess.CsvModel;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries.DataAccess
{
    public class ReservationRepository
    {
        private const string RootDirectoryPath = "Data";

        private readonly string reservationsFilePath = Path.Combine(RootDirectoryPath, "reservations.csv");

        public IEnumerable<Reservation> GetAll(IEnumerable<Customer> customers, IEnumerable<Room> rooms)
        {
            using (FileStream fileStream = new FileStream(reservationsFilePath, FileMode.Open, FileAccess.Read))
            using (ReservationCsvStreamReader streamReader = new ReservationCsvStreamReader(fileStream))
            {
                while (true)
                {
                    ReservationCsvRecord reservationCsvRecord = streamReader.ReadReservation();

                    if (reservationCsvRecord == null)
                        break;

                    yield return reservationCsvRecord.ToReservation(customers, rooms);
                }
            }
        }
    }
}