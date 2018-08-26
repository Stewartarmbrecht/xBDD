namespace MySample.Features
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
        public static void TestRunComplete()
        {
            WebDriver.Close();

            var directory = System.IO.Directory.GetCurrentDirectory();

            xB.CurrentRun.TestRun.Name = TestConfiguration.TestRunName;

            System.IO.Directory.CreateDirectory($"{directory}/../../../test-results");

            if(TestConfiguration.SortTestRun) {
                if(TestConfiguration.FullySortTestRun) {
                    xB.CurrentRun.SortTestRunResults(new FeatureSortFull().SortedFeatureNames);
                } else {
                    xB.CurrentRun.SortTestRunResults(new FeatureSort().SortedFeatureNames);
                }
            }

            var htmlPath = directory + $"/../../../test-results/{TestConfiguration.HtmlReportFileName}";
            Logger.LogMessage("Writing Html Report to " + htmlPath);
            var htmlReport = xB.CurrentRun.TestRun.WriteToHtml(TestConfiguration.RemoveFromAreaNameStart, TestConfiguration.FailuresOnly);
            File.WriteAllText(htmlPath, htmlReport);

            var textPath = directory + $"/../../../test-results/{TestConfiguration.TextReportFileName}";
            Logger.LogMessage("Writing Text Report to " + textPath);
            var textReport = xB.CurrentRun.TestRun.WriteToText();
            File.WriteAllText(textPath, textReport);

            var jsonPath = directory + $"/../../../test-results/{TestConfiguration.JsonReportFileName}";
            Logger.LogMessage("Writing Json Report to " + jsonPath);
            var jsonReport = xB.CurrentRun.TestRun.WriteToJson();
            File.WriteAllText(jsonPath, jsonReport);

            var opmlPath = $"{directory}/../../../test-results/{TestConfiguration.OutlineReportFileName}";
            Logger.LogMessage("Writing OPML Report to " + opmlPath);
            var opmlReport = xB.CurrentRun.TestRun.WriteToOpml();
            File.WriteAllText(opmlPath, opmlReport);

            xB.CurrentRun.TestRun.WriteToCode("MySample.Features", "./Code/", "My Sample - Features - ");
        }
    }
}
