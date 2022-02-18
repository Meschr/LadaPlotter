using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ladaplotter.Resources.Data;

namespace ladaplotter.UI.MeasurementPlots
{
    public class LogDataPlotViewModel
    {

        public ObservableCollection<IMeasurementPlotViewModel> MeasurementPlotViewModels { get; } =
            new ObservableCollection<IMeasurementPlotViewModel>();


        public LogDataPlotViewModel()
        {
            MeasurementPlotViewModels.Add(new PositionMeasurementPlotViewModel(null));
            MeasurementPlotViewModels.Add(new VelocityMeasurementPlotViewModel(new VelocityMeasurement(new List<double>(1000), 100, "mm")));
        }

        public void UpdateUI(LogData1 CurrentLogData)
        {
            MeasurementPlotViewModels.Clear();
            MeasurementPlotViewModels.Add(new PositionMeasurementPlotViewModel(CurrentLogData.Measurements.FirstOrDefault() as PositionMeasurement));
        }

    }
}