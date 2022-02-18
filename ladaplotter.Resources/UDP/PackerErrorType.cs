namespace ladaplotter.Resources.UDP
{
    public enum PackerErrorType
    {
        PacketLost,
        PacketOutOfSequence,
        PacketDuplicateReceived,
        MultiframePacketTimeOut,
        InvalidPacketReceived,
        PacketContentEmpty,
        InvalidContentSize,
        UnknownError
    }
}