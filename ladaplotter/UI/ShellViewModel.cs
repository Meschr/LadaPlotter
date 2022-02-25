using Caliburn.Micro;
using ladaplotter.Resources.Logging;
using ladaplotter.UI.TabElements.DataTab;
using ladaplotter.UI.TabElements.DeviceCommunicationTab;

namespace ladaplotter.UI
{
    public class ShellViewModel : PropertyChangedBase
    {
        private static readonly ILogger Logger = Logger<ShellViewModel>.Create();
        private readonly IEventAggregator _eventAggregator = new EventAggregator();

        private DeviceCommunicationTabViewModel _deviceCommunicationTabViewModel;
        private DataTabViewModel _localDataTabViewModel;

        public ShellViewModel()
        {
            _deviceCommunicationTabViewModel = new DeviceCommunicationTabViewModel();
            _localDataTabViewModel = new DataTabViewModel(_eventAggregator);
        }


        public void LogoIcon()
        {
            string targetWebsite = "https://www.youtube.com/watch?v=VU2d_Pld3w8";

            try
            {
                System.Diagnostics.Process.Start(targetWebsite);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                Logger.Error(noBrowser, noBrowser.Message);
            }
            catch (System.Exception other)
            {
                Logger.Error(other, other.Message);
            }
        }

        public DeviceCommunicationTabViewModel DeviceCommunicationTabViewModel
        {
            get => _deviceCommunicationTabViewModel;
            set
            {
                _deviceCommunicationTabViewModel = value;
                NotifyOfPropertyChange();
            }
        }

        public DataTabViewModel LocalDataTabViewModel
        {
            get => _localDataTabViewModel;
            set
            {
                _localDataTabViewModel = value;
                NotifyOfPropertyChange();
            }
        }
    }
}