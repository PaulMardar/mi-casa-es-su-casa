using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iQuest.CaesarCipher.DataGenerator.Business
{
    public sealed class TcpDataSender : IDataSender
    {
        private readonly IQuoteRepository quoteRepository;
        private DataSenderState state;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private long bytesSentCount;

        public IPAddress IpAddress { get; set; }

        public int Port { get; set; }

        public int Lag { get; set; }

        public long BytesSentCount
        {
            get => bytesSentCount;
            private set
            {
                bytesSentCount = value;
                OnBytesSentCountChanged();
            }
        }

        public DataSenderState State
        {
            get => state;
            private set
            {
                state = value;
                OnStateChanged();
            }
        }

        public event EventHandler<ErrorEventArgs> Error;
        public event EventHandler BytesSentCountChanged;
        public event EventHandler StateChanged;

        public TcpDataSender(IQuoteRepository quoteRepository)
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
            cancellationToken = cancellationTokenSource.Token;

            Task.Run(async () =>
            {
                try
                {
                    using TcpClient tcpClient = new TcpClient();
                    await tcpClient.ConnectAsync(IpAddress, Port);

                    State = DataSenderState.Running;

                    using (NetworkStream stream = tcpClient.GetStream())
                    {
                        SendData(stream);
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    ErrorEventArgs args = new ErrorEventArgs(ex);
                    OnError(args);
                }
                finally
                {
                    State = DataSenderState.Stopped;
                }
            });
        }

        private void SendData(NetworkStream stream)
        {
            while (true)
            {
                string text = quoteRepository.GetOne();
                EncryptedText encryptedText = new EncryptedText(text);
                byte[] bytes = encryptedText.ToBytes(Encoding.UTF8);

                stream.Write(bytes, 0, bytes.Length);
                BytesSentCount += bytes.Length;

                if (Lag > 0)
                    Task.Delay(Lag, cancellationToken).Wait(cancellationToken);
            }
        }

        public void Stop()
        {
            cancellationTokenSource.Cancel();
        }

        public void Dispose()
        {
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnError(ErrorEventArgs e)
        {
            Error?.Invoke(this, e);
        }

        private void OnBytesSentCountChanged()
        {
            BytesSentCountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}