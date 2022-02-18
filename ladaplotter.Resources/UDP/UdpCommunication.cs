using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ladaplotter.Resources.UDP
{
    public class UdpCommunication
    {
        public event EventHandler<Datagram> DatagramReceived; 

        private UdpTransport _udpTransport;

        public UdpCommunication(string ip, int port)
        {
            _udpTransport = new UdpTransport(ip, port);
            _udpTransport.Open();
        }

        private void StartClient()
        {
            new Thread(() =>
            {
               var result =  _udpTransport.ReceiveAsync().Result;
               DatagramReceived?.Invoke(this, new Datagram(result.RemoteEndPoint, result.Buffer));
            }).Start();
        }
        public void SendString(String s)
        {
            if (_udpTransport.IsOpen)
                _udpTransport.Send(Encoding.ASCII.GetBytes(s));
        }
        public void SendTest()
        {
            if (_udpTransport.IsOpen)
                _udpTransport.Send(BitConverter.GetBytes((int) UdpCommands.Test));
        }
    }
}
