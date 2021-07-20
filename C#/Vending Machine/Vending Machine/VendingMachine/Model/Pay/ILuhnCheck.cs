namespace iQuest.VendingMachine.Model.Pay
{
    public interface ILuhnCheck
    {
        bool CardChecking(string cardNumber);
    }
}