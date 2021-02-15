using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Model;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repo;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace TestVendingMachine.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class BuyUseCasesTest
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
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            buyView = new Mock<IBuyView>();
            buyView.Setup(x => x.ConfirmTransaction())
                .Returns(true);

            productRepository = new Mock<IProductRepository>();
            productRepository.Setup(x => x.isValid(It.IsAny<int>()))
                .Returns(true);
            productRepository.Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(new Product(1, "kit-kat cu menta", 2, 2));

            dispenseView = new Mock<DispenseView>();
        }

        [TestMethod]
        public void HavingAllValidComponents_DispenseTheBoughtItem()
        {
            var paymentUseCase = new Mock<IPaymentUseCase>();

            var buyusecase = new BuyUseCase(
          authenticationService.Object, buyView.Object, productRepository.Object, paymentUseCase.Object, dispenseView.Object);

            using (StringWriter stringWriter = new StringWriter())
            {
                var consoleBackup = Console.Out;
                Console.SetOut(stringWriter);
                buyusecase.Execute();
                Assert.AreEqual("you got a kit-kat cu menta\r\n", stringWriter.ToString());
                Console.SetOut(consoleBackup);
            }

            Assert.IsTrue(buyusecase.CanExecute);
        }


        [TestMethod]
        public void HavingAllValidComponents_CanceledBuyTest()
        {
            buyView.Setup(x => x.ConfirmTransaction())
               .Returns(false);
            paymentUseCase = new Mock<IPaymentUseCase>();
            var buyusecase = new BuyUseCase(
                authenticationService.Object, buyView.Object, productRepository.Object, paymentUseCase.Object, dispenseView.Object);

            buyusecase.Execute();

            Assert.IsTrue(buyusecase.CanExecute);
            Assert.IsFalse(buyView.Object.ConfirmTransaction());
        }


        [TestMethod]
        public void ValidBuyUseCase_InvalidId_ThrowsException()
        {
            productRepository.Setup(x => x.isValid(It.IsAny<int>()))
                .Returns(false);
            paymentUseCase = new Mock<IPaymentUseCase>();
            var buyusecase = new BuyUseCase(
                authenticationService.Object, buyView.Object, productRepository.Object, paymentUseCase.Object, dispenseView.Object);

            Assert.ThrowsException<InvalidProductIdException>(() =>
            {
                buyusecase.Execute();
            });
        }
    }
}
