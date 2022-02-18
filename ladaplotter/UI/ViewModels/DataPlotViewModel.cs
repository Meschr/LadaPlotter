using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using Caliburn.Micro;
using ladaplotter.Resources.Data;
using ladaplotter.Resources.Logic;
using ScottPlot;

namespace ladaplotter.UI.ViewModels
{
    public class DataPlotViewModel : PropertyChangedBase
    {
        private WpfPlot _signalPlot;

        private LogData1 _dataContext;

        public DataPlotViewModel()
        {
            SignalPlot = new WpfPlot();
            YFormatter = value => value.ToString("N");
        }

        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public WpfPlot SignalPlot
        {
            get => _signalPlot;
            set
            {
                _signalPlot = value;
                InitSignalPlot();
            }
        }

        public async void ChooseFile()
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog() { Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" };
            var result = fileDialog.ShowDialog();
            if (result != false)
            {
                var path = fileDialog.FileName;
                await HeavyMethodAsync(path);
            }
        }

        internal async Task HeavyMethodAsync(string in_path)
        {
            var logDataReader = new LogDataReaderFromFile1();
            await logDataReader.Read(in_path);
            _dataContext = logDataReader.LogData;
            UpdateChart();
        }


        private void UpdateChart()
        {
            if(_dataContext == null)
                return;
            
            _signalPlot.Plot.Clear();
            _signalPlot.Plot.AddSignal(_dataContext.Measurements.FirstOrDefault().Values.ToArray(), 1000);
            _signalPlot.Plot.Title(_dataContext.Measurements.FirstOrDefault().Values.Count + " Samples");
            _signalPlot.Plot.Render();
        }

        private void InitSignalPlot()
        {
            var rand = new Random(0);
            var values = DataGen.RandomWalk(rand, 100_000);
            var sampleRate = 20_000;

            // Signal plots require a data array and a sample rate (points per unit)
            _signalPlot.Plot.Style(Style.Gray1);
            _signalPlot.Height = 400;
            _signalPlot.Plot.AddSignal(values, sampleRate);
            _signalPlot.Plot.Benchmark(true);
            _signalPlot.Plot.Title("Signal Plot: One Million Points");
            _signalPlot.Plot.Render();
        }
    }
}