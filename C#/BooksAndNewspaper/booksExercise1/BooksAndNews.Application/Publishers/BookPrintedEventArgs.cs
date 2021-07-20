using iQuest.BooksAndNews.Application.Publications;
using System;

namespace iQuest.BooksAndNews.Application.Publishers
{
    public class BookPrintedEventArgs : EventArgs
    {
        public Book Book { get; set; }

        public BookPrintedEventArgs(Book book)
        {
            this.Book = book;
        }
    }
}
