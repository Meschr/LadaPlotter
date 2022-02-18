using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ladaplotter.Resources.Logging;

namespace ladaplotter.Resources.UDP
{
    public class Datagram
    {
        public string Ip { get; }
        public int Port { get; }
        public byte[] Data { get; }
        
        internal Datagram()
        {
            
        }

        internal Datagram(string ip, int port, byte[] data)
        {
            if (String.IsNullOrEmpty(ip)) throw new ArgumentNullException(nameof(ip));
            if (port < 0 || port > 65535)
                throw new ArgumentException("Port must be greater/equal to zero and less/equal to 65535");
            Ip = ip;
            Port = port;
            Data = data;
        }

        internal Datagram(IPEndPoint ipEndPoint, byte[] data)
        {
            Ip = ipEndPoint.Address.ToString();
            Port = ipEndPoint.Port;
            Data = data;
        }
    }
}
