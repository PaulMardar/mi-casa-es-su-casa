using System.Text;

namespace iQuest.HotelQueries.Domain
{
    public class PersonCustomer : Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonGender Gender { get; set; }

        public override string FullName
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(FirstName))
                    sb.Append(FirstName);

                if (!string.IsNullOrWhiteSpace(LastName))
                {
                    if (sb.Length > 0)
                        sb.Append(" ");

                    sb.Append(LastName);
                }

                return sb.ToString();
            }
        }

        public bool Equals(PersonCustomer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) && Gender == other.Gender;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PersonCustomer)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Gender;
                return hashCode;
            }
        }
    }
}