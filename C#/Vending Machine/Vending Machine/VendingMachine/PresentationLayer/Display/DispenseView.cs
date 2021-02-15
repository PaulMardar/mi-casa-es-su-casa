using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class DispenseView : DisplayBase
    {
        public void DispenseProduct(string productName)
        {
            DisplayLine("you got a " + productName.ToString(), ConsoleColor.Green);
        }
    }
}
