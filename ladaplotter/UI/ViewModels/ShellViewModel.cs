using Caliburn.Micro;
using ladaplotter.Resources.Logging;

namespace ladaplotter.UI.ViewModels
{
    public class ShellViewModel : PropertyChangedBase
    {
        private static readonly ILogger Logger = Logger<ShellViewModel>.Create();

        private UDPTestViewModel _udpTestViewModel;
        private DataTabViewModel _localDataTabViewModel;

        public ShellViewModel()
        {
            _udpTestViewModel = new UDPTestViewModel();
            _localDataTabViewModel = new DataTabViewModel();
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

        public UDPTestViewModel UdpTestViewModel
        {
            get => _udpTestViewModel;
            set
            {
                _udpTestViewModel = value;
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