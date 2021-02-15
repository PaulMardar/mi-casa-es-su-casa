using iQuest.VendingMachine.Authentication;
using System;

namespace iQuest.VendingMachine.UseCases
{
    class AddProductCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;

        public AddProductCase(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public string Name => "Add product";

        public string Description => "Replenish some items in the vending machine";

        public bool CanExecute => false;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
