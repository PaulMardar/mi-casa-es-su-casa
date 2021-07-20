using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IMainView
    {
        IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        void DisplayApplicationHeader();
    }
}