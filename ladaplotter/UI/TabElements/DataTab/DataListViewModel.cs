using System;
using System.Collections.ObjectModel;
using System.IO;
using Caliburn.Micro;

namespace ladaplotter.UI.TabElements.DataTab
{
    public class DataListViewModel : PropertyChangedBase
    {
        private string _selectedItem;

        public ObservableCollection<string> LocalMeasurements { get; private set; } =
            new ObservableCollection<string>();

        public DataListViewModel()
        {
            FillListBoxWithExistingFiles();
        }

        private void FillListBoxWithExistingFiles()
        {
            //Get all files with a .txt extension:
            foreach (string filepath in Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Ladadogger\\MeasurementData\\"), "*.txt"))
            {
                LocalMeasurements.Add(String.Copy(filepath));
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
    }
}