namespace iQuest.GrandCircus.Domain
{
  public class Dog : Animal
  {
    private string sound;

    public Dog(string name) : base(name, "Canis familiaris")
    {
      this.sound = "wof";
    }

    public override string MakeSound()
    {
      return this.sound;
    }
  }
}
