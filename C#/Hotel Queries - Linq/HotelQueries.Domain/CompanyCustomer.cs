namespace iQuest.HotelQueries.Domain
{
    public class CompanyCustomer : Customer
    {
        public string Name { get; set; }

        public override string FullName => Name;
    }
}