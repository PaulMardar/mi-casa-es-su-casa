using System;

namespace iQuest.VendingMachine.Model
{
    public class Product : IProduct
    {
        public Product(int columnId, string name, float price, int quantity)
        {
            ProductId = columnId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Quantity = quantity;
        }

        public int ProductId { get; private set; }

        public string Name { get; private set; }

        public float Price { get; private set; }

        public int Quantity { get; private set; }

        public void AddQuantity(int quantity)
        {
            Quantity = Quantity + quantity;
        }
        public void RemoveQuantity(int quantity)
        {
            Quantity = Quantity - quantity;
        }
        public override string ToString()
        {
            return "id: " + this.ProductId + " name: " + this.Name + " price: " + this.Price + " quantity: " + this.Quantity;
        }
    }
}
