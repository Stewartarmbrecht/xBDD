using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class ReportLocations
    {
        public PageLocation FromATestRunWithOnePassingScenario => new PageLocation(
            "the test html report from a test run with one passing scenario", 
            $"file:///{root}MySample.Features.Results.FirstPassing.html");
        public PageLocation FromAPassingTestRun => new PageLocation(
            "the test html report from a test run with all passing scenarios", 
            $"file:///{root}MySample.Features.Results.Passing.html");
        public PageLocation FromAPassingTestRunWithFailuresOnly => new PageLocation(
            "the test html report from a test run with all passing scenarios reporting failures only", 
            $"file:///{root}MySample.Features.Results.PassingFailuresOnly.html");
        public PageLocation FromASkippedTestRun => new PageLocation(
            "the test html report from a test run with passing and skipped scenarios", 
            $"file:///{root}MySample.Features.Results.Skipped.html");
        public PageLocation FromASkippedTestRunWithFailuresOnly => new PageLocation(
            "the test html report from a test run with passing and skipped scenarios reporting failures only", 
            $"file:///{root}MySample.Features.Results.SkippedFailuresOnly.html");
        public PageLocation FromATestRunWithOneFailingScenario => new PageLocation(
            "the test html report from a test run with one failed scenario", 
            $"file:///{root}MySample.Features.Results.FirstFailing.html");
        public PageLocation FromAFailedTestRun => new PageLocation(
            "the test html report from a test run with passing, skipped, and failed scenarios", 
            $"file:///{root}MySample.Features.Results.All.html");
        public PageLocation FromAFailedTestRunWithFailuresOnly => new PageLocation(
            "the test html report from a test run with passing, skipped, and failed scenarios and reporting failures only", 
            $"file:///{root}MySample.Features.Results.AllFailuresOnly.html");
        public PageLocation FromAFailedUnsortedTestRun => new PageLocation(
            "the test html report from an unsorted test run with passing, skipped, and failed scenarios", 
            $"file:///{root}MySample.Features.Results.All.Unsorted.html");
        public PageLocation FromAFailedFullySortedTestRun => new PageLocation(
            "the test html report from a fully sorted test run with passing, skipped, and failed scenarios", 
            $"file:///{root}MySample.Features.Results.All.FullSorted.html");
        public PageLocation FromATestRunWithNoScenarios => new PageLocation(
            "the test html report from a test run with no scenarios", 
            $"file:///{root}MySample.Features.Results.NoScenarios.html");
        public PageLocation FromATestRunWithNoAreaNameRemoval => new PageLocation(
            "the test html report from a test run with no area name removal", 
            $"file:///{root}MySample.Features.Results.NoAreaNameRemoval.html");
        public PageLocation FromATestRunWithFullAreaNameRemoval => new PageLocation(
            "the test html report from a test run with no area name removal", 
            $"file:///{root}MySample.Features.Results.FullAreaNameRemoval.html");

        private string location;
        private string root; 
        public ReportLocations()
        {
            this.root = System.IO.Directory.GetCurrentDirectory();
            var s = System.IO.Path.DirectorySeparatorChar;
            this.root = $"{root}{s}..{s}..{s}..{s}..{s}MySample.Features{s}test-results{s}";
        }
	
    }
}