using System;
using System.Windows.Input;
using System.Windows.Threading;
using iQuest.CaesarCipher.DataGenerator.Business;

namespace iQuest.CaesarCipher.DataGenerator.Presentation.Commands
{
    public class StartStopCommand : ICommand
    {
        private readonly IDataSender dataSender;
        private readonly Dispatcher callerDispatcher;

        public event EventHandler CanExecuteChanged;

        public StartStopCommand(IDataSender dataSender)
        {
            this.dataSender = dataSender ?? throw new ArgumentNullException(nameof(dataSender));

            callerDispatcher = Dispatcher.CurrentDispatcher;
            dataSender.StateChanged += HandleDataSenderStateChanged;
        }

        private void HandleDataSenderStateChanged(object sender, EventArgs e)
        {
            callerDispatcher.Invoke(OnCanExecuteChanged);
        }

        public bool CanExecute(object parameter)
        {
            DataSenderState dataSenderState = dataSender.State;
            return dataSenderState == DataSenderState.Stopped || dataSenderState == DataSenderState.Running;
        }

        public void Execute(object parameter)
        {
            switch (dataSender.State)
            {
                case DataSenderState.Stopped:
                    dataSender.Start();
                    break;

                case DataSenderState.Running:
                    dataSender.Stop();
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
