using iQuest.BooksAndNews.Application.Publications;
using System;

namespace iQuest.BooksAndNews.Application.Publishers
{
    public class NewspaperPrintedEventArgs : EventArgs
    {
        public Newspaper Newspaper { get; set; }

        public NewspaperPrintedEventArgs(Newspaper newspaper)
        {
            this.Newspaper = newspaper;
        }
    }
}