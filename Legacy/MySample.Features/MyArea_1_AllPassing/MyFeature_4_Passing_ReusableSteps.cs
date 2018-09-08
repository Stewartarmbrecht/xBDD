namespace MySample.Features.MyArea_1_AllPassing
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
    public class MyFeature_4_Passing_ReusableSteps: FeatureTestClass
    {
        MyActor you = new MyActor();

        [TestMethod]
        public async Task MyScenario_10_WithReusableSteps()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given(you.ExcuteStep28())
                .When(you.ExcuteStep29())
                .Then(you.ExcuteStep30())
                .Run();
        }
    }
}

