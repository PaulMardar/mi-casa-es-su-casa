using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Model;
using iQuest.VendingMachine.Model.Pay;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Pay;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
namespace TestVendingMachine.UseCases.PaymentUseCaseTests
{
    [TestClass]
    public class PaymentUseCaseTests
    {
        private Mock<IAuthenticationService> authenticationService;

        private Mock<IBuyView> buyView;

        private Mock<List<IPaymentAlgorithm>> paymentAlgorithms;

        private Mock<IEnumerable<IPaymentMethod>> payMethods;

        [TestInitialize]
        public void TestSetup()
        {
            authenticationService = new Mock<IAuthenticationService>();
            buyView = new Mock<IBuyView>();
            paymentAlgorithms = new Mock<List<IPaymentAlgorithm>>();
            payMethods = new Mock<IEnumerable<IPaymentMethod>>();
        }


        [TestMethod]
        public void HavingNotValidAskForPaymentMethod_ThrowsException()
        {

            var payUseCase = new PaymentUseCase(authenticationService.Object, buyView.Object, paymentAlgorithms.Object);
            Moq.Language.Flow.IReturnsResult<IBuyView> returnsResult = null;
            var paymentUseCase = new PaymentUseCase(authenticationService.Object, buyView.Object, paymentAlgorithms.Object);

            Assert.ThrowsException<PayMethodException>(() =>
            {
                paymentUseCase.Execute((float)2);
            });
        }

        [TestMethod]
        public void HavingALLValidComponets_noExceptionIsThrown()
        {
            CardPaymentView cardPaymentTerminal = new CardPaymentView();
            CardPayment cardPaymenth = new CardPayment(cardPaymentTerminal);

            CashPaymentView cashPaymentTerminal = new CashPaymentView();
            CashPayment cashPaymenth = new CashPayment(cashPaymentTerminal);
            List<IPaymentAlgorithm> paymentAlgorithmsList = new List<IPaymentAlgorithm>();

            paymentAlgorithmsList.Add(cashPaymenth);
            paymentAlgorithmsList.Add(cardPaymenth);
            var paymentUseCase = new PaymentUseCase(authenticationService.Object, buyView.Object, paymentAlgorithmsList);

            buyView.Setup(x => x.AskForPaymentMethod(payMethods.Object))
                .Returns(0);

            paymentUseCase.Execute((float)2);
            Assert.IsTrue(true);

        }
    }
}
