using System;

namespace iQuest.CaesarCipher.DataReceiver.Business
{
    public class DataReceivedEventArgs : EventArgs
    {
        public string Data { get; }

        public DataReceivedEventArgs(string data)
        {
            Data = data;
        }
    }
}