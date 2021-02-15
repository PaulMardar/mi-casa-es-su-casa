using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer.Pay
{
    public class CashPaymentView
    {
        static private Dictionary<string, Func<int, float>> currencies = new Dictionary<string, Func<int, float>>()
        {
            ["coins"] = ammount => (float)ammount / 100,
            ["banknotes"] = ammount => (float)ammount,
        };
        public float AskForMoney()
        {
            float totalCash = 0;
            Console.WriteLine("you can pres done to finish the procces! pres enter to continue");

            while (true)
            {
                Console.WriteLine("coins OR banknotes ", ConsoleColor.Blue);
                Console.WriteLine("Current credit is: " + totalCash);
                var currency = Console.ReadLine();

                if (currency == "done")
                {
                    break;
                }
                if (!currencies.TryGetValue(currency, out var formula))
                {
                    Console.WriteLine("Not a valid type of currency");
                    continue;
                }
                Console.WriteLine("Enter the value of " + currency, ConsoleColor.Blue);
                if (!int.TryParse(Console.ReadLine(), out var ammount))
                {
                    Console.WriteLine("The ammount is not a valid number");
                    continue;
                }

                totalCash += formula(ammount);
            }
            return totalCash;
        }

        public void GiveBackChange(float change)
        {
            Console.WriteLine("the change is " + change);
        }
    }
}

