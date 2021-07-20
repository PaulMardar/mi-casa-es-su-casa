using System;
using iQuest.BooksAndNews.Application;
using iQuest.BooksAndNews.DataAccess;

namespace iQuest.BooksAndNews
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Bootstrapping - Application Setup

            Log log = new Log();
            BookRepository bookRepository = new BookRepository();
            NewspaperRepository newspaperRepository = new NewspaperRepository();

            // Run

            PrintingUseCase printingUseCase = new PrintingUseCase(bookRepository, newspaperRepository, log);
            printingUseCase.Execute();

            // End

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}