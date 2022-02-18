using System;
using System.Collections.Generic;
using System.Linq;

namespace ladaplotter.Resources.UDP
{
    internal class UdpStreamingProtocol
    {
        private static readonly byte SingleFrameIdentifier = 0;
        private static readonly byte FirstFrameIdentifier = 1;
        private static readonly byte ConsecutiveFrameIdentifier = 2;
        private readonly List<FragmentedPacketHandler> _fragmentedPacketHandlers = new List<FragmentedPacketHandler>();
        private bool _first = true;
        private uint _lastBlockId = uint.MaxValue;

        public void ProcessDatagram(byte[] data)
        {
            if (data == null)
            {
                OnPacketError(new PacketErrorEventArgs
                {
                    Error = new PacketError(0U, PackerErrorType.InvalidPacketReceived, "Packet is null.")
                });
            }
            else if (data.Length < 8)
            {
                OnPacketError(new PacketErrorEventArgs
                {
                    Error = new PacketError(0U, PackerErrorType.InvalidPacketReceived,
                        string.Format("Packet size is {0} bytes.", data.Length))
                });
            }
            else
            {
                if (data[4] == SingleFrameIdentifier)
                {
                    PopulateBlock(BitConverter.ToUInt32(data, 0), data.Skip(8).ToArray());
                }
                else if (data[4] == FirstFrameIdentifier)
                {
                    _fragmentedPacketHandlers.Add(new FragmentedPacketHandler(data));
                }
                else if (data[4] == ConsecutiveFrameIdentifier)
                {
                    var blockId = BitConverter.ToUInt32(data, 0);
                    var fragmentedPacketHandler =
                        _fragmentedPacketHandlers.FirstOrDefault(fph => (int) fph.BlockId == (int) blockId);
                    if (fragmentedPacketHandler != null && fragmentedPacketHandler.ProcessConsecutiveFrame(data))
                    {
                        PopulateBlock(fragmentedPacketHandler.BlockId, fragmentedPacketHandler.Data);
                        _fragmentedPacketHandlers.Remove(fragmentedPacketHandler);
                    }
                }

                foreach (var fragmentedPacketHandler in _fragmentedPacketHandlers.Where(fph => fph.TimedOut))
                    OnPacketError(new PacketErrorEventArgs
                    {
                        Error = new PacketError(fragmentedPacketHandler.BlockId,
                            PackerErrorType.MultiframePacketTimeOut,
                            string.Format("Didn't receive all consecutive frames within {0} ms.",
                                fragmentedPacketHandler.Timeout))
                    });
                _fragmentedPacketHandlers.RemoveAll(fph => fph.TimedOut);
            }
        }

        private void PopulateBlock(uint blockId, byte[] data)
        {
            CheckBlockSequence(blockId);
            OnPacketReceived(new PacketEventArgs
            {
                BlockId = blockId,
                Data = data
            });
        }

        private void CheckBlockSequence(uint blockId)
        {
            if (_first)
            {
                _first = false;
                _lastBlockId = blockId;
            }
            else
            {
                var num = _lastBlockId + 1U;
                if ((int) blockId == (int) num)
                {
                    _lastBlockId = blockId;
                }
                else if ((int) blockId == (int) _lastBlockId)
                {
                    OnPacketError(new PacketErrorEventArgs
                    {
                        Error = new PacketError(blockId, PackerErrorType.PacketDuplicateReceived,
                            string.Format("Received packet with blockid {0} twice.", _lastBlockId))
                    });
                }
                else if (blockId > num)
                {
                    OnPacketError(new PacketErrorEventArgs
                    {
                        Error = new PacketError(blockId, PackerErrorType.PacketLost,
                            string.Format("One or more packets lost: Last received blockid was {0}, received {1}.",
                                _lastBlockId, blockId))
                    });
                    _lastBlockId = blockId;
                }
                else
                {
                    if (blockId >= _lastBlockId)
                        return;
                    OnPacketError(new PacketErrorEventArgs
                    {
                        Error = new PacketError(blockId, PackerErrorType.PacketOutOfSequence,
                            string.Format("Received packet with blockid {0}, expected {1}.", blockId, num))
                    });
                }
            }
        }

        public event EventHandler<PacketEventArgs> PacketReceived;

        public event EventHandler<PacketErrorEventArgs> PacketError;

        private void OnPacketReceived(PacketEventArgs e)
        {
            var packetReceived = PacketReceived;
            if (packetReceived == null)
                return;
            packetReceived(this, e);
        }

        private void OnPacketError(PacketErrorEventArgs e)
        {
            var packetError = PacketError;
            if (packetError == null)
                return;
            packetError(this, e);
        }
    }
}