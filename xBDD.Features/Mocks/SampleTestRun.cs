namespace SampleApp.Features
{
    using xBDD;
    using System.Threading.Tasks;
    using SampleApp.Features.SampleTestRunFeatures;

    public static class SampleTestRun
    {
        public static async Task<xBDDMock> RunTests()
        {
            xBDDMock xBMock = new xBDDMock();
            var feature2 = new SamplePassingFeature(xBMock);
            await feature2.PassingScenario1();
            await feature2.PassingScenario2();
            await feature2.PassingScenario3();
            var feature3 = new SampleSkippedFeature(xBMock);
            await feature3.PassingScenario1();
            await feature3.PassingScenario2();
            await feature3.SkippedScenario();
            var feature1 = new SampleAllOutcomeFeature(xBMock);
            await feature1.PassingScenario();
            await feature1.SkippedScenario();
            try {
                await feature1.FailedScenario();
            } catch {}
            return xBMock;
        }
    }
}