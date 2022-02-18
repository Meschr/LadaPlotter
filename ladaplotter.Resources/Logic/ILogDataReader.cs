using System;
using System.Threading.Tasks;

namespace ladaplotter.Resources.Logic
{
    public interface ILogDataReader
    {
        Task Read(string path);
    }
}