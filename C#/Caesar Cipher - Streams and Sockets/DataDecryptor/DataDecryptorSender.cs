using System;
using System.Configuration;
using System.Net.Sockets;
namespace DataDecryptor
{
    public class DataDecryptorSender
    {
        public void Send(String message)
        {
            try
            {
                Int32 port = 13002;
                var ip = ConfigurationManager.ConnectionStrings["serverIp"].ConnectionString;
                TcpClient client = new TcpClient(ip, port);

                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                data = new Byte[2048];

                String responseData = String.Empty;
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }

}
