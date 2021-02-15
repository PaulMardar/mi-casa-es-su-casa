using iQuest.VendingMachine.Model;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Repo
{
    public interface IProductRepository
    {
        public abstract void AddProduct(int columnId, string name, float price, int quantity);

        public abstract void ReduceProductQuantity(int columnId);

        public abstract IProduct GetProductById(int id);

        public bool isValid(int id);

        IEnumerable<Product> GetAllProducts();
    }
}
