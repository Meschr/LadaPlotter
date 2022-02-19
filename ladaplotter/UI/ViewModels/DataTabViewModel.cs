using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ladaplotter.Resources.Data;
using ladaplotter.Resources.Logic;
using ladaplotter.UI.MeasurementPlots;

namespace ladaplotter.UI.ViewModels
{
    public class DataTabViewModel : PropertyChangedBase
    {
        private DataListViewModel _dataListViewModel;
        private LogDataPlotViewModel _dataPlotViewModel;

        public DataTabViewModel()
        {
            _dataListViewModel = new DataListViewModel();
            _dataPlotViewModel = new LogDataPlotViewModel();
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
            DataPlotViewModel.UpdateUI(logDataReader.LogData); //todo refactor LogDataReader
        }

        public DataListViewModel LocalDataListViewModel
        {
            get => _dataListViewModel;
            set
            {
                _dataListViewModel= value;
                NotifyOfPropertyChange();
            }
        }

        public LogDataPlotViewModel DataPlotViewModel
        {
            get => _dataPlotViewModel;
            set
            {
                _dataPlotViewModel = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
