namespace iQuest.HotelQueries.Domain
{
    public class Room
    {
        public int Number { get; set; }
        public int MaxPersonCount { get; set; }
        public bool IsDisabledFriendly { get; set; }
        public bool HasBalcony { get; set; }
        public bool IsInUse { get; set; }
        public bool HasAirConditioner { get; set; }
        public double Surface { get; set; }

        public bool Equals(Room other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Number == other.Number &&
                   MaxPersonCount == other.MaxPersonCount &&
                   IsDisabledFriendly == other.IsDisabledFriendly &&
                   HasBalcony == other.HasBalcony &&
                   IsInUse == other.IsInUse &&
                   HasAirConditioner == other.HasAirConditioner &&
                   Equals(Surface, other.Surface);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Room)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Number;
                hashCode = (hashCode * 397) ^ MaxPersonCount;
                hashCode = (hashCode * 397) ^ IsDisabledFriendly.GetHashCode();
                hashCode = (hashCode * 397) ^ HasBalcony.GetHashCode();
                hashCode = (hashCode * 397) ^ IsInUse.GetHashCode();
                hashCode = (hashCode * 397) ^ HasAirConditioner.GetHashCode();
                hashCode = (hashCode * 397) ^ Surface.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{Number} ({MaxPersonCount} pers; {Surface} m2)";
        }
    }
}