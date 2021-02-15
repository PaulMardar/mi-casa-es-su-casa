using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class UnavailableProductException : Exception
    {
        private const string DefaultMessage = "Unavailable Product";

        public UnavailableProductException()
            : base(DefaultMessage)
        {
        }
    }
}
