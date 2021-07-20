using iQuest.BooksAndNews.Application.DataAccess;
using System;

namespace iQuest.BooksAndNews.Application.Publishers
{
    /// <summary>
    /// This is the class that will publish books and newspapers.
    /// It must offer a mechanism through which different other classes can subscribe ether
    /// to books or to newspaper.
    /// When a book or newspaper is published, the PrintingOffice must notify all the corresponding
    /// subscribers.
    /// </summary>
    public class PrintingOffice
    {
        private IBookRepository bookRepository;

        private INewspaperRepository newspaperRepository;

        private ILog log;

        public event EventHandler<BookPrintedEventArgs> BookPrinted;

        public event EventHandler<NewspaperPrintedEventArgs> NewspaperPrinted;

        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void PrintRandom(int bookCount, int newspaperCount)
        {
            printBooks(bookCount);
            printNewspapers(newspaperCount);
        }
        private void printBooks(int bookCount)
        {
            for (var i = 0; i < bookCount; ++i)
            {
                var book = bookRepository.GetRandom();
                log.WriteInfo(String.Format("A new BOOK was printed {0} , {1} , {2} ", book.Title, book.Author, book.Year));
                BookPrinted(this, new BookPrintedEventArgs(book));
            }
        }
        private void printNewspapers(int newspaperCount)
        {
            for (var i = 0; i < newspaperCount; ++i)
            {
                var newspaper = newspaperRepository.GetRandom();
                log.WriteInfo(String.Format("A new newspaper was printed {0} , {1} ", newspaper.Title, newspaper.Number));
                NewspaperPrinted(this, new NewspaperPrintedEventArgs(newspaper));
            }
        }
    }
}