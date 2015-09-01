using System;
using System.Linq;
using xBDD.Stats;
using xBDD.Test.Utilities;
using Xunit;

namespace xBDD.Test.Features
{
    public class BuildTestRunStatistics
    {
        ITestRun testRun;
        ITestRunStats testRunStats;
        [Fact(Skip = "Not Ready to Write")]
        public void SimpleTestRunTime()
        {
            var s = xBDD.CurrentRun.AddScenario();
            s.Given(SimpleTestRunCompleted);
            s.When(StatsAreCompiled);
            s.Then(TheRootAreaStartTimeShouldBeEqualToTheEarliestStepStartTimeForTheTestRun);
            s.And(TheRootAreaEndTimeShouldBeEqualToTheLatestStepEndTimeForTheTestRun);
            s.And(TheRootAreaDurationShouldBeTheDifferenceBetweenTheStartTimeAndEndTime);
            s.And(TheRootAreaTimeShouldBeTheAggregateOfAllStepDurations);
            s.Run();
        }

        private void TheRootAreaTimeShouldBeTheAggregateOfAllStepDurations(IStep obj)
        {
            throw new NotImplementedException();
        }

        private void TheRootAreaDurationShouldBeTheDifferenceBetweenTheStartTimeAndEndTime(IStep obj)
        {
            throw new NotImplementedException();
        }

        private void TheRootAreaEndTimeShouldBeEqualToTheLatestStepEndTimeForTheTestRun(IStep obj)
        {
            throw new NotImplementedException();
        }

        private void TheRootAreaStartTimeShouldBeEqualToTheEarliestStepStartTimeForTheTestRun(IStep obj)
        {
            throw new NotImplementedException();
        }

        private void TheRootAreaStartTimeShouldBeEqualToTheEarliestStepForTheTestRun(IStep obj)
        {
            DateTime minTime = testRun.Steps.Select(step => step.StartTime).Min();
            DateTime maxTime = testRun.Steps.Select(step => step.EndTime).Max();
            Assert.Equal(testRunStats.RootArea.TimeStats.StartTime, minTime);
        }

        private void StatsAreCompiled(IStep obj)
        {
            testRunStats = xBDD.StatsCompiler.CompileStats(testRun);
        }

        private void SimpleTestRunCompleted(IStep obj)
        {
            TestRunBuilder testRunBuilder = new TestRunBuilder();
            testRun = testRunBuilder.BuildPassingTestRun();
        }
    }
}
