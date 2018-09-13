using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xBDD.Test
{
    using xBDD.Core;
    using xBDD.Model;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Collections;
	using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

    [TestClass]
    public class xBTest
    {        
        [TestMethod]
        public async Task AllPassing()
        {
            var factory = new CoreFactory();
            xB.CurrentRun = factory.CreateTestRunBuilder("Test Run");
            var tr = await TestRunSetup.BuildTestRun();
            var reasons = new List<string>() {
                "Removing",
                "Building",
                "Untested",
                "Ready",
                "Defining"
            };
            var features = new List<string>() {
            };
            xB.Complete("xBDDConfig.json", features, (message) => { Logger.LogMessage(message); });
        }
    }
}
