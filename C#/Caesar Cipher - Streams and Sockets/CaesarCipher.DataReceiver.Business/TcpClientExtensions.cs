using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace iQuest.CaesarCipher.DataReceiver.Business
{
    internal static class TcpClientExtensions
    {
        public static async Task<TcpClient> GetTcpClient(this TcpListener listener, CancellationToken token)
        {
            await using (token.Register(listener.Stop))
            {
                try
                {
                    return await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                }
                catch (ObjectDisposedException)
                {
                    // Token was canceled - swallow the exception and return null
                    if (token.IsCancellationRequested)
                        return null;

                    throw;
                }
            }
        }
    }
}