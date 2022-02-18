using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace ladaplotter.UI.ViewModels
{
    public class DataTabViewModel : PropertyChangedBase
    {
        private DataListViewModel _dataListViewModel;
        private DataPlotViewModel _dataPlotViewModel;

        public DataTabViewModel()
        {
            _dataListViewModel = new DataListViewModel();
            _dataPlotViewModel = new DataPlotViewModel();
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

        public DataPlotViewModel DataPlotViewModel
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
