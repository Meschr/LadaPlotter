using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ladaplotter.Resources.Data
{
    public class PositionMeasurement : IMeasurement
    {
        public PositionMeasurement(List<double> values, int samplingRate, String unit)
        {
            //eventuell hier noch datenvorverarbeitung 
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