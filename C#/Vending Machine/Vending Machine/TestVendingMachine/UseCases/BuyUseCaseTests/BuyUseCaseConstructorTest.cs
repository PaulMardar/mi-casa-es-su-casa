using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repo;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TestVendingMachine.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class BuyUseCaseConstructorTest
    {
        private Mock<IAuthenticationService> authenticationService;

        private Mock<IBuyView> buyView;

        private Mock<IProductRepository> productRepository;

        private Mock<IPaymentUseCase> paymentUseCase;

        private Mock<DispenseView> dispenseView;

        [TestInitialize]
        public void TestSetup()
        {
            authenticationService = new Mock<IAuthenticationService>();
            buyView = new Mock<IBuyView>();
            productRepository = new Mock<IProductRepository>();
            paymentUseCase = new Mock<IPaymentUseCase>();
            dispenseView = new Mock<DispenseView>();
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(
                null, buyView.Object, productRepository.Object, paymentUseCase.Object, dispenseView.Object);
            });
        }

        [TestMethod]
        public void HavingANullBuyView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(
                authenticationService.Object, null, productRepository.Object, paymentUseCase.Object, dispenseView.Object);
            });
        }

        [TestMethod]
        public void HavingANullProductRepository_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(
                authenticationService.Object, buyView.Object, null, paymentUseCase.Object, dispenseView.Object);
            });
        }

        [TestMethod]
        public void HavingANullpaymentUseCase_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                new BuyUseCase(
                authenticationService.Object, buyView.Object, productRepository.Object, null, dispenseView.Object)
            );
        }

        [TestMethod]
        public void HavingANullDispenseView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>

                new BuyUseCase(
                authenticationService.Object, buyView.Object, productRepository.Object, paymentUseCase.Object, null)
            );
        }
    }
}
