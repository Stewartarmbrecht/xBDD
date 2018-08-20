using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xBDD.Test
{
    using xBDD.Core;
    using xBDD.Model;

    [TestClass]
    public class StatsCascaderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cf = new CoreFactory();
            var tr = cf.CreateTestRun("testrun");
            var trb = new TestRunBuilder(new CoreFactory(), tr);
            trb.AddScenario("scenario1", "feature1", "area1").Given("step1").When("step2").Then("step3");
            trb.AddScenario("scenario2", "feature1", "area1").Given("step1").When("step2").Then("step3");
            trb.AddScenario("scenario3", "feature1", "area1").Given("step1").When("step2").Then("step3");
            trb.TestRun.Scenarios[0].Steps[0].Outcome = Outcome.Passed;
            trb.TestRun.Scenarios[0].Steps[1].Outcome = Outcome.Passed;
            trb.TestRun.Scenarios[0].Steps[2].Outcome = Outcome.Passed;
            var factory = new xBDD.Utility.UtilityFactory();
            var sut = new xBDD.Core.StatsCascader(factory);
            sut.CascadeStepStats(trb.TestRun.Scenarios[0].Steps[0], false);
        }
    }
}
