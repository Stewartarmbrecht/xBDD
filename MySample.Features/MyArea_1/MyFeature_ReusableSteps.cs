namespace MySample.Features.MyArea_1
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;
    using MySample.Actors;

    [TestClass]
    [AsA(MyActor.Name)]
    [YouCan("have my feature 1 value")]
    [By("execute my feature 1")]
    public class MyFeature_ReusableSteps: FeatureTestClass
    {
        MyActor you = new MyActor();

        [TestMethod]
        public async Task MyScenario_WithReusableSteps()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given(you.ExcuteFirstAction())
                .When(you.ExcuteAnotherAction())
                .Then(you.WillSeeAResult())
                .Run();
        }
    }
}

