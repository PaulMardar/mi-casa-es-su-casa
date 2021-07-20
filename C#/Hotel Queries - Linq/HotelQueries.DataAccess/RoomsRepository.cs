using System.Collections.Generic;
using System.IO;
using iQuest.HotelQueries.DataAccess.CsvModel;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries.DataAccess
{
    public class RoomsRepository
    {
        private const string RootDirectoryPath = "Data";

        private readonly string roomsFilePath = Path.Combine(RootDirectoryPath, "rooms.csv");

        public IEnumerable<Room> GetAll()
        {
            using (FileStream fileStream = new FileStream(roomsFilePath, FileMode.Open, FileAccess.Read))
            using (RoomCsvStreamReader streamReader = new RoomCsvStreamReader(fileStream))
            {
                while (true)
                {
                    RoomCsvRecord roomCsvRecord = streamReader.ReadRoom();

                    if (roomCsvRecord == null)
                        break;

                    yield return roomCsvRecord.ToRoom();
                }
            }
        }
    }
}