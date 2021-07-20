namespace iQuest.GrandCircus.Domain
{
  public abstract class Animal : IAnimal
  {
    public string Name { get; }
    public string Speciesname { get; }

    public Animal(string name, string speciesName)
    {
      this.Name = name;
      this.Speciesname = speciesName;
    }
    public abstract string MakeSound();
  }
}
