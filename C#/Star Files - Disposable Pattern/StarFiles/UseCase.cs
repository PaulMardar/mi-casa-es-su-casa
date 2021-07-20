using iQuest.StarFiles.UniverseModel;
using System;

namespace iQuest.StarFiles
{
    internal class UseCase
    {
        public void Execute()
        {
            using (Universe universe = new Universe())
            {
                string starFilePath = GenerateStar(universe);

                (string binaryStarFilePath1, string binaryStarFilePath2) = GenerateBinaryStar(universe);

                DisplayFileContent(starFilePath);

                DisplayFileContent(binaryStarFilePath1);

                DisplayFileContent(binaryStarFilePath2);
            }
        }

        private static string GenerateStar(Universe universe)
        {
            Console.WriteLine();
            Console.WriteLine("Generating star.");

            const string starName = "Betelgeuse";
            string createdFilePath = universe.CreateStarFromTemplate(starName);

            Console.WriteLine($"Finished generating star: '{starName}'.");
            Console.WriteLine($"File: {createdFilePath}");

            return createdFilePath;
        }

        private static Tuple<string, string> GenerateBinaryStar(Universe universe)
        {
            Console.WriteLine();
            Console.WriteLine("Generating binary star.");

            const string starName = "Sirius";
            Tuple<string, string> createdFilePath = universe.CreateBinaryStar(starName);

            Console.WriteLine($"Finished generating binary star '{starName}'.");
            Console.WriteLine($"Files: {createdFilePath}");

            return createdFilePath;
        }

        private static void DisplayFileContent(string filePath)
        {
            Console.WriteLine();
            Console.WriteLine($"File: '{filePath}'");
            Console.WriteLine("Content:");

            WinApiFile winApiFile = new WinApiFile(filePath);
            string text = winApiFile.ReadAll();
            Console.WriteLine(text);

        }
    }
}