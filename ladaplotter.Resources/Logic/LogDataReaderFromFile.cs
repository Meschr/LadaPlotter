using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ladaplotter.Resources.Logic
{
    public class LogDataReaderFromFile : ILogDataReader
    {
        private List<Data.SLogData> _DataList = new List<Data.SLogData>();
        public List<Data.SLogData> DataList { get { return _DataList; } set{} }

        public async Task Read(String in_path)
        {
            _DataList.Clear();

            using (var fileReader = File.OpenText(in_path))
            {
                var fileText = await fileReader.ReadToEndAsync();
                var stringReader = new System.IO.StringReader(fileText);
                var line = stringReader.ReadLine();

                while (line != null)
                {
                    var linesplit = line.Split(new[] { "," }, StringSplitOptions.None);
                    uint index = 0;
                    bool marker = false;
                    double pos = 0;

                    if (linesplit.Length >= 3) index = Convert.ToUInt32(linesplit[2]);
                    if (linesplit.Length >= 2) marker = Convert.ToInt32(linesplit[1]) != 0;
                    if (linesplit.Length >= 1) pos = Convert.ToDouble(linesplit[0]);

                    _DataList.Add(new Data.SLogData(index, marker, pos));
                    line = stringReader.ReadLine(); // read next line
                }
            }
        }
    }
}
