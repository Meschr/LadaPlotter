using System;

namespace ladaplotter.Resources.UDP
{
    public class PacketErrorEventArgs : EventArgs
    {
        public PacketError Error { get; set; }
    }
}