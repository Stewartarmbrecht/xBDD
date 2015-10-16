using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.Environment
{
    [Collection("xBDDTest")]
    public class RunTests
    {
        private readonly OutputWriter outputWriter;

        public RunTests(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void RunAllTests ()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given("a contributor has downloaded the solution")
                .And("the contributor runs the xBDD\\RunJustTests.ps1 powershell script")
                .Then("all tests will run")
				.And("the test results will be written in plain text to the <ProjectName>.TestResults.txt file at the root of each project")
				.And("the test results will be written in html to the <ProjectName>.TestResults.html file at the root of each project")
				.And("the output from running the tests will be written to the <ProjectName>.Output.txt file at the root of each project")
                .Document();
        }
        [ScenarioFact]
        public void RunProjectTests ()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given("a contributor has downloaded the solution")
                .And("opened powershell")
                .And("has navigated to the root folder of a project in powershell")
                .When("the contributor runs 'dnx test' in powershell")
                .Then("all tests in that project will run")
				.And("the test results will be written in plain text to the <ProjectName>.TestResults.txt file at the root of the project")
				.And("the test results will be written in html to the <ProjectName>.TestResults.html file at the root of the project")
				.And("the output from running the tests will be written to the <ProjectName>.Output.txt file at the root of the project")
                .Document();
        }
        [ScenarioFact]
        public void RunFilteredTests ()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given("a contributor has downloaded the solution")
                .And("marked a test method with a trait: '[Trait(\"category\", \"now\")]'")
                .And("has opened powershell")
                .And("has navigated to the root folder of a project in powershell")
                .When("the contributor runs 'dnx xunit.runner.dnx -trait \"category=now\"")
                .Then("only the test that was marked will run")
				.And("the test results will be written in plain text to the <ProjectName>.TestResults.txt file at the root of the project")
				.And("the test results will be written in html to the <ProjectName>.TestResults.html file at the root of the project")
				.And("the output from running the tests will be written to the <ProjectName>.Output.txt file at the root of the project")
                .Document();
        }
    }
}
