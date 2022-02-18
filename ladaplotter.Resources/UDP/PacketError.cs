namespace ladaplotter.Resources.UDP
{
    public class PacketError
    {
        public uint BlockId { get; }

        public PackerErrorType ErrorType { get; }

        public string Message { get; }

        public PacketError(uint blockId, PackerErrorType errorType, string message)
        {
            this.BlockId = blockId;
            this.ErrorType = errorType;
            this.Message = message;
        }
    }
}