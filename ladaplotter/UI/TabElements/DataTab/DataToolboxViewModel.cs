using System.Windows;
using Caliburn.Micro;
using MahApps.Metro.Controls;

namespace ladaplotter.UI.TabElements.DataTab
{
    public class DataToolboxViewModel
    {
        public bool ScrollingEnabled { get; private set; }

        public bool PlotsConnected { get; private set; }

        public void ConnectPlotsToggled(object sender, RoutedEventArgs e)
        {
            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch == null)
                return;

            PlotsConnected = toggleSwitch.IsOn;
        }

        public void EnableScrollToggled(object sender, RoutedEventArgs e)
        {
            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch == null) 
                return;

            ScrollingEnabled = toggleSwitch.IsOn;
        }
    }
}
