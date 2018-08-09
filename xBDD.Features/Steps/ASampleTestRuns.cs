namespace xBDD.Features.Steps
{
    using System;
    using System.IO;
    using System.Linq;
    using xBDD.Model;

    public static class ASampleTestRun
    {
        internal static Step ThatIsNotSorted()
        {
            string path = GetReportPath("ThatIsNotSorted");

            var step = xB.CreateAsyncStep(
                "a sample executed test run that is not sorted",
                async (s) =>
                {
                    var sampleTestRun = await SampleApp.Features.SampleTestRun.RunTests();
                    var htmlReport = await sampleTestRun.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step ThatIsSorted()
        {
            string path = GetReportPath("ThatIsSorted");

            var step = xB.CreateAsyncStep(
                "a sample executed test run that is not sorted",
                async (s) =>
                {
                    var sampleTestRun = await SampleApp.Features.SampleTestRun.RunTests();
                    sampleTestRun.CurrentRun.SortTestRunResults(SampleApp.Features.SampleFeatureSort.SortedFeatureNames);
                    var htmlReport = await sampleTestRun.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        private static string GetReportPath(string reportName)
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            var path = directory + $"{System.IO.Path.DirectorySeparatorChar}TestResults{reportName}.html";
            return path;
        }
    }
}