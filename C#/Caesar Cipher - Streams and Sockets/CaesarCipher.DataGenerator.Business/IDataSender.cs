using System;
using System.IO;
using System.Net;

namespace iQuest.CaesarCipher.DataGenerator.Business
{
    public interface IDataSender : IDisposable
    {
        IPAddress IpAddress { get; set; }
        
        int Port { get; set; }
        
        int Lag { get; set; }
        
        DataSenderState State { get; }
        
        long BytesSentCount { get; }

        event EventHandler<ErrorEventArgs> Error;
        event EventHandler StateChanged;
        event EventHandler BytesSentCountChanged;
        
        void Start();
        
        void Stop();
        
        void Dispose();
    }
}