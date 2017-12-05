using xb = xBDD.Model;
using System;

namespace xBDD.Reporting.Service.Core
{
    public class PayloadFactory
    {
        public Scenario CreateScenario(xb.Scenario scenario, TestRun testRun)
        {
            return new Scenario()
            {
                Id = Guid.NewGuid(),
                TestRunId = testRun.Id,
                AreaPath = scenario.Feature.Area.Name,
                FeatureName = scenario.Feature.Name,
                Name = scenario.Name,
                Outcome = scenario.Outcome,
                Reason = scenario.Reason,
                EndTime = scenario.EndTime,
                StartTime = scenario.StartTime
            };
        }

        public Step CreateStep(xb.Step step, Scenario scenario)
        {
            return new Step()
            {
                Id = Guid.NewGuid(),
                ScenarioId = scenario.Id,
                EndTime = step.EndTime,
                Exception = step.Exception == null ? null : step.Exception.Message + "\n" + step.Exception.StackTrace,
                ActionType = Enum.GetName(typeof(xBDD.Model.ActionType), step.ActionType),
                Name = step.Name,
                Outcome = step.Outcome,
                Reason = step.Reason,
                StartTime = step.StartTime,
                MultilineParameter = step.MultilineParameter
            };
        }

        public TestRun CreateTestRun(xb.TestRun testRun)
        {
            return new TestRun()
            {
                Id = Guid.NewGuid(),
                Name = testRun.Name
            };
        }

        public PayloadObjectBuilder CreatePayloadObjectBuilder()
        {
            PayloadFactory payloadFactory = CreatePayloadFactory();
            return new PayloadObjectBuilder(payloadFactory);
        }

        public PayloadFactory CreatePayloadFactory()
        {
            return new PayloadFactory();
        }

        public TestRunPayloadSaver CreateTestRunPayloadSaver(string url)
        {
            return new TestRunPayloadSaver(this, url);
        }
    }
}