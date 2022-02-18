using System;
using System.Collections.Generic;
using System.Text;

namespace ladaplotter.Resources.Data
{
    public interface IMeasurement
    {
        List<double> Values { get; set; }
        int SamplingRate { get; }
        bool Plotable { get; set; }
        String Unit { get; set; }
    }
}