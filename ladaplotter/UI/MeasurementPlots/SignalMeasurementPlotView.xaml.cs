using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ladaplotter.UI.MeasurementPlots
{
    /// <summary>
    /// Interaktionslogik für SignalMeasurementPlotView.xaml
    /// </summary>
    public partial class SignalMeasurementPlotView : UserControl
    {
        public SignalMeasurementPlotView()
        {
            InitializeComponent();
            DataContextChanged += DataPlotView_OnDataContextChanged;
        }

        private void DataPlotView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is SignalMeasurementPlotViewModel signalMeasurementPlotViewModel)
            {
                PlotGrid.Children.Clear();

                PlotGrid.Children.Add(signalMeasurementPlotViewModel.Plot);

                signalMeasurementPlotViewModel.Plot.Render();
            }
        }
    }
}
