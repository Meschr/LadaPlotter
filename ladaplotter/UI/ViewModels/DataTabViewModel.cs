using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
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
