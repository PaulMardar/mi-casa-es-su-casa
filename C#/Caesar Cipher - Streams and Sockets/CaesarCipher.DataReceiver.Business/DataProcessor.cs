using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iQuest.CaesarCipher.DataReceiver.Business
{
    public class DataProcessor
    {
        private DataProcessorState state;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private long receivedBytesCount;
        private TcpListener tcpListener;

        public IPAddress IpAddress { get; set; }

        public int Port { get; set; }

        public DataProcessorState State
        {
            get => state;
            private set
            {
                state = value;
                OnStateChanged();
            }
        }

        public long ReceivedBytesCount
        {
            get => receivedBytesCount;
            set
            {
                receivedBytesCount = value;
                OnReceivedCharsChanged();
            }
        }

        public event EventHandler StateChanged;
        public event EventHandler<ErrorEventArgs> Error;
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        public event EventHandler ReceivedCharsChanged;

        public void Start()
        {
            if (State != DataProcessorState.Stopped) throw new Exception("Already running.");
            if (IpAddress == null) throw new Exception("IpAddress value was not set.");
            if (Port == 0) throw new Exception("Port was not set.");

            State = DataProcessorState.Starting;

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            Task.Run(async () =>
            {
                if (tcpListener != null)
                {
                    tcpListener.Stop();
                    tcpListener = null;
                }

                IPEndPoint ipEndPoint = new IPEndPoint(IpAddress, Port);
                tcpListener = new TcpListener(ipEndPoint);

                try
                {
                    tcpListener.Start();

                    State = DataProcessorState.Running;

                    while (true)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        TcpClient tcpClient = await tcpListener.GetTcpClient(cancellationToken);

                        if (tcpClient == null)
                            continue;

                        _ = Task.Run(async () => await ReceiveData(tcpClient), cancellationToken);
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    OnError(new ErrorEventArgs(ex));
                }
                finally
                {
                    State = DataProcessorState.Stopped;
                }
            });
        }

        public async Task ReceiveData(TcpClient tcpClient)
        {
            await using NetworkStream stream = tcpClient.GetStream();

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                byte[] buffer = new byte[10240];

                int readCount = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);

                if (readCount == 0)
                {
                    await Task.Delay(100, cancellationToken);
                    continue;
                }

                string data = Encoding.UTF8.GetString(buffer);

                ReceivedBytesCount += readCount;

                DataReceivedEventArgs args = new DataReceivedEventArgs(data);
                OnDataReceived(args);
            }
        }

        public void RequestStop()
        {
            if (State != DataProcessorState.Running)
                return;

            cancellationTokenSource.Cancel();
        }

        protected virtual void OnStateChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDataReceived(DataReceivedEventArgs e)
        {
            DataReceived?.Invoke(this, e);
        }

        protected virtual void OnError(ErrorEventArgs e)
        {
            Error?.Invoke(this, e);
        }

        protected virtual void OnReceivedCharsChanged()
        {
            ReceivedCharsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}