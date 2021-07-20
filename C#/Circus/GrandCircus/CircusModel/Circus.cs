using iQuest.GrandCircus.Presentation;
using iQuest.GrandCircus.Domain;
using System.Collections.Generic;

namespace iQuest.GrandCircus.CircusModel
{
  internal class Circus
  {
    private readonly Arena _arena;
    private readonly string _circusName;
    private readonly List<IAnimal> _animalList;

    public Circus(Arena arena, string circusName)
    {
      this._arena = arena;
      this._circusName = circusName;

      _animalList = new List<IAnimal>
      {
        new Dog("Rufus"),
        new Lion("Simba"),
        new Cat("Marie"),
        new Cat("Ducesa"),
      };
    }

    public void Perform()
    {
      this._arena.PresentCircus(this._circusName);
      foreach (var animal in _animalList)
      {
        this._arena.AnnounceAnimal(animal.Name, animal.Speciesname);
        this._arena.DisplayAnimalPerformance(animal.MakeSound());
      }
    }
  }
}