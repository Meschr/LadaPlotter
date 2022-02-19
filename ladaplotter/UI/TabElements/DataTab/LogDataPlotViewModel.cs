using System.Collections.ObjectModel;
using ladaplotter.Resources.Computation;
using ladaplotter.Resources.Data;
using ladaplotter.UI.TabElements.DataTab.MeasurementPlots;

namespace ladaplotter.UI.TabElements.DataTab
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

        public void UpdateUI(LogData currentLogData)
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