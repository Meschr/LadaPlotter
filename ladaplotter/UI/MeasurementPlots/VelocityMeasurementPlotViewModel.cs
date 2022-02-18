using System;
using System.Drawing;
using ladaplotter.Resources.Data;
using ScottPlot;

namespace ladaplotter.UI.MeasurementPlots
{
    public class VelocityMeasurementPlotViewModel : IMeasurementPlotViewModel
    {
        private VelocityMeasurement _positionMeasurement;

        private WpfPlot _plot;

        public VelocityMeasurementPlotViewModel(VelocityMeasurement measurement)
        {
            _positionMeasurement = measurement;
            Plot = new WpfPlot();
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
            _plot.Plot.Benchmark(true);
            _plot.Plot.Title("Velocity Plot: " + _positionMeasurement.Values.Count + " Sample Points");
            _plot.Render();
        }
    }
}