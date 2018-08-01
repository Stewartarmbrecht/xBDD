using xb = xBDD.Model;
using System;
using xBDD.API.Model.Entities;
using xBDD.API.Model.Messages;

namespace xBDD.Reporting.Service.Core
{
    public class PayloadFactory
    {
        public Scenario CreateScenario(xb.Scenario scenario, TestRun testRun)
        {
            Outcome outcome;
            Enum.TryParse<Outcome>(Enum.GetName(typeof(xb.Outcome), scenario.Outcome), out outcome);
            return new Scenario()
            {
                Id = Guid.NewGuid(),
                TestRunId = testRun.Id,
                AreaPath = scenario.Feature.Area.Name,
                FeatureName = scenario.Feature.Name,
                Name = scenario.Name,
                Outcome = outcome,
                Reason = scenario.Reason,
                EndTime = scenario.EndTime,
                StartTime = scenario.StartTime
            };
        }

        public Step CreateStep(xb.Step step, Scenario scenario)
        {
            Outcome outcome;
            Enum.TryParse<Outcome>(Enum.GetName(typeof(xb.Outcome), step.Outcome), out outcome);
            return new Step()
            {
                Id = Guid.NewGuid(),
                PartitionKey = scenario.TestRunId.ToString() + scenario.Id.ToString(),
                EndTime = step.EndTime,
                Exception = step.Exception == null ? null : step.Exception.Message + "\n" + step.Exception.StackTrace,
                ActionType = Enum.GetName(typeof(xBDD.Model.ActionType), step.ActionType),
                Name = step.Name,
                Outcome = outcome,
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
                ConfigurationId = new Guid("d67aeda0-2f87-4e50-a476-eedd82a79cb4")
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