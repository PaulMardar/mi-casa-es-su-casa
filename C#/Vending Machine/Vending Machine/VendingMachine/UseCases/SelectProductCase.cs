using System;

namespace iQuest.VendingMachine.UseCases
{
    class SelectProductCase : IUseCase
    {
        public string Name => "Select";

        public string Description => "Allows the user to select an product";

        public bool CanExecute => false;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
