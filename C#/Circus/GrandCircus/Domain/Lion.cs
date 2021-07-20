namespace iQuest.GrandCircus.Domain
{
  public class Lion : Animal
  {
    private string sound;

    public Lion(string name) : base(name, "Felis Panthera leo")
    {
      this.sound = "ROOOWW!";
    }

    public override string MakeSound()
    {
      return this.sound;
    }
  }
}
