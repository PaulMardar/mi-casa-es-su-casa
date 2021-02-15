using iQuest.VendingMachine.Authentication;
using System;

namespace iQuest.VendingMachine.UseCases
{
    class VolumeReportCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;

        public VolumeReportCase(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public string Name => "volume report";

        public string Description => "Generates a volume report for the admin";

        public bool CanExecute => false;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
