using System;

namespace Lab4_ppd1
{
    public class ParserReq
    {
        public static readonly int HTTP_PORT = 80;

        public static string getResponseBody(string responseContent)
        {
            var responseParts = responseContent.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            return responseParts.Length > 1 ? responseParts[1] : "";
        }

        public static bool responseHeaderFullyObtained(string responseContent)
        {
            return responseContent.Contains("\r\n\r\n");
        }

        public static int getContentLength(string responseContent)
        {
            var contentLength = 0;
            var responseLines = responseContent.Split('\r', '\n');

            foreach (var responseLine in responseLines)
            {

                var headerDetails = responseLine.Split(':');

                if (headerDetails[0].CompareTo("Content-Length") == 0)
                {
                    contentLength = int.Parse(headerDetails[1]);
                }
            }

            return contentLength;
        }

        public static string getRequestString(string hostname, string endpoint)
        {
            return "GET " + endpoint + " HTTP/1.1\r\n" +
"Host: " + hostname + "\r\n" +
"Content-Length: 0\r\n\r\n";
        }
    }
}
