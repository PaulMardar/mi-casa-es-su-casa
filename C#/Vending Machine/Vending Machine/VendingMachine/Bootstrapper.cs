using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Model.Pay;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Pay;
using iQuest.VendingMachine.Repo;
using iQuest.VendingMachine.UseCases;
using System.Collections.Generic;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            var productRepository = new SqlServerRepository(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False ");
            MainView mainView = new MainView();
            LoginView loginView = new LoginView();

            CardPaymentView cardPaymentTerminal = new CardPaymentView();
            CardPayment cardPaymenth = new CardPayment(cardPaymentTerminal);

            CashPaymentView cashPaymentTerminal = new CashPaymentView();
            CashPayment cashPaymenth = new CashPayment(cashPaymentTerminal);

            ShelfView shelfView = new ShelfView();
            BuyView buyView = new BuyView();
            DispenseView dispenseView = new DispenseView();

            AuthenticationService authenticationService = new AuthenticationService();
            List<IPaymentAlgorithm> paymentAlgorithmsList = new List<IPaymentAlgorithm>();
            paymentAlgorithmsList.Add(cashPaymenth);
            paymentAlgorithmsList.Add(cardPaymenth);
            var payUseCase = new PaymentUseCase(authenticationService, buyView, paymentAlgorithmsList);

            List<IUseCase> useCases = new List<IUseCase>
            {
                new TurnOffUseCase(),
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new ViewUseCase(shelfView,productRepository),
                new AddProductCase(authenticationService),
                new RemoveProductCase(authenticationService),
                new BuyUseCase(authenticationService,buyView,productRepository,payUseCase,dispenseView),
                new CheckProductExistanceCase(authenticationService),
                new SalesReportCase(authenticationService),
                new StockReportCase(authenticationService),
                new VolumeReportCase(authenticationService),
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}