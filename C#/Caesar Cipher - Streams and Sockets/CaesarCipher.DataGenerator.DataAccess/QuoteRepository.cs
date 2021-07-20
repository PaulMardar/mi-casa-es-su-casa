using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using iQuest.CaesarCipher.DataGenerator.Business;

namespace iQuest.CaesarCipher.DataGenerator.DataAccess
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly List<string> quotes = new List<string>();
        private readonly Random random = new Random();

        public QuoteRepository()
        {
            IEnumerable<string> loadedQuotes = LoadParagraphs();
            quotes.AddRange(loadedQuotes);
        }

        private static IEnumerable<string> LoadParagraphs()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using Stream stream = assembly.GetManifestResourceStream("iQuest.CaesarCipher.DataGenerator.DataAccess.Data.data.txt");
            using StreamReader streamReader = new StreamReader(stream);

            while (!streamReader.EndOfStream)
                yield return streamReader.ReadLine();
        }

        public string GetOne()
        {
            int paragraphIndex = random.Next(quotes.Count);
            return quotes[paragraphIndex];
        }
    }
}
