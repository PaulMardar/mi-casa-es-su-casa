namespace iQuest.VendingMachine.Model.Pay
{
    public class LuhnCheck
    {
        public bool CardChecking(string cardNumber)
        {
            int nDigits = cardNumber.Length;
            int sumNumbers = 0;
            bool isEven = false;

            for (int i = nDigits - 1; i >= 0; i--)
            {
                int digit = cardNumber[i] - '0';
                if (isEven == true)
                    digit = digit * 2;

                sumNumbers += digit / 10;
                sumNumbers += digit % 10;

                isEven = !isEven;
            }

            return (sumNumbers % 10 == 0);
        }
    }
}
