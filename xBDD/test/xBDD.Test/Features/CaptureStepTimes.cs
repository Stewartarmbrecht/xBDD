using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features
{
    public class CaptureStepTimes
    {
        [Fact]
        public void WhenPassingRun()
        {
            DateTime capturedTime = DateTime.Now;
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(step => {
                System.Threading.Thread.Sleep(10);
                capturedTime = DateTime.Now;
                System.Threading.Thread.Sleep(10);
            });
            scenario.Run();
            Assert.True(scenario.Steps[0].StartTime < capturedTime);
            Assert.True(scenario.Steps[0].EndTime > capturedTime);
        }

        [Fact]
        public void WhenFailingRun()
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
                Assert.True(scenario.Steps[0].StartTime < capturedTime);
                Assert.True(scenario.Steps[0].EndTime > capturedTime);
            }
            Assert.True(hit);
        }
    }
}
