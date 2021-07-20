using System.Configuration;
using System.Net;

namespace iQuest.CaesarCipher.DataGenerator
{
    internal static class DataGeneratorConfiguration
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
                    ? 13001
                    : int.Parse(rawValue);
            }
        }

        public static int Lag
        {
            get
            {
                string rawValue = ConfigurationManager.AppSettings["Lag"];
                return rawValue == null
                    ? 300
                    : int.Parse(rawValue);
            }
        }
    }
}