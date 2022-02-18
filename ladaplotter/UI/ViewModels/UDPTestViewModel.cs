using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Navigation;
using ladaplotter.Resources.Logging;
using ladaplotter.Resources.UDP;

namespace ladaplotter.UI.ViewModels
{
    public class UDPTestViewModel
    {
        private string _stringToSend;
        private UdpCommunication _udpCommunication;

        private static readonly ILogger Logger = Logger<UDPTestViewModel>.Create();

        public UDPTestViewModel()
        {
            _udpCommunication = new UdpCommunication("192.168.1.1", 3333);
        }

        public void SendData()
        {
            if(!String.IsNullOrEmpty(StringToSend))
               _udpCommunication.SendString(StringToSend);
        }

        public String StringToSend
        {
            get => _stringToSend;
            set => _stringToSend = value;
        }
    }
}
