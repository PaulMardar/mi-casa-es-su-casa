using System;
namespace iQuest.GrandCircus.Presentation
{
  internal class Arena
  {

    public void PresentCircus(string circusName)
    {
      Console.WriteLine("This is the {0} !", circusName);
      Console.WriteLine(new string('=', 79));
    }
    public void AnnounceAnimal(string animalName, string animalSpecies)
    {
      Console.WriteLine();
      Console.WriteLine("Next will perform {0}. It is a {1}:", animalName, animalSpecies);
    }
    public void DisplayAnimalPerformance(string performance)
    {
      Console.WriteLine("-> {0}", performance);
    }
  }
}