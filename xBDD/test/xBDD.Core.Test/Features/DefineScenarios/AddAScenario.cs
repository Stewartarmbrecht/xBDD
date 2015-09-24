using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

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
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasMethod("\\Features\\DefineScenarios\\SampleCode\\AddAScenarioDefaultSample.cs"))
                .When(Code.ExecuteMethod(() =>
                {
                    sut.Object = new SampleCode.AddAScenarioDefaultSample().DefaultScenarioAdd();
                }))
                .Then(ScenarioTarget.ShouldBeCreated(sut))
                .And(ScenarioTarget.NameShouldMatchMethodName("Default Scenario Add", sut))
                .And(ScenarioTarget.FeatureNameShouldMatchClassName("Add A Scenario Default Sample", sut))
                .And(ScenarioTarget.AreaPathShouldMatchNamespace("xBDD.Core.Test.Features.DefineScenarios.SampleCode", sut))
                .Run();
        }
        [ScenarioFact]
        public void WithExplicitName()
        {
            Wrapper<Scenario> sut = new Wrapper<Scenario>();
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasMethod("\\Features\\DefineScenarios\\SampleCode\\AddAScenarioExplicitNameSample.cs"))
                .When(Code.ExecuteMethod(() =>
                {
                    sut.Object = new SampleCode.AddAScenarioExplicitNameSample().WithExplicitName();
                }))
                .Then(ScenarioTarget.ShouldBeCreated(sut))
                .And(ScenarioTarget.NameShouldMatchMethodName("My Explicit Scenario Name", sut))
                .And(ScenarioTarget.FeatureNameShouldMatchClassName("Add A Scenario Explicit Name Sample", sut))
                .And(ScenarioTarget.AreaPathShouldMatchNamespace("xBDD.Core.Test.Features.DefineScenarios.SampleCode", sut))
                .Run();
        }
    }
}
