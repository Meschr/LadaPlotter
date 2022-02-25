using System;
using System.Threading.Tasks;
using ladaplotter.Resources.Data;

namespace ladaplotter.Resources.Logic
{
    public interface ILogDataReader
    {
        Task<LogData> Read(string path);
    }
}