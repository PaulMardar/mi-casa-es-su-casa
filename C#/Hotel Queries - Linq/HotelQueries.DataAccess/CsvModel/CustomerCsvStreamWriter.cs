using System;
using System.IO;

namespace iQuest.HotelQueries.DataAccess.CsvModel
{
    internal class CustomerCsvStreamWriter : IDisposable
    {
        private bool isDisposed;
        private readonly TextWriter textWriter;

        public CustomerCsvStreamWriter(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            textWriter = new StreamWriter(stream);
            textWriter.WriteLine(CustomerCsvRecord.Header);
        }

        public void WriteCustomer(CustomerCsvRecord customerCsvRecord)
        {
            textWriter.WriteLine(customerCsvRecord.ToString());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
                textWriter?.Dispose();

            isDisposed = true;
        }
    }
}