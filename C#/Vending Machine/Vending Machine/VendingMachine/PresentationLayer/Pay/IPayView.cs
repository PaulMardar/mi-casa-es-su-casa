namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IPayView
    {
        public float PayMethod(float productPrice);

        public void GiveChange(float change);
    }
}
