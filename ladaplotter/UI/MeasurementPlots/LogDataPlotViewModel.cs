using System.Collections.Generic;
using System.Collections.ObjectModel;
using ladaplotter.Resources.Data;

namespace ladaplotter.UI.MeasurementPlots
{
    public class LogDataPlotViewModel
    {

        public ObservableCollection<IMeasurementPlotViewModel> MeasurementPlotViewModels { get; } =
            new ObservableCollection<IMeasurementPlotViewModel>();


        public LogDataPlotViewModel()
        {
            MeasurementPlotViewModels.Add(new PositionMeasurementPlotViewModel(new PositionMeasurement(new List<double>(1000),100,"mm")));
        }
    }
}