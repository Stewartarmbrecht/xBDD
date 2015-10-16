using Xunit;
using Xunit.Abstractions;
using xBDD.Model;
using xBDD.Test;
using xBDD.xUnit;

namespace xBDD.Core.Test.Features.DefineScenarios
{
    [Collection("xBDDCoreTest")]
    public class AddAScenario
    {

        private readonly OutputWriter outputWriter;

        public AddAScenario(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void DefaultMethod()
        {
            Wrapper<Scenario> sut = new Wrapper<Scenario>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAScenarioDefaultSample.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    sut.Object = new SampleCode.AddAScenarioDefaultSample().DefaultScenarioAdd().Scenario;
                }))
                .Then(ScenarioTarget.WillBeCreated(sut))
                .And(ScenarioTarget.NameWillMatchMethodName("Default Scenario Add", sut))
                .And(ScenarioTarget.FeatureNameWillMatchClassName("Add A Scenario Default Sample", sut))
                .And(ScenarioTarget.AreaPathWillMatchNamespace("xBDD - Core - Test - Features - Define Scenarios - Sample Code", sut))
                .Run();
        }
        [ScenarioFact]
        public void WithExplicitName()
        {
            Wrapper<Scenario> sut = new Wrapper<Scenario>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAScenarioExplicitNameSample.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    sut.Object = new SampleCode.AddAScenarioExplicitNameSample().WithExplicitName().Scenario;
                }))
                .Then(ScenarioTarget.WillBeCreated(sut))
                .And(ScenarioTarget.NameWillMatchMethodName("My Explicit Scenario Name", sut))
                .And(ScenarioTarget.FeatureNameWillMatchClassName("Add A Scenario Explicit Name Sample", sut))
                .And(ScenarioTarget.AreaPathWillMatchNamespace("xBDD - Core - Test - Features - Define Scenarios - Sample Code", sut))
                .Run();
        }
    }
}
