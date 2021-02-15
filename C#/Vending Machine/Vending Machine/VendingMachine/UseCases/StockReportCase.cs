using iQuest.VendingMachine.Authentication;
using System;

namespace iQuest.VendingMachine.UseCases
{
    class StockReportCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;

        public StockReportCase(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public string Name => "stock report";

        public string Description => "Generates a stock report for the admin";

        public bool CanExecute => false;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
