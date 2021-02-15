using System;

namespace iQuest.VendingMachine.Model
{
    internal class InsuficientQuantityException : Exception
    {
        private const string DefaultMessage = "Insuficient Quantity";

        public InsuficientQuantityException()
            : base(DefaultMessage)
        {
        }
    }
}
