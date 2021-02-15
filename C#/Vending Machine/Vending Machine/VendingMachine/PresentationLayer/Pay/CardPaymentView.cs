using System;

namespace iQuest.VendingMachine.PresentationLayer.Pay
{
    internal class CardPaymentView : DisplayBase
    {
        public string AskForCardNumber()
        {
            DisplayLine("Please provide a valid card number", ConsoleColor.Blue);
            return Console.ReadLine();
        }
    }
}
