using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ladaplotter.Resources.Data
{
    public class PositionMeasurement : IMeasurement
    {
        public PositionMeasurement(double[] values, int samplingRate)
        {
            Values = values;
            Name = "Position";
            SamplingRate = samplingRate;
            Unit = "mm";
            Plotable = true; 
        }
        public double[] Values { get; set; }
        public string Name { get; }
        public int SamplingRate { get; }
        public bool Plotable { get; set; }
        public string Unit { get; }
    }
}