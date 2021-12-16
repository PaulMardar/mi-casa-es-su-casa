using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Lab4_ppd1
{
    public static class DirectCallbacks
    {
        private static List<string> urls;

        public static void run(List<string> hostnames)
        {
            urls = hostnames;

            for (var i = 0; i < urls.Count; i++)
            {
                doStart(i);
                Thread.Sleep(5000);
            }
        }

        private static void doStart(object idObject)
        {
            var id = (int)idObject;

            StartClient(urls[id], id);
        }

        private static void StartClient(string host, int id)
        {

            var ipHostInfo = Dns.GetHostEntry(host.Split('/')[2]);
            var ipAddress = ipHostInfo.AddressList[0];
            var remoteEndpoint = new IPEndPoint(ipAddress, ParserReq.HTTP_PORT);

            var client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            var state = new MutexesAndHelper
            {
                socket = client,
                hostname = host.Split('/')[2],
                endpoint = host.Contains("/") ? host.Substring(host.IndexOf("/")) : "/",
                remoteEndpoint = remoteEndpoint,
                id = id
            };

            state.socket.BeginConnect(state.remoteEndpoint, Connected, state);
        }

        private static void Connected(IAsyncResult ar)
        {
            var state = (MutexesAndHelper)ar.AsyncState;
            var clientSocket = state.socket;
            var clientId = state.id;
            var hostname = state.hostname;

            clientSocket.EndConnect(ar);
            Console.WriteLine("{0} --> Socket connected {1} ({2})", clientId, hostname, clientSocket.RemoteEndPoint);

            var byteData = Encoding.ASCII.GetBytes(ParserReq.getRequestString(state.hostname, state.endpoint));

            state.socket.BeginSend(byteData, 0, byteData.Length, 0, Sent, state);
        }

        private static void Sent(IAsyncResult ar)
        {
            var state = (MutexesAndHelper)ar.AsyncState;
            var clientSocket = state.socket;
            var clientId = state.id;
            var bytesSent = clientSocket.EndSend(ar);
            Console.WriteLine("{0} --> Sent {1} bytes to server.", clientId, bytesSent);
            state.socket.BeginReceive(state.buffer, 0, MutexesAndHelper.BUFFER_SIZE, 0, Receiving, state);
        }

        private static void Receiving(IAsyncResult ar)
        {
            var state = (MutexesAndHelper)ar.AsyncState;
            var clientSocket = state.socket;
            var clientId = state.id;

            try
            {
                var bytesRead = clientSocket.EndReceive(ar);
                state.responseContent.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));


                if (!ParserReq.responseHeaderFullyObtained(state.responseContent.ToString()))
                {
                    clientSocket.BeginReceive(state.buffer, 0, MutexesAndHelper.BUFFER_SIZE, 0, Receiving, state);
                }
                else
                {

                    var responseBody = ParserReq.getResponseBody(state.responseContent.ToString());
                    Console.Write(responseBody);

                    var contentLengthHeaderValue = ParserReq.getContentLength(state.responseContent.ToString());
                    if (responseBody.Length < contentLengthHeaderValue)
                    {
                        clientSocket.BeginReceive(state.buffer, 0, MutexesAndHelper.BUFFER_SIZE, 0, Receiving, state);
                    }
                    else
                    {

                        foreach (var i in state.responseContent.ToString().Split('\r', '\n'))
                            Console.WriteLine(i);
                        Console.WriteLine("{0} --> Response received : expected {1} chars in body, got {2} chars (headers + body)",
                            clientId, contentLengthHeaderValue, state.responseContent.Length);

                        clientSocket.Shutdown(SocketShutdown.Both);
                        clientSocket.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
