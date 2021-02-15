using iQuest.VendingMachine.Authentication;
using System;

namespace iQuest.VendingMachine.UseCases
{
    class CheckProductExistanceCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;

        public CheckProductExistanceCase(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));

        }

        public string Name => "Check product";

        public string Description => "Check if a product is in stock";

        public bool CanExecute => false;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
