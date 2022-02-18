using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using ladaplotter.Resources.Logic;
using ScottPlot;

namespace ladaplotter.UI.ViewModels
{
    public class DataPlotViewModel : PropertyChangedBase
    {
        private Plot _signalPlot;
        private WpfPlot _wpfPlot;

        public DataPlotViewModel()
        {
            YFormatter = value => value.ToString("N");
            WpfPlot = new WpfPlot();
        }

        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public Plot SignalPlot
        {
            get => _signalPlot;
            set
            {
                _signalPlot = value;
                InitSignalPlot();
            }
        }


        public WpfPlot WpfPlot
        {
            get => _wpfPlot;
            set
            {
                _wpfPlot = value;
                InitWpfPlot();
            }
        }

        public async void ChooseFile()
        {
            SignalPlot.Render();
            /*
            var fileDialog = new Microsoft.Win32.OpenFileDialog() { Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" };
            var result = fileDialog.ShowDialog();
            if (result != false)
            {
                var path = fileDialog.FileName;
                await HeavyMethodAsync(path);
            }*/
        }

        internal async Task HeavyMethodAsync(string in_path)
        {
            var logDataReader = new LogDataReaderFromFile1();
            await logDataReader.Read(in_path);
            var dataList = logDataReader.LogData;
        }

        private void InitSignalPlot()
        {
            var rand = new Random(0);
            var values = DataGen.RandomWalk(rand, 100_000);
            var sampleRate = 20_000;

            // Signal plots require a data array and a sample rate (points per unit)
            _signalPlot.Height = 400;
            _signalPlot.AddSignal(values, sampleRate);
            _signalPlot.Benchmark(true);
            _signalPlot.Title("Signal Plot: One Million Points");
            _signalPlot.Render();
        }

        private void InitWpfPlot()
        {
            var rand = new Random(0);
            var values = DataGen.RandomWalk(rand, 100_000);
            const int sampleRate = 20_000;

            // Signal plots require a data array and a sample rate (points per unit)
            //_wpfPlot.Height = 400;
            //_wpfPlot.AddSignal(values, sampleRate);
            //_wpfPlot.Benchmark(true);
            //_wpfPlot.Title("Signal Plot: One Million Points");
            //_wpfPlot.Render();
        }
    }
}