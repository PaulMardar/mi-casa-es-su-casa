using iQuest.TheUniverse.Application.AddGalaxy;
using iQuest.TheUniverse.Application.AddStar;
using iQuest.TheUniverse.Application.GetAllStars;
using iQuest.TheUniverse.Infrastructure;
using iQuest.TheUniverse.Presentation;
using System.Collections.Generic;

namespace iQuest.TheUniverse
{
    internal class Bootstrapper
    {
        private static RequestBus requestBus;

        public void Run()
        {
            requestBus = new RequestBus();
            ConfigureRequestBus();
            DisplayApplicationHeader();
            RunUserCommandProcessLoop();
        }

        private static void ConfigureRequestBus()
        {
            requestBus.RegisterHandler<AddStarRequest, bool, AddStarRequestHandler>();
            requestBus.RegisterHandler<AddGalaxyRequest, bool, AddGalaxyRequestHandler>();
            requestBus.RegisterHandler<GetAllStarsRequest, List<StarInfo>, GetAllStarsRequestHandler>();
        }

        private static void DisplayApplicationHeader()
        {
            ApplicationHeader applicationHeader = new ApplicationHeader();
            applicationHeader.Display();
        }

        private static void RunUserCommandProcessLoop()
        {
            Prompter prompter = new Prompter(requestBus);
            prompter.ProcessUserInput();
        }
    }
}