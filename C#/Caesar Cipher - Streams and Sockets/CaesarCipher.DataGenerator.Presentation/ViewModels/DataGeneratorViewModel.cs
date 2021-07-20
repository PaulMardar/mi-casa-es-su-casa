using System;
using System.IO;
using System.Net;
using iQuest.CaesarCipher.DataGenerator.Business;
using iQuest.CaesarCipher.DataGenerator.Presentation.Commands;
using iQuest.CaesarCipher.PresentationBase.Controls;
using iQuest.CaesarCipher.PresentationBase.ViewModels;

namespace iQuest.CaesarCipher.DataGenerator.Presentation.ViewModels
{
    public class DataGeneratorViewModel : ViewModelBase
    {
        private readonly IDataSender dataSender;
        private string startButtonText;
        private string errorMessage;
        private bool areDataInputFieldsEnabled;
        private long bytesSentCount;
        private LedState ledState;

        public IPAddress IpAddress
        {
            get => dataSender.IpAddress;
            set
            {
                dataSender.IpAddress = value;
                OnPropertyChanged();
            }
        }

        public int Port
        {
            get => dataSender.Port;
            set
            {
                dataSender.Port = value;
                OnPropertyChanged();
            }
        }

        public int Lag
        {
            get => dataSender.Lag;
            set
            {
                dataSender.Lag = value;
                OnPropertyChanged();
            }
        }

        public bool AreDataInputFieldsEnabled
        {
            get => areDataInputFieldsEnabled;
            set
            {
                areDataInputFieldsEnabled = value;
                OnPropertyChanged();
            }
        }

        public string StartButtonText
        {
            get => startButtonText;
            private set
            {
                startButtonText = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public long BytesSentCount
        {
            get => bytesSentCount;
            private set
            {
                bytesSentCount = value;
                OnPropertyChanged();
            }
        }

        public LedState LedState
        {
            get => ledState;
            private set
            {
                ledState = value;
                OnPropertyChanged();
            }
        }

        public StartStopCommand StartStopCommand { get; }

        public DataGeneratorViewModel(IDataSender dataSender)
        {
            this.dataSender = dataSender;

            dataSender.StateChanged += HandleDataSenderStateChanged;
            dataSender.Error += HandleDataSenderError;
            dataSender.BytesSentCountChanged += HandleBytesSentCountChanged;

            StartStopCommand = new StartStopCommand(dataSender);

            BytesSentCount = 0;
            
            UpdateLedState();
            UpdateButtonState();
        }

        private void HandleBytesSentCountChanged(object sender, EventArgs e)
        {
            BytesSentCount = dataSender.BytesSentCount;
        }

        private void HandleDataSenderError(object sender, ErrorEventArgs e)
        {
            Exception exception = e.GetException();
            ErrorMessage = exception?.Message;
        }

        private void HandleDataSenderStateChanged(object sender, EventArgs e)
        {
            if (dataSender.State == DataSenderState.Starting)
                ErrorMessage = null;

            UpdateLedState();
            UpdateButtonState();
        }

        private void UpdateLedState()
        {
            switch (dataSender.State)
            {
                case DataSenderState.Stopped:
                case DataSenderState.Starting:
                case DataSenderState.Stopping:
                    LedState = LedState.Off;
                    break;

                case DataSenderState.Running:
                    LedState = LedState.On;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateButtonState()
        {
            DataSenderState dataSenderState = dataSender.State;

            AreDataInputFieldsEnabled = dataSenderState == DataSenderState.Stopped;

            switch (dataSenderState)
            {
                case DataSenderState.Stopped:
                case DataSenderState.Starting:
                    StartButtonText = "Start";
                    break;

                case DataSenderState.Running:
                case DataSenderState.Stopping:
                    StartButtonText = "Stop";
                    break;

                default:
                    StartButtonText = string.Empty;
                    break;
            }
        }
    }
}