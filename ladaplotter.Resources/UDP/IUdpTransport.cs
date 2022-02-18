using System.Net.Sockets;
using System.Threading.Tasks;

namespace ladaplotter.Resources.UDP
{
    public interface IUdpTransport
    {
        void Close();

        void Open();

        byte[] Receive();

        Task<UdpReceiveResult> ReceiveAsync();

        bool IsOpen { get; }
    }
}
