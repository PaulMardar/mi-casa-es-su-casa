using iQuest.VendingMachine.Model;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Repo
{
    class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public ProductRepository()
        {
            AddProduct(1, "Oreo", (float)1.00, 1);
            AddProduct(2, "Kit-Kat", (float)1.50, 8);
            AddProduct(3, "Coca Cola", (float)1.25, 2);
            AddProduct(4, "Fanta", (float)1.25, 5);
            AddProduct(5, "Pepsi", (float)1.00, 7);
        }

        public void AddProduct(int columnId, string name, float price, int quantity)
        {
            Product addedProduct = new Product(columnId, name, price, quantity);

            _products.Add(addedProduct);
        }

        public void ReduceProductQuantity(int columnId)
        {
            foreach (var product in _products)
            {
                if (product.ProductId == columnId)
                {
                    product.RemoveQuantity(1);
                }
            }
        }

        public IProduct GetProductById(int Id)
        {
            foreach (Product product in _products)
            {
                if (product.ProductId == Id)
                {
                    return product;
                }
            }
            return null;
        }

        public bool isValid(int id)
        {
            {
                foreach (Product product in _products)
                {
                    if (product.ProductId == id)
                        return true;
                }
                return false;
            }
        }

        public IEnumerable<Product> GetAllProducts() => this._products;
    }
}
