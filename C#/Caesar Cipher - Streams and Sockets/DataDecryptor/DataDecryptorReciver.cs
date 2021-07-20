using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;

namespace DataDecryptor
{

    public class DataDecryptorReciver
    {
        Decryptor module = new Decryptor();

        DataDecryptorSender sender = new DataDecryptorSender();

        public void Recive()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 13001;
                var ip = ConfigurationManager.ConnectionStrings["serverIp"].ConnectionString;
                IPAddress localAddr = IPAddress.Parse(ip);

                server = new TcpListener(localAddr, port);

                server.Start();

                Byte[] bytes = new Byte[2048];
                String data = null;

                while (true)
                {
                    Console.Write("Waiting for a connection... ");


                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    NetworkStream stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {

                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        data = module.decryptCesarCodeBasic(data);

                        sender.Send(data);
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        Console.WriteLine("Sent: {0}", data);
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
        }
    }
}

