using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features.RunningScenarios
{
    public class CaptureStepOutcome
    {
        [Fact]
        public async Task WhenPassingRun()
        {
            DateTime capturedTime = DateTime.Now;
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(step => {
                System.Threading.Thread.Sleep(10);
                capturedTime = DateTime.Now;
                System.Threading.Thread.Sleep(10);
            });
            scenario.Run();
            Assert.True(scenario.Steps[0].Outcome == Outcome.Passed);
        }

        [Fact]
        public async Task WhenFailingRun()
        {
            DateTime capturedTime = DateTime.Now;
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(step => 
            {
                System.Threading.Thread.Sleep(10);
                capturedTime = DateTime.Now;
                System.Threading.Thread.Sleep(10);
                throw new Exception("Deliberate");
            });
            var hit = false;
            try
            {
                scenario.Run();
            }
            catch(Exception ex)
            {
                hit = true;
                Assert.Equal("Deliberate", ex.Message);
                Assert.True(scenario.Steps[0].Outcome == Outcome.Failed);
            }
            Assert.True(hit);
        }
    }
}
