using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Model.Pay;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace TestVendingMachine.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class PaymentUseCaseConstructorTests
    {
        private Mock<IAuthenticationService> authenticationService;

        private Mock<IBuyView> buyView;

        private Mock<List<IPaymentAlgorithm>> paymentAlgorithms;

        [TestInitialize]
        public void TestSetup()
        {
            authenticationService = new Mock<IAuthenticationService>();
            buyView = new Mock<IBuyView>();
            paymentAlgorithms = new Mock<List<IPaymentAlgorithm>>();
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingPaymentUseCase_ThrowsException()
        {
            var paymentUseCase = new PaymentUseCase(authenticationService.Object, buyView.Object, paymentAlgorithms.Object);
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new PaymentUseCase(null, buyView.Object, paymentAlgorithms.Object);
            });
        }

        [TestMethod]
        public void HavingANullBuyView_WhenInitializingPaymentUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new PaymentUseCase(authenticationService.Object, null, paymentAlgorithms.Object);
            });
        }

        [TestMethod]
        public void HavingANullPaymentAlgorithms_WhenInitializingPaymentUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new PaymentUseCase(authenticationService.Object, buyView.Object, null);
            });
        }
    }
}
