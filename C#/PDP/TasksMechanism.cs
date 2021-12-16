﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_ppd1
{
    public static class TaskMechanism
    {
        private static List<string> HOSTS;

        public static void run(List<string> hostnames)
        {
            HOSTS = hostnames;

            var tasks = new List<Task>();

            for (var i = 0; i < HOSTS.Count; i++)
            {
                tasks.Add(Task.Factory.StartNew(doStart, i));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private static void doStart(object idObject)
        {
            var id = (int)idObject;

            StartClient(HOSTS[id], id);
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
                hostname = host.Split('/')[0],
                endpoint = host.Contains("/") ? host.Substring(host.IndexOf("/")) : "/",
                remoteEndpoint = remoteEndpoint,
                id = id
            };


            ConnectWrapper(state).Wait();
            SendWrapper(state, ParserReq.getRequestString(state.hostname, state.endpoint)).Wait();

            ReceiveWrapper(state).Wait();


            Console.WriteLine(
                "{0}) Response received : expected {1} chars in body, got {2} chars (headers + body)",
                id, ParserReq.getContentLength(state.responseContent.ToString()), state.responseContent.Length);

            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        private static Task ConnectWrapper(MutexesAndHelper state)
        {
            state.socket.BeginConnect(state.remoteEndpoint, ConnectCallback, state);

            return Task.FromResult(state.connectDone.WaitOne());
        }

        private static void ConnectCallback(IAsyncResult ar)
        {

            var state = (MutexesAndHelper)ar.AsyncState;
            var clientSocket = state.socket;
            var clientId = state.id;
            var hostname = state.hostname;
            clientSocket.EndConnect(ar);
            Console.WriteLine("{0} --> Socket connected to {1} ({2})", clientId, hostname, clientSocket.RemoteEndPoint);
            state.connectDone.Set();
        }

        private static Task SendWrapper(MutexesAndHelper state, string data)
        {
            var byteData = Encoding.ASCII.GetBytes(data);
            state.socket.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, state);
            return Task.FromResult(state.sendDone.WaitOne());
        }

        private static void SendCallback(IAsyncResult ar)
        {
            var state = (MutexesAndHelper)ar.AsyncState;
            var clientSocket = state.socket;
            var clientId = state.id;
            var bytesSent = clientSocket.EndSend(ar);
            Console.WriteLine("{0} --> Sent {1} bytes to server.", clientId, bytesSent);

            state.sendDone.Set();
        }

        private static Task ReceiveWrapper(MutexesAndHelper state)
        {
            state.socket.BeginReceive(state.buffer, 0, MutexesAndHelper.BUFFER_SIZE, 0, ReceiveCallback, state);

            return Task.FromResult(state.receiveDone.WaitOne());
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            var state = (MutexesAndHelper)ar.AsyncState;
            var clientSocket = state.socket;

            try
            {
                var bytesRead = clientSocket.EndReceive(ar);
                state.responseContent.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                if (!ParserReq.responseHeaderFullyObtained(state.responseContent.ToString()))
                {
                    clientSocket.BeginReceive(state.buffer, 0, MutexesAndHelper.BUFFER_SIZE, 0, ReceiveCallback, state);
                }
                else
                {
                    var responseBody = ParserReq.getResponseBody(state.responseContent.ToString());
                    Console.Write(responseBody);
                    if (responseBody.Length < ParserReq.getContentLength(state.responseContent.ToString()))
                    {
                        clientSocket.BeginReceive(state.buffer, 0, MutexesAndHelper.BUFFER_SIZE, 0, ReceiveCallback, state);
                    }
                    else
                    {
                        state.receiveDone.Set();
                    }
                    Console.Write(responseBody);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
