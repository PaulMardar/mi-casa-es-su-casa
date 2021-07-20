using System;
using System.Globalization;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries.DataAccess.CsvModel
{
    internal class RoomCsvRecord
    {
        private readonly string number;
        private readonly string maxPersonCount;
        private readonly string isDisabledFriendly;
        private readonly string hasBalcony;
        private readonly string isInUse;
        private readonly string hasAirConditioner;
        private readonly string surface;

        public static string Header => "room_number,max_occupants,disabled_friendly,has_balcony,in_use,has_air_conditioner,surface";

        public RoomCsvRecord(string text)
        {
            string[] items = text.Split(',');

            number = items[0];
            maxPersonCount = items[1];
            isDisabledFriendly = items[2];
            hasBalcony = items[3];
            isInUse = items[4];
            hasAirConditioner = items[5];
            surface = items[6];
        }

        public RoomCsvRecord(Room room)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));

            number = room.Number.ToString();
            maxPersonCount = room.MaxPersonCount.ToString();
            isDisabledFriendly = room.IsDisabledFriendly.ToString();
            hasBalcony = room.HasBalcony.ToString();
            isInUse = room.IsInUse.ToString();
            hasAirConditioner = room.HasAirConditioner.ToString();
            surface = room.Surface.ToString(CultureInfo.InvariantCulture);
        }

        public Room ToRoom()
        {
            return new Room
            {
                Number = int.Parse(number),
                MaxPersonCount = int.Parse(maxPersonCount),
                IsDisabledFriendly = bool.Parse(isDisabledFriendly),
                HasBalcony = bool.Parse(hasBalcony),
                IsInUse = bool.Parse(isInUse),
                HasAirConditioner = bool.Parse(hasAirConditioner),
                Surface = double.Parse(surface)
            };
        }

        public override string ToString()
        {
            return $"{number},{maxPersonCount},{isDisabledFriendly},{hasBalcony},{isInUse},{hasAirConditioner},{surface}";
        }
    }
}