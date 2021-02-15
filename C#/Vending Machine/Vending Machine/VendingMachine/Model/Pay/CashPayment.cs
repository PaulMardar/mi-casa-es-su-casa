using iQuest.VendingMachine.PresentationLayer.Pay;

namespace iQuest.VendingMachine.Model.Pay
{
    internal class CashPayment : IPaymentAlgorithm
    {
        public string Name { get; private set; }

        private CashPaymentView cashPaymentTerminal;

        public CashPayment(CashPaymentView cashPaymentTerminal)
        {
            this.cashPaymentTerminal = cashPaymentTerminal;
            this.Name = "cash";
        }

        public void Run(float price)
        {
            var cash = cashPaymentTerminal.AskForMoney();

            if (cash < price)
            {
                cashPaymentTerminal.GiveBackChange(cash);
                throw new PayMethodException("not enought founds");

            }
            cashPaymentTerminal.GiveBackChange(cash - price);
        }

    }
}
