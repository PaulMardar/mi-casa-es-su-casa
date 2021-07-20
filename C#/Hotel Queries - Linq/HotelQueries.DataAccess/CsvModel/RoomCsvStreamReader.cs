using System;
using System.IO;

namespace iQuest.HotelQueries.DataAccess.CsvModel
{
    internal class RoomCsvStreamReader : IDisposable
    {
        private bool isDisposed;
        private readonly TextReader textReader;

        public RoomCsvStreamReader(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            textReader = new StreamReader(stream);
            textReader.ReadLine();
        }

        public RoomCsvStreamReader(TextReader textReader)
        {
            this.textReader = textReader ?? throw new ArgumentNullException(nameof(textReader));

            this.textReader.ReadLine();
        }

        public RoomCsvStreamReader(StreamReader streamReader)
        {
            textReader = streamReader ?? throw new ArgumentNullException(nameof(streamReader));

            textReader.ReadLine();
        }

        public RoomCsvRecord ReadRoom()
        {
            string line = textReader.ReadLine();

            return line == null
                ? null
                : new RoomCsvRecord(line);
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