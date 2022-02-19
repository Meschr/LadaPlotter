using System;
using System.Drawing;
using ladaplotter.Resources.Data;
using ScottPlot;

namespace ladaplotter.UI.TabElements.DataTab.MeasurementPlots
{
    public class VelocityMeasurementPlotViewModel : IMeasurementPlotViewModel
    {
        private VelocityMeasurement _velocityMeasurement;

        private WpfPlot _plot;

        public VelocityMeasurementPlotViewModel(VelocityMeasurement measurement)
        {
            _velocityMeasurement = measurement;
            Plot = new WpfPlot();

            if (measurement != null)
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
            _plot.Plot.AddSignal(values, sampleRate, Color.LawnGreen);
            _plot.Plot.Title("Velocity Plot: " + values.Length + " Sample Points");
            _plot.Render();
        }

        public void InitPlotWithValues()
        {
            _plot.Plot.Clear();
            _plot.Plot.AddSignal(_velocityMeasurement.Values, _velocityMeasurement.SamplingRate, Color.LawnGreen);
            _plot.Plot.Title("Velocity Plot: " + _velocityMeasurement.Values.Length + " Sample Points");
            _plot.Render();
        }
    }
}