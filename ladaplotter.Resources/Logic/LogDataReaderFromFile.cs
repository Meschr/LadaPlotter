using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ladaplotter.Resources.Data;

namespace ladaplotter.Resources.Logic
{
    public class LogDataReaderFromFile : ILogDataReader
    {

        public async Task<LogData> Read(string path)
        {
            var logData = new LogData();
            logData.Name = Path.GetFileNameWithoutExtension(path);
            using (var fileReader = File.OpenText(path))
            {
                var fileText = await fileReader.ReadToEndAsync();
                var stringReader = new System.IO.StringReader(fileText);
                var line = stringReader.ReadLine();

                var positionValues = new List<double>();
                while (line != null)
                {
                    var linesplit = line.Split(new[] { "," }, StringSplitOptions.None);
                    uint index = 0;
                    bool marker = false;
                    double pos = 0;

                    if (linesplit.Length >= 3) index = Convert.ToUInt32(linesplit[2]);
                    if (linesplit.Length >= 2) marker = Convert.ToInt32(linesplit[1]) != 0;
                    if (linesplit.Length >= 1) pos = Convert.ToDouble(linesplit[0]);

                    positionValues.Add(pos);

                    line = stringReader.ReadLine(); // read next line
                }

                PositionMeasurement position = new PositionMeasurement(positionValues.ToArray(), 1000);
                logData.AddMeasurement(position);
            }

            return logData;
        }
    }
}