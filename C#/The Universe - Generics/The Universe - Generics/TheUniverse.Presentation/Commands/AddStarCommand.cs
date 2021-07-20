using System;
using iQuest.TheUniverse.Application.AddStar;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Presentation.Commands
{
    internal class AddStarCommand
    {
        private readonly RequestBus requestBus;

        public AddStarCommand(RequestBus requestBus)
        {
            this.requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void Execute()
        {
            AddStarRequest addStarRequest = new AddStarRequest
            {
                StarDetailsProvider = new StarDetailsProvider()
            };
            bool success = requestBus.Send<AddStarRequest, bool>(addStarRequest);

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
            Console.WriteLine("The star was successfully created.");
            Console.ForegroundColor = oldColor;
        }

        private static void DisplayFailureMessage()
        {
            Console.WriteLine();

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to create the star. The star already exists.");
            Console.ForegroundColor = oldColor;
        }
    }
}