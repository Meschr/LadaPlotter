using System.Windows;
using System.Windows.Controls;

namespace ladaplotter.UI.TabElements.DataTab.MeasurementPlots
{
    /// <summary>
    /// Interaction logic for PositionMeasurementPlotView.xaml
    /// </summary>
    public partial class PositionMeasurementPlotView : UserControl
    {
        public PositionMeasurementPlotView()
        {
            InitializeComponent();
            DataContextChanged += DataPlotView_OnDataContextChanged;
        }

        private void DataPlotView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is PositionMeasurementPlotViewModel positionMeasurementPlotViewModel)
            {
                PlotGrid.Children.Clear();

                PlotGrid.Children.Add(positionMeasurementPlotViewModel.Plot);

                positionMeasurementPlotViewModel.Plot.Render();
            }
        }

    }
}
