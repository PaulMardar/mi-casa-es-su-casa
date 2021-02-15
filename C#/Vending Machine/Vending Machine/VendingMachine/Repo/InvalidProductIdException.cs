using System;

namespace iQuest.VendingMachine.Repo
{
    internal class InvalidProductIdException : Exception
    {
        private const string DefaultMessage = "Invalid Product Id";

        public InvalidProductIdException()
            : base(DefaultMessage)
        {
        }
    }
}
