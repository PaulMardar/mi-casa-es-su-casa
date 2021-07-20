namespace iQuest.VendingMachine.PresentationLayer.Pay
{
    public interface ICashPaymentView
    {
        float AskForMoney();
        void GiveBackChange(float change);
    }
}