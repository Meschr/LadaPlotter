using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ladaplotter.Resources.Data;
using ScottPlot;

namespace ladaplotter.UI.MeasurementPlots
{
    public class PositionMeasurementPlotViewModel : IMeasurementPlotViewModel
    {
        private PositionMeasurement _positionMeasurement;

        private WpfPlot _positionPlot;

        public PositionMeasurementPlotViewModel(PositionMeasurement measurement)
        {
            _positionMeasurement = measurement;
        }

        public WpfPlot Plot
        {
            get => _positionPlot;
            set
            {
                _positionPlot = value;
                InitPlot();
            }
        }

        private void InitPlot()
        {
            var rand = new Random(0);
            var values = DataGen.RandomWalk(rand, 100_000);
            var sampleRate = 20_000;

            // Signal plots require a data array and a sample rate (points per unit)
            _positionPlot.Plot.Style(Style.Gray1);
            _positionPlot.Height = 400;
            _positionPlot.Plot.AddSignal(values, sampleRate);
            _positionPlot.Plot.Benchmark(true);
            _positionPlot.Plot.Title("Signal Plot: One Million Points");
            _positionPlot.Plot.Render();
        }
    }
}
