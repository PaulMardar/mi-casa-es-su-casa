using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// Subscribe to the printing office and log each book that was printed.
    /// </summary>
    public class BookLover
    {
        private readonly string name;

        private readonly ILog log;

        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name;
            this.log = log;

            printingOffice.BookPrinted += this.HandleBookPrinted;
        }

        private void HandleBookPrinted(object sender, BookPrintedEventArgs args)
        {
            log.WriteInfo(String.Format("New book printed for BookLover {0}, with title {1}, author {2} and published in the year {3} ", this.name, args.Book.Title, args.Book.Author, args.Book.Year));
        }
    }
}