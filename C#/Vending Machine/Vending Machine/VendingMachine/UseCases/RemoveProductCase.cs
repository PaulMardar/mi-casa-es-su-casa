using iQuest.VendingMachine.Authentication;
using System;

namespace iQuest.VendingMachine.UseCases
{
    class RemoveProductCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;

        public RemoveProductCase(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public string Name => "Remove a product";

        public string Description => "Allows the admin to remove products";

        public bool CanExecute => false;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
