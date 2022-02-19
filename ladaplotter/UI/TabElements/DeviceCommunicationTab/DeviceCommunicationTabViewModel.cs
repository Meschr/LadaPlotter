using System;
using ladaplotter.Resources.Logging;

namespace ladaplotter.UI.TabElements.DeviceCommunicationTab
{
    public class DeviceCommunicationTabViewModel
    {
        private string _stringToSend;

        private static readonly ILogger Logger = Logger<DeviceCommunicationTabViewModel>.Create();

        public DeviceCommunicationTabViewModel()
        {
           
        }

        public void SendData()
        {

        }

        public String StringToSend
        {
            get => _stringToSend;
            set => _stringToSend = value;
        }
    }
}
