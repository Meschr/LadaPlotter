using System;
using System.Collections.Generic;
using System.Text;

namespace ladaplotter.Resources.Data
{
    public class AccelerationMeasurement : IMeasurement
    {
        public AccelerationMeasurement(double[] values, int samplingRate)
        {
            Values = values;
            Name = "Acceleration";
            SamplingRate = samplingRate;
            Unit = "m/s^2";
            Plotable = true;
        }

        public double[] Values { get; set; }
        public string Name { get; }
        public int SamplingRate { get; }
        public bool Plotable { get; set; }
        public string Unit { get; }
    }
}
