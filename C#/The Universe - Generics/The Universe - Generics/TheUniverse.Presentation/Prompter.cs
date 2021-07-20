using System;
using iQuest.TheUniverse.Infrastructure;
using iQuest.TheUniverse.Presentation.Commands;

namespace iQuest.TheUniverse.Presentation
{
    public class Prompter
    {
        private readonly RequestBus requestBus;
        private bool exitWasRequested;

        public Prompter(RequestBus requestBus)
        {
            this.requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void ProcessUserInput()
        {
            exitWasRequested = false;

            while (!exitWasRequested)
            {
                try
                {
                    string command = ReadCommandFromConsole();
                    ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    DisplayError(ex);
                }
            }
        }

        private static string ReadCommandFromConsole()
        {
            Console.WriteLine();
            Console.Write("Universe> ");
            return Console.ReadLine();
        }

        private void ProcessCommand(string command)
        {
            switch (command)
            {
                case "add-galaxy":
                    AddGalaxyCommand command1 = new AddGalaxyCommand(requestBus);
                    command1.Execute();
                    break;

                case "add-star":
                    AddStarCommand command2 = new AddStarCommand(requestBus);
                    command2.Execute();
                    break;

                case "display-stars":
                    DisplayAllStarsCommand command3 = new DisplayAllStarsCommand(requestBus);
                    command3.Execute();
                    break;

                case "exit":
                case "kill":
                case "collapse":
                    exitWasRequested = true;
                    break;

                default:
                    throw new Exception("Invalid command.");
            }
        }

        private static void DisplayError(Exception exception)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception);
            Console.ForegroundColor = oldColor;
        }
    }
}