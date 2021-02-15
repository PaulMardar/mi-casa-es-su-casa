using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Model;
using iQuest.VendingMachine.Model.Pay;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Pay;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private readonly IAuthenticationService authenticationService;

        private IBuyView buyView;

        private List<IPaymentAlgorithm> paymentAlgorithms;

        private IEnumerable<IPaymentMethod> payMethods;

        public string Name => "Pay";

        public string Description => "Allows the client to add credit to the vending machine";

        public bool CanExecute => false;

        public PaymentUseCase(IAuthenticationService authenticationService, IBuyView buyView, List<IPaymentAlgorithm> paymentAlgorithms)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView)); ;
            this.paymentAlgorithms = paymentAlgorithms ?? throw new ArgumentNullException(nameof(paymentAlgorithms)); ;
            this.payMethods = paymentAlgorithms.Select((algorithm, index) => new PaymentMethod(index, algorithm.Name));
        }

        public void Execute(float price)
        {
            var paymethodId = buyView.AskForPaymentMethod(payMethods);

            if (paymethodId is null)
            {
                throw new PayMethodException("invalid paymenth method");
            }

            paymentAlgorithms[paymethodId.Value].Run(price);
        }
    }
}
