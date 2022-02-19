﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ladaplotter.Resources.Data
{
    public class LogData1
    {
        private ObservableCollection<IMeasurement> _measurements = new ObservableCollection<IMeasurement>();

        public bool Processed { get;}

        public LogData1()
        {
            Processed = false;
            TimeStamp = DateTime.Now; //todo später auslesen aus logfile
        }

        public void AddMeasurement(IMeasurement measurement)
        {
            _measurements.Add(measurement);
        }

        public DateTime TimeStamp { get; private set; }

        public String Name { get; set; }

        public ObservableCollection<IMeasurement> Measurements => _measurements;
    }
}
