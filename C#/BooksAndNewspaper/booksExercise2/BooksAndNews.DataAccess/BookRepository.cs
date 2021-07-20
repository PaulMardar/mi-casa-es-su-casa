using System;
using System.Collections.Generic;
using System.IO;
using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publications;
using Newtonsoft.Json;

namespace iQuest.BooksAndNews.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private static readonly List<Book> books;

        static BookRepository()
        {
            string json = File.ReadAllText("Data\\books.json");
            books = JsonConvert.DeserializeObject<List<Book>>(json);
        }

        private readonly Random random;

        public BookRepository()
        {
            random = new Random();
        }

        public Book GetRandom()
        {
            if (books.Count == 0)
                return null;

            int index = random.Next(books.Count);
            return books[index];
        }
    }
}