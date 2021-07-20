using System;
using iQuest.BooksAndNews.Application;

namespace iQuest.BooksAndNews
{
    /// <summary>
    /// This class is responsible to store the received message.
    /// This particular implementation is just sending the message to the console.
    /// The implementation can be changed to store the message in a text file
    /// or in a database or send it over the network to a server.
    /// But, for now, writing it to the console is the simplest thing to do. 
    /// </summary>
    public class Log : ILog
    {
        public void WriteInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}