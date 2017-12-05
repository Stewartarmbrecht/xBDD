using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using xBDD;
using System.IO;
using System.Threading.Tasks;

namespace xBDD.Test
{
    public class TestPublisher
    {
        public async static Task PublishResults()
        {
            if(TestConfiguration.Publish)
            {
                Logger.LogMessage("Writing Results to the database.");
                //xB.CurrentRun.TestRun.SaveToDatabase(TestConfiguration.DatabaseConnectionString);
                Logger.LogMessage(TestConfiguration.xBDDPublishURL);
                await xB.CurrentRun.TestRun.SaveToService(TestConfiguration.xBDDPublishURL);

                var directory = System.IO.Directory.GetCurrentDirectory();
                var path = directory + $"{System.IO.Path.DirectorySeparatorChar}xBDD.Test.Results.html";
                var htmlReport = await xB.CurrentRun.TestRun.WriteToHtml();
                Logger.LogMessage("Writing Html Report to " + path);
                File.WriteAllText(path, htmlReport);
            }
        }
    }
}
