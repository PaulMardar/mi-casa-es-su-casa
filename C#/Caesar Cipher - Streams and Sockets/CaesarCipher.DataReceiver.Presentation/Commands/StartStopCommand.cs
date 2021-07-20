using System;
using System.Windows.Input;
using System.Windows.Threading;
using iQuest.CaesarCipher.DataReceiver.Business;

namespace iQuest.CaesarCipher.DataReceiver.Presentation.Commands
{
    public class StartStopCommand : ICommand
    {
        private readonly DataProcessor dataProcessor;
        private readonly Dispatcher callerDispatcher;

        public event EventHandler CanExecuteChanged;

        public StartStopCommand(DataProcessor dataProcessor)
        {
            this.dataProcessor = dataProcessor ?? throw new ArgumentNullException(nameof(dataProcessor));

            callerDispatcher = Dispatcher.CurrentDispatcher;
            dataProcessor.StateChanged += HandleDataSenderStateChanged;
        }

        private void HandleDataSenderStateChanged(object sender, EventArgs e)
        {
            callerDispatcher.Invoke(OnCanExecuteChanged);
        }

        public bool CanExecute(object parameter)
        {
            DataProcessorState dataSenderState = dataProcessor.State;
            return dataSenderState == DataProcessorState.Stopped || dataSenderState == DataProcessorState.Running;
        }

        public void Execute(object parameter)
        {
            switch (dataProcessor.State)
            {
                case DataProcessorState.Stopped:
                    dataProcessor.Start();
                    break;

                case DataProcessorState.Running:
                    dataProcessor.RequestStop();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
