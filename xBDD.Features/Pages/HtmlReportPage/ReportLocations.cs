using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class ReportLocations
    {
        public PageLocation WithAFailingStepWithAnException => new PageLocation(
            "the test html report with a failing step with an exception", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithAFailingStepWithAnException.html");
        public PageLocation WithAPassingFullTestRun => new PageLocation(
            "the test html report with a passing full test run", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithAPassingFullTestRun.html");
        public PageLocation WithAFullTestRunWithAllOutcomes => new PageLocation(
            "the test html report with a full test run with all outcomes", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithAFullTestRunWithAllOutcomes.html");
        public PageLocation WithAFailingStepWithANestedException => new PageLocation(
            "the test html report with a failing step with a nested exception", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithAFailingStepWithANestedException.html");
        public PageLocation WithAStepWithOutput => new PageLocation(
            "the test html report with a step with output", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithAStepWithOutput.html");
        public PageLocation WithASinglePassingScenario => new PageLocation(
            "the test html report with a single passing scenario", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithASinglePassingScenario.html");
        public PageLocation WithASingleFailedScenario => new PageLocation(
            "the test html report with a single failed scenario", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithASingleFailedScenario.html");
        public PageLocation WithASingleSkippedScenario => new PageLocation(
            "the test html report with a single skipped scenario", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithASingleSkippedScenario.html");
        public PageLocation WithAnEmptyTestRun => new PageLocation(
            "the test html report with an empty test run", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithAnEmptyTestRun.html");

        public PageLocation ThatIsNotSorted => new PageLocation(
            "the sample test html report that is not sorted", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsThatIsNotSorted.html");

        public PageLocation ThatIsSorted => new PageLocation(
            "the sample test html report that is sorted", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsThatIsSorted.html");

        public PageLocation WithAStepWithAMultilineParameter => new PageLocation(
            "the sample test html report with a step with a multiline parameter", 
            $"file:///{directory}{System.IO.Path.DirectorySeparatorChar}TestResultsWithAStepWithAMultilineParameter.html");

        private string location;
        private string directory; 
        public ReportLocations()
        {
            this.location = System.Reflection.Assembly.GetEntryAssembly().Location;
            this.directory = System.IO.Path.GetDirectoryName(this.location);
        }
	
    }
}