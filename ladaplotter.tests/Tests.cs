using System;
using ladaplotter.Resources.Logging;
using ladaplotter.UI;
using log4net;
using Xunit;

namespace ladaplotter.tests
{
    public class Tests
    {
        [Fact]
        public void TestLoggingFunctionality()
        {
            ILogger Logger = Logger<ShellViewModel>.Create();
            Logger.Info("test log4net");
        }
    }
}
