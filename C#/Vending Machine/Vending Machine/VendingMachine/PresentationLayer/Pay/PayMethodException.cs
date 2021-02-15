using System;

namespace iQuest.VendingMachine.PresentationLayer.Pay
{
    internal class PayMethodException : Exception
    {
        private const string DefaultMessage = "An exception occurred during the paymenth procces";

        public PayMethodException()
            : base(DefaultMessage)
        {
        }

        public PayMethodException(string errorMesage) : base(errorMesage)
        {
        }
    }
}
