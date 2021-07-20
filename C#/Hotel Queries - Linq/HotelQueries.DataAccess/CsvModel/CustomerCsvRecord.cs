using System;
using System.Globalization;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries.DataAccess.CsvModel
{
    internal class CustomerCsvRecord
    {
        private readonly string id;
        private readonly string firstName;
        private readonly string lastName;
        private readonly string email;
        private readonly string gender;
        private readonly string city;
        private readonly string country;
        private readonly string phone;
        private readonly string lastAccommodation;

        private readonly bool isPerson;

        public static string Header => "id,first_name,last_name,email,gender,city,Country,Phone,LastAccommodation";

        public CustomerCsvRecord(string text)
        {
            string[] items = text.Split(',');

            id = items[0];
            firstName = items[1];
            lastName = items[2];
            email = items[3];
            gender = items[4];
            city = items[5];
            country = items[6];
            phone = items[7];
            lastAccommodation = items[8];

            isPerson = !string.IsNullOrEmpty(gender);
        }

        public CustomerCsvRecord(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            id = customer.Id.ToString();
            email = customer.Email;
            city = customer.City;
            country = customer.Country;
            phone = customer.Phone;
            lastAccommodation = customer.LastAccommodation.ToString("M/d/yyyy", new CultureInfo("en-US"));

            switch (customer)
            {
                case PersonCustomer personCustomer:
                    firstName = personCustomer.FirstName;
                    lastName = personCustomer.LastName;
                    gender = personCustomer.Gender.ToString();
                    isPerson = true;
                    break;

                case CompanyCustomer companyCustomer:
                    firstName = companyCustomer.Name;
                    isPerson = false;
                    break;
            }
        }

        public Customer ToCustomer()
        {
            return isPerson
                ? (Customer)CreatePersonCustomer()
                : CreateCompanyCustomer();
        }

        private PersonCustomer CreatePersonCustomer()
        {
            return new PersonCustomer
            {
                Id = int.Parse(id),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Gender = (PersonGender)Enum.Parse(typeof(PersonGender), gender),
                City = city,
                Country = country,
                Phone = phone,
                LastAccommodation = ParseDateTime(lastAccommodation)
            };
        }

        private CompanyCustomer CreateCompanyCustomer()
        {
            return new CompanyCustomer
            {
                Id = int.Parse(id),
                Name = firstName,
                Email = email,
                City = city,
                Country = country,
                Phone = phone,
                LastAccommodation = ParseDateTime(lastAccommodation)
            };
        }

        private static DateTime ParseDateTime(string value)
        {
            return DateTime.Parse(value, new CultureInfo("en-US"));
        }

        public override string ToString()
        {
            return $"{id},{firstName},{lastName},{email},{gender},{city},{country},{phone},{lastAccommodation}";
        }
    }
}