using System;
using System.Drawing;
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
        private WpfPlot _positionPlot;

        private LogData1 _dataContext;

        public DataPlotViewModel()
        {
            PositionPlot = new WpfPlot();
        }

        public WpfPlot PositionPlot
        {
            get => _positionPlot;
            set
            {
                _positionPlot = value;
                InitPositionPlot();
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
            
            _positionPlot.Plot.Clear();
            _positionPlot.Plot.AddSignal(_dataContext.Measurements.FirstOrDefault().Values.ToArray(), 1000, Color.Coral);
            _positionPlot.Plot.Title(_dataContext.Measurements.FirstOrDefault().Values.Count + " Samples");
            _positionPlot.Render();
        }

        private void InitPositionPlot()
        {
            var rand = new Random(0);
            var values = DataGen.RandomWalk(rand, 100_000);
            var sampleRate = 20_000;

            // Signal plots require a data array and a sample rate (points per unit)
            _positionPlot.Plot.Style(Style.Gray1);
            _positionPlot.Height = 400;
            _positionPlot.Plot.AddSignal(values, sampleRate);
            _positionPlot.Plot.Benchmark(true);
            _positionPlot.Plot.Title("Signal Plot: One Million Points");
            _positionPlot.Plot.Render();
        }
    }
}