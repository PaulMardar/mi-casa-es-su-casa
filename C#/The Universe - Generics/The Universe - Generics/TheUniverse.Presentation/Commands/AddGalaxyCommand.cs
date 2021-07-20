using System;
using iQuest.TheUniverse.Application.AddGalaxy;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Presentation.Commands
{
    internal class AddGalaxyCommand
    {
        private readonly RequestBus requestBus;

        public AddGalaxyCommand(RequestBus requestBus)
        {
            this.requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void Execute()
        {
            AddGalaxyRequest addGalaxyRequest = new AddGalaxyRequest
            {
                GalaxyDetailsProvider = new GalaxyDetailsProvider()
            };
            bool success = requestBus.Send<AddGalaxyRequest, bool>(addGalaxyRequest);

            if (success)
                DisplaySuccessMessage();
            else
                DisplayFailureMessage();
        }

        private static void DisplaySuccessMessage()
        {
            Console.WriteLine();

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The galaxy was successfully created.");
            Console.ForegroundColor = oldColor;
        }

        private static void DisplayFailureMessage()
        {
            Console.WriteLine();

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to create the galaxy. The galaxy already exists.");
            Console.ForegroundColor = oldColor;
        }
    }
}