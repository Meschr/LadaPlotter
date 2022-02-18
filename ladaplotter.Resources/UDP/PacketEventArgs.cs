using System;

namespace ladaplotter.Resources.UDP
{
    public class PacketEventArgs : EventArgs
    {
        public uint BlockId { get; set; }

        public byte[] Data { get; set; }
    }
}