using System;
using System.Drawing;
using System.Linq;
using ladaplotter.Resources.Data;
using ScottPlot;

namespace ladaplotter.UI.TabElements.DataTab.MeasurementPlots
{
    public class PositionMeasurementPlotViewModel : IMeasurementPlotViewModel
    {
        private PositionMeasurement _positionMeasurement;

        private WpfPlot _plot;

        public PositionMeasurementPlotViewModel(PositionMeasurement measurement)
        {
            _positionMeasurement = measurement;
            Plot = new WpfPlot();

            if(measurement != null)
                InitPlotWithValues();
        }

        public WpfPlot Plot 
        {
            get => _plot;
            set
            {
                _plot = value;
                InitPlotWithoutValues();
            }
        }

        private void InitPlotWithoutValues()
        {
            var rand = new Random(0);
            var values = DataGen.RandomWalk(rand, 100_000);
            var sampleRate = 20_000;

            // Signal plots require a data array and a sample rate (points per unit)
            _plot.Plot.Style(Style.Gray1);
            _plot.Height = 400;
            _plot.Plot.AddSignal(values, sampleRate);
            _plot.Plot.Title("Position Plot with random points");
            _plot.Render();
        }
        public void InitPlotWithValues()
        {
            _plot.Plot.Clear();
            _plot.Plot.AddSignal(_positionMeasurement.Values.ToArray(), _positionMeasurement.SamplingRate, Color.LawnGreen);
            _plot.Plot.Title("Position Plot: " + _positionMeasurement.Values.Length + " Sample Points");
            _plot.Render();
        }
    }
}
