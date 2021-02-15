using iQuest.VendingMachine.PresentationLayer.Pay;

namespace iQuest.VendingMachine.Model.Pay
{
    internal class CardPayment : IPaymentAlgorithm
    {
        public string Name { get; private set; }

        private CardPaymentView cardPaymentTerminal;

        private LuhnCheck luhnCheck;

        public CardPayment(CardPaymentView cardPaymentTerminal)
        {
            this.cardPaymentTerminal = cardPaymentTerminal;
            this.Name = "card";
            this.luhnCheck = new LuhnCheck();
        }

        public void Run(float price)
        {
            var cardNumber = cardPaymentTerminal.AskForCardNumber();
            if (!luhnCheck.CardChecking(cardNumber))
            {
                throw new PayMethodException("invalid credit card number");
            }
        }
    }
}
