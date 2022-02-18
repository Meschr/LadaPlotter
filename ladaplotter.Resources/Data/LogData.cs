namespace ladaplotter.Resources.Data
{
    public struct SAccelerationData
    {
        public SAccelerationData(int in_acceleration_x, int in_acceleration_y, int in_acceleration_z)
        {
            acceleration_x = in_acceleration_x;
            acceleration_y = in_acceleration_y;
            acceleration_z = in_acceleration_z;
        }

        private int acceleration_x { get; }
        private int acceleration_y { get; }
        private int acceleration_z { get; }
    }

    internal struct SRotationData
    {
        public SRotationData(int in_rotation_x, int in_rotation_y, int in_rotation_z)
        {
            rotation_x = in_rotation_x;
            rotation_y = in_rotation_y;
            rotation_z = in_rotation_z;
        }

        private int rotation_x { get; }
        private int rotation_y { get; }
        private int rotation_z { get; }
    }

    public struct SLogData
    {
        public SLogData(uint in_index, bool in_marker, double in_pos, int in_adc0 = 0,
            SAccelerationData in_accelerationData = default)
        {
            index = in_index;
            marker = in_marker;
            pos = in_pos;

            // unused
            adc0 = in_adc0;
            acceleration_data = in_accelerationData;
        }

        public uint index { get; }
        public bool marker { get; }
        public double pos { get; }
        public int adc0 { get; }

        private SAccelerationData acceleration_data;
    }
}