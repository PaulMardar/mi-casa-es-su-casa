using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repo;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;

        private readonly IBuyView buyView;

        private readonly IProductRepository productRepository;

        private IPaymentUseCase paymenthUseCase;

        private readonly DispenseView dispenserView;

        public string Name => "buy";

        public string Description => "Allows the user to buy a products";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(IAuthenticationService authenticationService, IBuyView buyView, IProductRepository productrepository, IPaymentUseCase paymenthUsecase, DispenseView dispenseView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(BuyUseCase.buyView));
            this.productRepository = productrepository ?? throw new ArgumentNullException(nameof(BuyUseCase.productRepository));
            this.paymenthUseCase = paymenthUsecase ?? throw new ArgumentNullException(nameof(paymenthUsecase));
            this.dispenserView = dispenseView ?? throw new ArgumentNullException(nameof(dispenseView));
        }

        public void Execute()
        {
            buyView.DisplayProducts(productRepository.GetAllProducts());

            int columnId = buyView.GetProductId();

            if (!productRepository.isValid(columnId))
            {
                throw new InvalidProductIdException();
            }

            if (buyView.ConfirmTransaction())
            {
                var product = productRepository.GetProductById(columnId);
                paymenthUseCase.Execute(product.Price);
                productRepository.ReduceProductQuantity(columnId);
                dispenserView.DispenseProduct(product.Name);
            }
        }
    }
}
