using ScottPlot;

namespace ladaplotter.UI.TabElements.DataTab.MeasurementPlots
{
    public interface IMeasurementPlotViewModel
    {
        WpfPlot Plot { get; set; }
    }
}
