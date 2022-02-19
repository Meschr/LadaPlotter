using System.Windows;
using System.Windows.Controls;

namespace ladaplotter.UI.TabElements.DataTab
{
    /// <summary>
    /// Interaction logic for LogDataPlotView.xaml
    /// </summary>
    public partial class LogDataPlotView : UserControl
    {
        public LogDataPlotView()
        {
            InitializeComponent();
            DataContextChanged += DataPlotView_OnDataContextChanged;
        }
        private void DataPlotView_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
