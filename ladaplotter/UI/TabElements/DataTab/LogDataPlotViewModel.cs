using System.Collections.ObjectModel;
using System.Web.UI;
using System.Windows.Controls;
using System.Windows.Input;
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
            MeasurementPlotViewModels.Add(new SignalMeasurementPlotViewModel(null));
        }

        public void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            // manually scroll the window then mark the event as handled so it does not zoom
            double scrollOffset = scrollViewer.VerticalOffset - (e.Delta * .2);
            scrollViewer.ScrollToVerticalOffset(scrollOffset);
            e.Handled = true;
        }

        public void UpdateUi(LogData currentLogData)
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