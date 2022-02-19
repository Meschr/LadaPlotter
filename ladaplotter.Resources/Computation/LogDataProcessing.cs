using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using ladaplotter.Resources.Data;
using ladaplotter.Resources.UDP;

namespace ladaplotter.Resources.Computation
{
    public class LogDataProcessing
    {
        public void ProcessLogData(LogData1 logData)
        {
            if(logData.Processed)
                return;

            var measurements = new ObservableCollection<IMeasurement>(logData.Measurements);
            foreach (var measurement in measurements)
            {
                if (measurement is PositionMeasurement positionMeasurement)
                {
                    var velocityMeasurement = new VelocityMeasurement(ComputeVelocity(positionMeasurement), 1000); //todo refactor sampling rate handling
                    logData.AddMeasurement(velocityMeasurement);
                }
            }
        }

        private double [] ComputeVelocity(PositionMeasurement positionMeasurement)
        {
            //1.Schritt Eckdeteck 
            //2.Spline
            var positionValues = positionMeasurement.Values;
            var velocityValues = new double[positionValues.Length];

            for (var i = 0; i < positionValues.Length; i++)
            {
                velocityValues[i] = positionValues[i] / 2;
            }

            return velocityValues;
        }
    }
}