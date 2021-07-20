using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using iQuest.CaesarCipher.DataReceiver.Business;
using iQuest.CaesarCipher.DataReceiver.Presentation.Commands;
using iQuest.CaesarCipher.PresentationBase.Controls;
using iQuest.CaesarCipher.PresentationBase.ViewModels;

namespace iQuest.CaesarCipher.DataReceiver.Presentation.ViewModels
{
    public class DataReceiverViewModel : ViewModelBase
    {
        private readonly DataProcessor dataProcessor;
        private string startButtonText;
        private string errorMessage;
        private bool areDataInputFieldsEnabled;
        private string receivedText;
        private readonly ConcurrentQueue<string> receivedData = new ConcurrentQueue<string>();
        private long receivedBytesCount;
        private LedState ledState;

        public IPAddress IpAddress
        {
            get => dataProcessor.IpAddress;
            set
            {
                dataProcessor.IpAddress = value;
                OnPropertyChanged();
            }
        }

        public int Port
        {
            get => dataProcessor.Port;
            set
            {
                dataProcessor.Port = value;
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

        public string ReceivedText
        {
            get => receivedText;
            set
            {
                receivedText = value;
                OnPropertyChanged();
            }
        }

        public long ReceivedBytesCount
        {
            get => receivedBytesCount;
            private set
            {
                receivedBytesCount = value;
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

        public DataReceiverViewModel(DataProcessor dataProcessor)
        {
            this.dataProcessor = dataProcessor;

            dataProcessor.StateChanged += HandleDataSenderStateChanged;
            dataProcessor.Error += HandleDataSenderError;
            dataProcessor.DataReceived += HandleDataReceived;
            dataProcessor.ReceivedCharsChanged += HandleReceivedCharsChanged;

            StartStopCommand = new StartStopCommand(dataProcessor);

            UpdateLedState();
            UpdateButtonState();
        }

        private void HandleReceivedCharsChanged(object sender, EventArgs e)
        {
            ReceivedBytesCount = dataProcessor.ReceivedBytesCount;
        }

        private void HandleDataSenderError(object sender, ErrorEventArgs e)
        {
            Exception exception = e.GetException();
            ErrorMessage = exception?.Message;
        }

        private void HandleDataSenderStateChanged(object sender, EventArgs e)
        {
            if (dataProcessor.State == DataProcessorState.Starting)
                ErrorMessage = null;

            UpdateLedState();
            UpdateButtonState();
        }

        private void UpdateLedState()
        {
            switch (dataProcessor.State)
            {
                case DataProcessorState.Stopped:
                case DataProcessorState.Starting:
                case DataProcessorState.Stopping:
                    LedState = LedState.Off;
                    break;
                
                case DataProcessorState.Running:
                    LedState = LedState.On;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateButtonState()
        {
            DataProcessorState dataProcessorState = dataProcessor.State;

            AreDataInputFieldsEnabled = dataProcessorState == DataProcessorState.Stopped;

            switch (dataProcessorState)
            {
                case DataProcessorState.Stopped:
                case DataProcessorState.Starting:
                    StartButtonText = "Start";
                    break;

                case DataProcessorState.Running:
                case DataProcessorState.Stopping:
                    StartButtonText = "Stop";
                    break;

                default:
                    StartButtonText = string.Empty;
                    break;
            }
        }

        private void HandleDataReceived(object sender, DataReceivedEventArgs e)
        {
            receivedData.Enqueue(e.Data);

            if (receivedData.Count > 50)
                receivedData.TryDequeue(out _);

            ReceivedText = string.Join(Environment.NewLine, receivedData.Reverse());
        }
    }
}