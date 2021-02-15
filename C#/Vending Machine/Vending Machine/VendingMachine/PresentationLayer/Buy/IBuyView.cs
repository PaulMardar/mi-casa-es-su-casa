using iQuest.VendingMachine.Model;
using System.Collections.Generic;
namespace iQuest.VendingMachine.PresentationLayer
{
    interface IBuyView
    {
        public int GetProductId();

        public void DisplayProducts(IEnumerable<Product> products);

        public bool ConfirmTransaction();

        public int? AskForPaymentMethod(IEnumerable<IPaymentMethod> payMethods);
    }
}
