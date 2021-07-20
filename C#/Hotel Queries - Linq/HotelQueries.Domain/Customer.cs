using System;

namespace iQuest.HotelQueries.Domain
{
    public abstract class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public DateTime LastAccommodation { get; set; }

        public abstract string FullName { get; }

        public bool Equals(Customer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Email, other.Email) && string.Equals(City, other.City) && string.Equals(Country, other.Country) && string.Equals(Phone, other.Phone) && LastAccommodation.Equals(other.LastAccommodation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Customer)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Id;
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LastAccommodation.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{FullName} ({Id})";
        }
    }
}