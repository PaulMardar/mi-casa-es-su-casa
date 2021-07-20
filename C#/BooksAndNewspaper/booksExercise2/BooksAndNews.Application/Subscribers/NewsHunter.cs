using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever news
    /// are printed.
    ///
    /// Subscribe to the printing office and log each news that was printed.
    /// </summary>
    public class NewsHunter
    {
        private readonly string name;

        private readonly ILog log;

        public NewsHunter(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name;
            this.log = log;

            printingOffice.NewspaperPrinted += this.NewsPrintedHandler;
        }

        private void NewsPrintedHandler(Newspaper newspaper)
        {
            log.WriteInfo(String.Format("New newspaper printed for NewspaperHunter {0}, with title {1}, number {2} ", this.name, newspaper.Title, newspaper.Number));
        }
    }
}