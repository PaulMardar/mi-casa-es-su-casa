using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repo;

namespace iQuest.VendingMachine.UseCases
{
    internal class ViewUseCase : IUseCase
    {
        private readonly ShelfView shelfView;

        private readonly IProductRepository productrepository;

        public ViewUseCase(ShelfView shelfView, IProductRepository productrepository)
        {
            this.shelfView = shelfView;
            this.productrepository = productrepository;
        }

        public string Name => "view";

        public string Description => "View all products stored in the vending machine";

        public bool CanExecute => true;

        public void Execute()
        {
            this.shelfView.DisplayProducts(productrepository.GetAllProducts());
        }
    }
}
