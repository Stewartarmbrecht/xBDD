using Xunit;
using Xunit.Abstractions;
using xBDD.Model;
using xBDD.Test;
using xBDD.xUnit;

namespace xBDD.Core.Test.Features.DefineScenarios
{
    [Collection("xBDDCoreTest")]
    public class AddAStep
    {
        private readonly OutputWriter outputWriter;

        public AddAStep(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void Given()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<Step> stepWrapper = new Wrapper<Step>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAGivenStep.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAGivenStep().Add().Scenario;
                }))
                .Then(ScenarioTarget.WillBeCreated(scenarioWrapper))
                .And(ScenarioTarget.WillHaveAStep(1,scenarioWrapper, stepWrapper))
                .And(StepTarget.NameWillBe("my starting condition", stepWrapper))
                .And(StepTarget.FullNameWillBe("Given my starting condition", stepWrapper))
                .And(StepTarget.ActionWillNotBeNull(stepWrapper))
                .And(StepTarget.ActionTypeWillBe(ActionType.Given, stepWrapper))
                .Run();
        }
        [ScenarioFact]
        public void WithNoAction()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<Step> stepWrapper = new Wrapper<Step>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAGivenStepWithNoAction.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAGivenStepWithNoAction().Add().Scenario;
                }))
                .Then(ScenarioTarget.WillBeCreated(scenarioWrapper))
                .And(ScenarioTarget.WillHaveAStep(1, scenarioWrapper, stepWrapper))
                .And(StepTarget.NameWillBe("my starting condition that needs no action", stepWrapper))
                .And(StepTarget.FullNameWillBe("Given my starting condition that needs no action", stepWrapper))
                .And(StepTarget.ActionWillNotBeNull(stepWrapper))
                .And(StepTarget.ActionTypeWillBe(ActionType.Given, stepWrapper))
                .Run();
        }
        [ScenarioFact]
        public void Async()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<Step> stepWrapper = new Wrapper<Step>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAnAsyncStep.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAnAsyncStep().Add().Scenario;
                }))
                .Then(ScenarioTarget.WillBeCreated(scenarioWrapper))
                .And(ScenarioTarget.WillHaveAStep(1, scenarioWrapper, stepWrapper))
                .And(StepTarget.NameWillBe("my async starting condition", stepWrapper))
                .And(StepTarget.FullNameWillBe("Given my async starting condition", stepWrapper))
                .And(StepTarget.AsyncActionWillNotBeNull(stepWrapper))
                .And(StepTarget.ActionTypeWillBe(ActionType.Given, stepWrapper))
                .Run();
        }
        [ScenarioFact]
        public void When()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<Step> stepWrapper = new Wrapper<Step>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAWhenStep.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAWhenStep().Add().Scenario;
                }))
                .Then(ScenarioTarget.WillBeCreated(scenarioWrapper))
                .And(ScenarioTarget.WillHaveAStep(2, scenarioWrapper, stepWrapper))
                .And(StepTarget.NameWillBe("my action", stepWrapper))
                .And(StepTarget.FullNameWillBe("When my action", stepWrapper))
                .And(StepTarget.ActionWillNotBeNull(stepWrapper))
                .And(StepTarget.ActionTypeWillBe(ActionType.When, stepWrapper))
                .Run();
        }
        [ScenarioFact]
        public void Then()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<Step> stepWrapper = new Wrapper<Step>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAThenStep.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAThenStep().Add().Scenario;
                }))
                .Then(ScenarioTarget.WillBeCreated(scenarioWrapper))
                .And(ScenarioTarget.WillHaveAStep(3, scenarioWrapper, stepWrapper))
                .And(StepTarget.NameWillBe("my ending condition", stepWrapper))
                .And(StepTarget.FullNameWillBe("Then my ending condition", stepWrapper))
                .And(StepTarget.ActionWillNotBeNull(stepWrapper))
                .And(StepTarget.ActionTypeWillBe(ActionType.Then, stepWrapper))
                .Run();
        }
        [ScenarioFact]
        public void And()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<Step> stepWrapper = new Wrapper<Step>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAnAndStep.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAnAndStep().Add().Scenario;
                }))
                .Then(ScenarioTarget.WillBeCreated(scenarioWrapper))
                .And(ScenarioTarget.WillHaveAStep(4, scenarioWrapper, stepWrapper))
                .And(StepTarget.NameWillBe("my extra ending condition", stepWrapper))
                .And(StepTarget.FullNameWillBe("And my extra ending condition", stepWrapper))
                .And(StepTarget.ActionWillNotBeNull(stepWrapper))
                .And(StepTarget.ActionTypeWillBe(ActionType.And, stepWrapper))
                .Run();
        }
        [ScenarioFact]
        public void ReusableStep()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<Step> stepWrapper = new Wrapper<Step>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAReusableStep.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAReusableStep().Add().Scenario;
                }))
                .And(ScenarioTarget.WillHaveAStep(1, scenarioWrapper, stepWrapper))
                .And(StepTarget.NameWillBe("the user performs an action", stepWrapper))
                .Run();
        }
        [ScenarioFact]
        public void ReusableStepThatTakesAStaticParameter()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<Step> stepWrapper = new Wrapper<Step>();
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\AddAReusableStepThatTakesAStaticParameter.cs"))
                .When(Code.IsExecuted((s) =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAReusableStepThatTakesAStaticParameter().Add().Scenario;
                }))
                .And(ScenarioTarget.WillHaveAStep(1, scenarioWrapper, stepWrapper))
                .And(StepTarget.NameWillBe("the user performs a 'save' action", stepWrapper))
                .Run();
        }
        [ScenarioFact]
        public void AsyncFunctionInSyncStep()
        {
            xB.CurrentRun
                .AddScenario(this)
                .Skip("Not Started");
        }
    }
}
