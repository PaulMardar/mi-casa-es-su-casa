using System;
using System.IO;

namespace iQuest.HotelQueries.DataAccess.CsvModel
{
    internal class CustomerCsvStreamReader : IDisposable
    {
        private bool isDisposed;
        private readonly TextReader textReader;

        public CustomerCsvStreamReader(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            textReader = new StreamReader(stream);
            textReader.ReadLine();
        }

        public CustomerCsvStreamReader(TextReader textReader)
        {
            this.textReader = textReader ?? throw new ArgumentNullException(nameof(textReader));

            this.textReader.ReadLine();
        }

        public CustomerCsvStreamReader(StreamReader streamReader)
        {
            textReader = streamReader ?? throw new ArgumentNullException(nameof(streamReader));

            textReader.ReadLine();
        }

        public CustomerCsvRecord ReadCustomer()
        {
            string line = textReader.ReadLine();

            return line == null
                ? null
                : new CustomerCsvRecord(line);
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
                textReader?.Dispose();

            isDisposed = true;
        }
    }
}