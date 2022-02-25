using System;
using System.Collections.Generic;
using System.Text;

namespace ladaplotter.Resources.Events
{
    public class LogDataChangedEvent
    {
        public LogDataChangedEvent(string logDataName, string filepath)
        {
            LogDataName = logDataName;
            Filepath = filepath;
        }

        public string Filepath { get; }
        public string LogDataName { get; }
    }
}
