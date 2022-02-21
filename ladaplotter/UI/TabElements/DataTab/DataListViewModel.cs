using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace ladaplotter.UI.TabElements.DataTab
{
    public class DataListViewModel : PropertyChangedBase
    {
        private string _selectedItem;

        public CancellationToken PeriodicUpdateTaskCancellationToken { get; } = new CancellationToken();

        public ObservableCollection<string> LocalMeasurements { get; private set; } = new ObservableCollection<string>();

        public DataListViewModel()
        {
            _ = PeriodicFooAsync(new TimeSpan(0, 0, 3), PeriodicUpdateTaskCancellationToken);
        }

        public async Task PeriodicFooAsync(TimeSpan interval, CancellationToken cancellationToken)
        {
            while (true)
            {
                await FillListBoxWithExistingFiles();
                await Task.Delay(interval, cancellationToken);
            }
        }

        private async Task FillListBoxWithExistingFiles()
        {
            LocalMeasurements.Clear();
            //Get all files with a .txt extension:
            foreach (string filepath in Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Ladadogger\\MeasurementData\\"), "*.txt"))
            {
                LocalMeasurements.Add(Path.GetFileNameWithoutExtension(filepath));
            }
        }

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    NotifyOfPropertyChange();
                }
            }
        }
        public void SelectionChanged(Object sender, EventArgs e)
        {

        }
    }
}