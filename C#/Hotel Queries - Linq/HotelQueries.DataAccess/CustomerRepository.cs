using System.Collections.Generic;
using System.IO;
using iQuest.HotelQueries.DataAccess.CsvModel;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries.DataAccess
{
    public class CustomerRepository
    {
        private const string RootDirectoryPath = "Data";

        private readonly string customersFilePath = Path.Combine(RootDirectoryPath, "customers.csv");

        public IEnumerable<Customer> GetAll()
        {
            using (FileStream fileStream = new FileStream(customersFilePath, FileMode.Open, FileAccess.Read))
            using (CustomerCsvStreamReader streamReader = new CustomerCsvStreamReader(fileStream))
            {
                while (true)
                {
                    CustomerCsvRecord customerCsvRecord = streamReader.ReadCustomer();

                    if (customerCsvRecord == null)
                        break;

                    yield return customerCsvRecord.ToCustomer();
                }
            }
        }

        public void SaveAll(IEnumerable<Customer> customers)
        {
            using (FileStream fileStream = new FileStream(customersFilePath + ".new", FileMode.Create, FileAccess.Write))
            using (CustomerCsvStreamWriter streamWriter = new CustomerCsvStreamWriter(fileStream))
            {
                foreach (Customer customer in customers)
                {
                    CustomerCsvRecord customerCsvRecord = new CustomerCsvRecord(customer);
                    streamWriter.WriteCustomer(customerCsvRecord);
                }
            }
        }
    }
}