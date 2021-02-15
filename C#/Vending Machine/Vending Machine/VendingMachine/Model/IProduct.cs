namespace iQuest.VendingMachine.Model
{
    public interface IProduct
    {
        public int ProductId { get; }

        public string Name { get; }

        public float Price { get; }

        public int Quantity { get; }
    }
}
