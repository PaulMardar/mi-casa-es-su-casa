using iQuest.VendingMachine.Authentication;
using System;

namespace iQuest.VendingMachine.UseCases
{
    class SalesReportCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;

        public SalesReportCase(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public string Name => "Sales report";

        public string Description => "Generates a sales report for the admin";

        public bool CanExecute => false;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
