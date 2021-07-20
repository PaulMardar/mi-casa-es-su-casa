namespace iQuest.GrandCircus.Domain
{
  public class Cat : Animal
  {
    private string sound;

    public Cat(string name) : base(name, "Felis catus")
    {
      this.sound = "mew";
    }

    public override string MakeSound()
    {
      return this.sound;
    }
  }
}


