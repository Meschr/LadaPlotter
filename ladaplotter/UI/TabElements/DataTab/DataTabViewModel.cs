using System.Threading.Tasks;
using Caliburn.Micro;
using ladaplotter.Resources.Logic;

namespace ladaplotter.UI.TabElements.DataTab
{
    public class DataTabViewModel : PropertyChangedBase
    {
        private DataListViewModel _dataListViewModel;
        private DataToolboxViewModel _dataToolboxViewModel;
        private LogDataPlotViewModel _dataPlotViewModel;

        public DataTabViewModel()
        {
            _dataListViewModel = new DataListViewModel();
            _dataToolboxViewModel = new DataToolboxViewModel();
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
            var logDataReader = new LogDataReaderFromFile();
            await logDataReader.Read(in_path);
            DataPlotViewModel.UpdateUi(logDataReader.LogData); //todo refactor LogDataReader
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

        public DataToolboxViewModel DataToolboxViewModel
        {
            get => _dataToolboxViewModel;
            set
            {
                _dataToolboxViewModel = value;
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
