using Microsoft.Framework.Runtime;
using Microsoft.Framework.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;
using System.IO;

namespace xBDD.Test.Features.Helpers
{
    public class CompareStrings
    {
        private readonly IOutputWriter outputWriter;

        public CompareStrings(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }
        Steps s = new Steps();
        [ScenarioTheory]
        [InlineData("Matching", true)]
        [InlineData("Miss", false)]
        [InlineData("MissMultilineTargetMore", false)]
        [InlineData("MissMultilineTemplateMore", false)]
        public void CompareTwoMatchingSingleLines(string scenario, bool match)
        {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.Target = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\Helpers\\TestFiles\\" + scenario + "Target.txt");
            s.State.Template = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\Helpers\\TestFiles\\" + scenario + "Template.txt");
            s.State.Match = match;
            if(match)
            {
                xBDD.CurrentRun
                    .AddScenario()
                    .SetOutputWriter(outputWriter)
                    .Given(s.Given.a_target_of)
                    .And(s.Given.a_matching_pattern_of)
                    .When(s.When.the_target_is_compared_to_the_matching_pattern)
                    .Then(s.Then.the_result_should_be_match)
                    .Run();
            }
            else
            {
                s.State.ExceptionMessage = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\Helpers\\TestFiles\\" + scenario + "Exception.txt");
                xBDD.CurrentRun
                    .AddScenario()
                    .SetOutputWriter(outputWriter)
                    .Given(s.Given.a_target_of)
                    .And(s.Given.a_matching_pattern_of)
                    .When(s.When.the_target_is_compared_to_the_matching_pattern)
                    .Then(s.Then.an_exception_should_be_thrown)
                    .And(s.Then.the_exception_message_should_be)
                    .Run();
            }
        }
    }
}
