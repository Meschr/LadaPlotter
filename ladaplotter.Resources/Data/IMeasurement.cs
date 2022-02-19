using System;
using System.Collections.Generic;
using System.Text;

namespace ladaplotter.Resources.Data
{
    public interface IMeasurement
    {
        double[] Values { get; set; }

        string Name { get; }
        int SamplingRate { get; }
        bool Plotable { get; set; }
        String Unit { get; }
    }
}