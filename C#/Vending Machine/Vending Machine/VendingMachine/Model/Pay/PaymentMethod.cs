namespace iQuest.VendingMachine.Model.Pay
{
    class PaymentMethod : IPaymentMethod
    {
        public PaymentMethod(int id, string name) => (Id, Name) = (id, name);

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
