using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace iQuest.CaesarCipher.DataGenerator.Business
{
    public sealed class SocketDataSender : IDataSender
    {
        private readonly IQuoteRepository quoteRepository;
        private Socket socket;
        private DataSenderState state;
        private readonly ManualResetEventSlim idleIndicator = new ManualResetEventSlim(true);
        private CancellationTokenSource cancellationTokenSource;

        public IPAddress IpAddress { get; set; }

        public int Port { get; set; }

        public int Lag { get; set; }

        public DataSenderState State
        {
            get => state;
            private set
            {
                state = value;
                OnStateChanged();
            }
        }

        public long BytesSentCount { get; }

        public event EventHandler<DataSenderErrorEventArgs> ConnectionError;
        public event EventHandler<DataSenderErrorEventArgs> SendError;
        public event EventHandler StateChanged;
        public event EventHandler BytesSentCountChanged;

        public SocketDataSender(IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));

            State = DataSenderState.Stopped;
        }

        public void Start()
        {
            if (State != DataSenderState.Stopped)
                throw new Exception("Already running.");

            if (IpAddress == null) throw new Exception("IpAddress value was not set.");
            if (Port == 0) throw new Exception("Port was not set.");

            State = DataSenderState.Starting;

            cancellationTokenSource = new CancellationTokenSource();

            socket = new Socket(IpAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            {
                ReceiveTimeout = 20000,
                SendTimeout = 20000
            };

            IPEndPoint ipEndPoint = new IPEndPoint(IpAddress, Port);
            socket.BeginConnect(ipEndPoint, ConnectCallback, socket);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;

            try
            {
                client.EndConnect(ar);
                State = DataSenderState.Running;
            }
            catch (Exception ex)
            {
                DataSenderErrorEventArgs args = new DataSenderErrorEventArgs(ex);
                OnConnectionError(args);

                State = DataSenderState.Stopped;

                return;
            }

            SendData(client);
        }

        private void SendData(Socket client)
        {
            if (cancellationTokenSource.IsCancellationRequested)
                return;

            idleIndicator.Reset();

            string chunk = quoteRepository.GetOne();

            byte[] byteData = Encoding.ASCII.GetBytes(chunk);
            client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);
        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;

            try
            {
                client.EndSend(ar);

                idleIndicator.Set();

                if (cancellationTokenSource.IsCancellationRequested)
                    return;

                if (Lag > 0)
                    Thread.Sleep(Lag);

                SendData(client);
            }
            catch (Exception ex)
            {
                idleIndicator.Set();

                DataSenderErrorEventArgs args = new DataSenderErrorEventArgs(ex);
                OnSendError(args);

                client.Disconnect(true);

                State = DataSenderState.Stopped;
            }
        }

        public void Stop()
        {
            if (State != DataSenderState.Running)
                return;

            cancellationTokenSource.Cancel();

            idleIndicator.WaitHandle.WaitOne();

            socket.Disconnect(true);

            State = DataSenderState.Stopped;
        }

        public void Dispose()
        {
            socket?.Dispose();
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnConnectionError(DataSenderErrorEventArgs e)
        {
            ConnectionError?.Invoke(this, e);
        }

        private void OnSendError(DataSenderErrorEventArgs e)
        {
            SendError?.Invoke(this, e);
        }
    }
}
