using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ladaplotter.Resources.UDP
{
    /// <summary>
    /// Creates a UDP Client and Server 
    /// </summary>
    public class UdpTransport
    {
        private int _maxDatagramSize;
        private IPEndPoint _localeEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private IPAddress _ipAddress;
        private UdpClient _udpClient;
        private Socket _socket;

        /// <summary>
        /// Maximum datagram size, must be greater than zero and less/equal to 65507 
        ///  (source https://stackoverflow.com/a/1098940)
        /// </summary>
        public int MaxDatagramSize
        {
            get => _maxDatagramSize;
            set
            {
                if (value < 1 || value > 65507)
                    throw new ArgumentException("MaxDatagramSize must be greater than zero and less/equal to 65507");

                _maxDatagramSize = value;
            }
        }

        public UdpTransport(string ip, int port)
        {
            if (String.IsNullOrEmpty(ip)) 
                throw new ArgumentNullException(nameof(ip));
            if (port < 0 || port > 65535)
                throw new ArgumentException("Port must be greater/equal to zero an less/equal to 65535");

            Ip = ip;
            Port = port;
            _ipAddress= IPAddress.Parse(Ip);

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _socket.SetSocketOption(SocketOptionLevel.IP,SocketOptionName.ReuseAddress,true);
            _socket.Bind(_localeEndPoint);

        }

        public string Ip { get; }

        public int Port { get; }

        public bool IsOpen => _udpClient != null;

        public void Open()
        {
            if (_udpClient != null)
                return;

            _udpClient = new UdpClient();
            _udpClient.Client.ReceiveTimeout = 1000;

            try
            {
                _udpClient.Connect(_localeEndPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Send a datagram to the specific IP adress and UDP port.
        /// This will throw a SocketException if the report UDP port is unreachable.
        /// </summary>
        /// <param name="ip">IP address</param>
        /// <param name="port"> port</param>
        /// <param name="text">text to send</param>
        public void SendString(string ip, int port, string text)
        {
            if (String.IsNullOrEmpty(ip)) throw new ArgumentNullException(nameof(ip));
            if (port < 0 || port > 65535) throw new ArgumentException("port is out of range (0-65535");
            if (String.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));

            byte[] data = Encoding.UTF8.GetBytes(text);

            if(data.Length > _maxDatagramSize) 
                throw new ArgumentException("Data exceed maximum datagram size ("+ data.Length + "data bytes," + _maxDatagramSize + "bytes).");
        }


        public async Task<UdpReceiveResult> ReceiveAsync()
        {
            return await _udpClient.ReceiveAsync();
        }

        public byte[] Receive()
        {
            return _udpClient.Receive(ref _localeEndPoint);
        }

        public void Send(byte[] data)
        {
            //_udpClient.Send(data,data.Length);
        }

        public async Task<int> SendAsync(byte[] data)
        {
            return await _udpClient.SendAsync(data, data.Length);
        }

        public void Close()
        {
            _udpClient?.Close();
            _udpClient = null;
        }
    }
}