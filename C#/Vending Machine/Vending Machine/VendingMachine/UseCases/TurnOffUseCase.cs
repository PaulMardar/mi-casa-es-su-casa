using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        public string Name => "exit";

        public string Description => "Turns of the vending machine";

        public bool CanExecute => true;

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
