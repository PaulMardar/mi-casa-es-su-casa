using iQuest.VendingMachine.Model;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShelfView : DisplayBase
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                DisplayLine(product.ToString(), ConsoleColor.DarkMagenta);
            }
        }
    }
}
