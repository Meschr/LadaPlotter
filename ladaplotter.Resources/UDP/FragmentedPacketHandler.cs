using System;
using System.Collections.Generic;
using System.Linq;

namespace ladaplotter.Resources.UDP
{
    internal class FragmentedPacketHandler
    {
        private readonly int _consecutiveFrameCount;
        private readonly Dictionary<int, byte[]> _frames = new Dictionary<int, byte[]>();
        private readonly DateTime _timestamp = DateTime.Now;

        public FragmentedPacketHandler(byte[] frame)
        {
            this.BlockId = BitConverter.ToUInt32(frame, 0);
            this._consecutiveFrameCount = (int) BitConverter.ToUInt16(frame, 6) - 1;
            this._frames.Add(0, ((IEnumerable<byte>) frame).Skip<byte>(8).ToArray<byte>());
        }

        public uint BlockId { get; }

        public bool Complete => this._frames.Count == this._consecutiveFrameCount;

        public bool TimedOut =>
            DateTime.Now.Subtract(this._timestamp) > TimeSpan.FromMilliseconds((double) this.Timeout);

        public int Timeout { get; set; } = 1000;

        public byte[] Data
        {
            get
            {
                List<byte> byteList = new List<byte>();
                for (int key = 0; key <= this._consecutiveFrameCount; ++key)
                    byteList.AddRange((IEnumerable<byte>) this._frames[key]);
                return byteList.ToArray();
            }
        }

        public bool ProcessConsecutiveFrame(byte[] frame)
        {
            if ((int) BitConverter.ToUInt32(frame, 0) != (int) this.BlockId)
                return false;
            int uint16 = (int) BitConverter.ToUInt16(frame, 6);
            if (!this._frames.ContainsKey(uint16))
                this._frames.Add(uint16, ((IEnumerable<byte>) frame).Skip<byte>(8).ToArray<byte>());
            return this._frames.Count >= this._consecutiveFrameCount + 1 && this.CheckPacketNumbers();
        }

        private bool CheckPacketNumbers()
        {
            bool flag = true;
            for (int key = 0; key <= this._consecutiveFrameCount; ++key)
            {
                if (!this._frames.ContainsKey(key))
                    flag = false;
            }

            return flag;
        }
    }
}