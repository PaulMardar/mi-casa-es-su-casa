using System;
using System.Collections.Generic;
using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publishers;
using iQuest.BooksAndNews.Application.Subscribers;

namespace iQuest.BooksAndNews.Application
{
    public class PrintingUseCase
    {
        private readonly IBookRepository bookRepository;
        private readonly INewspaperRepository newspaperRepository;
        private readonly ILog log;

        private PrintingOffice printingOffice;
        private readonly List<BookLover> bookLovers = new List<BookLover>();
        private readonly List<NewsHunter> newsHunters = new List<NewsHunter>();

        public PrintingUseCase(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Execute()
        {
            CreatePrintingOffice();
            CreateBookLovers();
            CreateNewsHunters();

            printingOffice.PrintRandom(2, 5);
        }

        private void CreatePrintingOffice()
        {
            printingOffice = new PrintingOffice(bookRepository, newspaperRepository, log);
        }

        private void CreateBookLovers()
        {
            BookLover william = new BookLover("William", printingOffice, log);
            bookLovers.Add(william);

            BookLover james = new BookLover("James", printingOffice, log);
            bookLovers.Add(james);

            BookLover anna = new BookLover("Anna", printingOffice, log);
            bookLovers.Add(anna);
        }

        private void CreateNewsHunters()
        {
            NewsHunter alice = new NewsHunter("Alice", printingOffice, log);
            newsHunters.Add(alice);

            NewsHunter johnny = new NewsHunter("Johnny", printingOffice, log);
            newsHunters.Add(johnny);
        }
    }
}