using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Lab4_ppd1
{
    public class MutexesAndHelper
    {
        public Socket socket = null;

        public const int BUFFER_SIZE = 2048 * 8;

        public byte[] buffer = new byte[BUFFER_SIZE];
        public StringBuilder responseContent = new StringBuilder();

        public int id;

        public string hostname;

        public string endpoint;

        public IPEndPoint remoteEndpoint;

        // mutex for connect
        public ManualResetEvent connectDone = new ManualResetEvent(false);

        // mutex for send
        public ManualResetEvent sendDone = new ManualResetEvent(false);

        // mutex for receive
        public ManualResetEvent receiveDone = new ManualResetEvent(false);
    }
}
