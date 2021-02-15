namespace iQuest.VendingMachine.Model.Pay
{
    interface IPaymentAlgorithm
    {
        public string Name { get; }

        public void Run(float price);
    }
}
