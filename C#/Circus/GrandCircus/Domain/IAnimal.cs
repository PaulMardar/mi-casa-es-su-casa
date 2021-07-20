namespace iQuest.GrandCircus.Domain
{
  public interface IAnimal
  {
    public string Name { get; }
    public string Speciesname { get; }

    string MakeSound();
  }
}
