using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ladaplotter.Resources.Computation;
using ladaplotter.Resources.Data;
using ScottPlot.Plottable;

namespace ladaplotter.UI.MeasurementPlots
{
    public class LogDataPlotViewModel
    {

        private readonly LogDataProcessing _logDataProcessing = new LogDataProcessing();

        public ObservableCollection<IMeasurementPlotViewModel> MeasurementPlotViewModels { get; } = 
            new ObservableCollection<IMeasurementPlotViewModel>();


        public LogDataPlotViewModel()
        {
            //display the empty plots when no LogData is loaded
            MeasurementPlotViewModels.Add(new SignalMeasurementPlotViewModel(null));
            MeasurementPlotViewModels.Add(new SignalMeasurementPlotViewModel(null));
        }

        public void UpdateUI(LogData1 currentLogData)
        {
            MeasurementPlotViewModels.Clear();
            _logDataProcessing.ProcessLogData(currentLogData);

            foreach (var measurement in currentLogData.Measurements)
            {
                if (measurement is PositionMeasurement positionMeasurement)
                {
                    MeasurementPlotViewModels.Add(new SignalMeasurementPlotViewModel(positionMeasurement));
                }
                else if (measurement is VelocityMeasurement velocityMeasurement)
                {
                    MeasurementPlotViewModels.Add(new SignalMeasurementPlotViewModel(velocityMeasurement));
                }
            }
        }

    }
}