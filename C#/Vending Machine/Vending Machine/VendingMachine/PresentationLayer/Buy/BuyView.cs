using iQuest.VendingMachine.Model;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        public int GetProductId()
        {
            DisplayLine("Provide the id please:", ConsoleColor.White);
            return Int32.Parse(Console.ReadLine());
        }

        public void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                DisplayLine(product.ToString(), ConsoleColor.DarkMagenta);
            }
        }

        public bool ConfirmTransaction()
        {
            DisplayLine("enter 'no' to cancel the current transaction or 'yes' to continue.", ConsoleColor.Red);
            if (Console.ReadLine() == "no")
                return false;
            return true;
        }

        public int? AskForPaymentMethod(IEnumerable<IPaymentMethod> payMethods)
        {
            foreach (var payment in payMethods)
            {
                DisplayLine("id : " + payment.Id + " " + payment.Name, ConsoleColor.White);
            }

            return int.TryParse(Console.ReadLine(), out var number) ? number : (int?)null;
        }
    }
}
