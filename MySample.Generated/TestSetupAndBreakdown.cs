namespace MySample.Generated
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using xBDD;
    using xBDD.Browser;

    [TestClass]
    public class TestSetupAndBreakdown
    {

        [AssemblyInitialize]
        public static void TestRunStart(TestContext context)
        {
            xBDD.Browser.WebBrowser.WatchBrowser = TestConfiguration.WatchBrowswer;
        }
        [AssemblyCleanup()]
        public async static Task TestRunComplete()
        {
            WebDriver.Close();

            var directory = System.IO.Directory.GetCurrentDirectory();

            xB.CurrentRun.TestRun.Name = TestConfiguration.TestRunName;

            System.IO.Directory.CreateDirectory($"{directory}/../../../test-results");

            xB.CurrentRun.SortTestRunResults(new FeatureSort().SortedFeatureNames);

            var htmlPath = directory + $"/../../../test-results/MySample.Generated.Results.html";
            Logger.LogMessage("Writing Html Report to " + htmlPath);
            var htmlReport = await xB.CurrentRun.TestRun.WriteToHtml(TestConfiguration.RemoveFromAreaNameStart, TestConfiguration.FailuresOnly);
            File.WriteAllText(htmlPath, htmlReport);

            var textPath = directory + $"/../../../test-results/MySample.Generated.Results.txt";
            Logger.LogMessage("Writing Text Report to " + textPath);
            var textReport = await xB.CurrentRun.TestRun.WriteToText();
            File.WriteAllText(textPath, textReport);

            var jsonPath = directory + $"/../../../test-results/MySample.Generated.Results.json";
            Logger.LogMessage("Writing Json Report to " + jsonPath);
            var jsonReport = xB.CurrentRun.TestRun.WriteToJson();
            File.WriteAllText(jsonPath, jsonReport);

            var opmlPath = $"{directory}/../../../test-results/MySample.Generated.Results.opml";
            Logger.LogMessage("Writing OPML Report to " + opmlPath);
            var opmlReport = await xB.CurrentRun.TestRun.WriteToOpml();
            File.WriteAllText(opmlPath, opmlReport);

        }
    }
}
