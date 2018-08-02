using xBDD.Reporting.Service.Core;
using xb = xBDD.Model;
using System.Threading.Tasks;

namespace xBDD
{
    public static class xBDDExtensions
    {
        public static async Task<int> SaveToService(this xb.TestRun testRun, string url)
        {
            PayloadFactory factory = new PayloadFactory();
            TestRunPayloadSaver saver = factory.CreateTestRunPayloadSaver(url);
            return await saver.SaveTestRun(testRun);
        }
    }
}
