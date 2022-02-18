using System;
using System.Collections.Generic;
using System.Text;

namespace ladaplotter.Resources.Data
{
    public class VelocityMeasurement : IMeasurement
    {
        public VelocityMeasurement(List<double> values, int samplingRate, String unit)
        {
            Values = values;
            SamplingRate = samplingRate;
            Unit = unit;
            Plotable = true;
        }
        public List<double> Values { get; set; }
        public int SamplingRate { get; set; }
        public bool Plotable { get; set; }
        public string Unit { get; set; }
    }
}
