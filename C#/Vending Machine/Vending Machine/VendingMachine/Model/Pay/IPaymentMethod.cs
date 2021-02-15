namespace iQuest.VendingMachine.Model
{
    public interface IPaymentMethod
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
