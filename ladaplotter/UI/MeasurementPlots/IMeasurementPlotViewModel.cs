using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;

namespace ladaplotter.UI.MeasurementPlots
{
    public interface IMeasurementPlotViewModel
    {
        WpfPlot Plot { get; set; }
    }
}
