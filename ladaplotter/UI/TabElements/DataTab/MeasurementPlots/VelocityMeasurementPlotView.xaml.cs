using System.Windows;
using System.Windows.Controls;

namespace ladaplotter.UI.TabElements.DataTab.MeasurementPlots
{
    /// <summary>
    /// Interaction logic for PositionMeasurementPlotView.xaml
    /// </summary>
    public partial class VelocityMeasurementPlotView : UserControl
    {
        public VelocityMeasurementPlotView()
        {
            InitializeComponent();
            DataContextChanged += DataPlotView_OnDataContextChanged;
        }

        private void DataPlotView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is VelocityMeasurementPlotViewModel velocityMeasurementPlotViewModel)
            {
                PlotGrid.Children.Clear();

                PlotGrid.Children.Add(velocityMeasurementPlotViewModel.Plot);

                velocityMeasurementPlotViewModel.Plot.Render();
            }
        }

    }
}
