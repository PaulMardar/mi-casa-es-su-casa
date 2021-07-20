using System.Configuration;
using System.Net;

namespace iQuest.CaesarCipher.DataReceiver
{
    internal static class DataReceiverConfiguration
    {
        public static IPAddress IpAddress
        {
            get
            {
                string rawValue = ConfigurationManager.AppSettings["IpAddress"];
                return rawValue == null
                    ? IPAddress.Loopback
                    : IPAddress.Parse(rawValue);
            }
        }

        public static int Port
        {
            get
            {
                string rawValue = ConfigurationManager.AppSettings["Port"];
                return rawValue == null
                    ? 13002
                    : int.Parse(rawValue);
            }
        }
    }
}