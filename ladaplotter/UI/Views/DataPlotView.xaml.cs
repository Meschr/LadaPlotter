using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ladaplotter.UI.ViewModels;
using ScottPlot;
using ScottPlot.Plottable;

namespace ladaplotter.UI.Views
{
    /// <summary>
    /// Interaction logic for DataPlotView.xaml
    /// </summary>
    public partial class DataPlotView
    {
        public DataPlotView()
        {
            InitializeComponent();
            DataContextChanged += DataPlotView_OnDataContextChanged;
        }

        private void DataPlotView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is DataPlotViewModel dataPlotViewModel)
            {
                ChartGrid.Children.Clear();
                ChartGrid.Children.Add(dataPlotViewModel.SignalPlot);

                dataPlotViewModel.SignalPlot.Render();
            }
        }
    }
}
