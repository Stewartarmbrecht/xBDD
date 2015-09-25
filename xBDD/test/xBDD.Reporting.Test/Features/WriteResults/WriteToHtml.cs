﻿using System;
using System.Runtime.CompilerServices;
using xBDD.Reporting.Test.Steps;
using xBDD.Test;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.WriteResults
{
    [Collection("xBDDReportingTest")]
    public class WriteToHtml
    {
        private readonly OutputWriter outputWriter;

        public WriteToHtml(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        public void Run(IExecute<string> action, bool writeActual = false, [CallerMemberName]string methodName = "")
        {
            var actionName = action.GetType().Name;
            Wrapper<string> text = new Wrapper<string>();
            xBDD.CurrentRun
                .AddScenario(this, methodName)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasMethod("\\Features\\WriteResults\\Scenarios\\" + actionName + ".cs"))
                .When(Code.ExecuteMethod(() =>
                {
                    text.Object = action.Execute();
                }))
                .Then(TestResults.ShouldMatch(
                    "\\Features\\WriteResults\\Scenarios\\" + actionName + ".txt", text, writeActual))
                .Run();
        }

        //[ScenarioFact]
        //public void WriteEmtpyTestRun()
        //{
        //    Run(new Scenarios.EmptyTestRun());
        //}
        //[ScenarioFact]
        //public void WriteSkippedEmptyScenario()
        //{
        //    Run(new Scenarios.SkippedEmptyScenario());
        //}
        //[ScenarioFact]
        //public void WriteRunEmptyScenario()
        //{
        //    Run(new Scenarios.RunEmptyScenario());
        //}
        //[ScenarioFact]
        //public void WriteSkippedScenarioWithSteps()
        //{
        //    Run(new Scenarios.SkippedScenarioWithSteps());
        //}
        //[ScenarioFact]
        //public void WriteRunScenarioWithSteps()
        //{
        //    Run(new Scenarios.RunScenarioWithSteps());
        //}
        //[ScenarioFact]
        //public void WriteRunScenarioWithSkippedStep()
        //{
        //    Run(new Scenarios.RunScenarioWithSkippedStep());
        //}
        //[ScenarioFact]
        //public void WriteRunScenarioWithNotImplementedStep()
        //{
        //    Run(new Scenarios.RunScenarioWithNotImplementedStep());
        //}
        //[ScenarioFact]
        //public void WriteRunScenarioWithFailedStep()
        //{
        //    Run(new Scenarios.RunScenarioWithFailedStep());
        //}
        //[ScenarioFact]
        //public void WriteRunMultipleScenariosSameFeature()
        //{
        //    Run(new Scenarios.RunMultipleScenariosSameFeature());
        //}
        //[ScenarioFact]
        //public void WriteRunMultipleFeaturesSameArea()
        //{
        //    Run(new Scenarios.RunMultipleFeaturesSameArea());
        //}
        //[ScenarioFact]
        //public void WriteRunMultipleAreas()
        //{
        //    Run(new Scenarios.RunMultipleAreas());
        //}
        //[ScenarioFact]
        //public void WriteRunScenarioWithStepWithMultilineParameter()
        //{
        //    Run(new Scenarios.RunScenarioWithStepWithMultilineParameter());
        //}
    }
}
