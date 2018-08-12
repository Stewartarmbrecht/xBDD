using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using xBDD;
using System.IO;
using System.Threading.Tasks;

namespace xBDD.Features
{
    public class TestPublisher
    {
        public async static Task PublishResults(string skipAreaName)
        {
            //if(TestConfiguration.Publish)
            //{
                //Logger.LogMessage("Writing Results to the database.");
                //xB.CurrentRun.TestRun.SaveToDatabase(TestConfiguration.DatabaseConnectionString);
                //Logger.LogMessage(TestConfiguration.xBDDPublishURL);
                //await xB.CurrentRun.TestRun.SaveToService(TestConfiguration.xBDDPublishURL);

                var separator = System.IO.Path.DirectorySeparatorChar;

                var directory = System.IO.Directory.GetCurrentDirectory();
                var htmlPath = directory + $"{separator}../../../test-results/xBDD.Features.Results.html";
                Logger.LogMessage("Writing Html Report to " + htmlPath);
                var failuresOnlyEnv = System.Environment.GetEnvironmentVariable("XBDD_FAILURES_ONLY");
                var failuresOnly = false;
                if(failuresOnlyEnv != null)
                {
                    System.Boolean.TryParse(failuresOnlyEnv, out failuresOnly);
                }
                xB.CurrentRun.SortTestRunResults(new FeatureSort().SortedFeatureNames);
                var htmlReport = await xB.CurrentRun.TestRun.WriteToHtml(skipAreaName, failuresOnly);
                File.WriteAllText(htmlPath, htmlReport);

                var textPath = directory + $"{separator}../../../test-results/xBDD.Features.Results.txt";
                Logger.LogMessage("Writing Text Report to " + textPath);
                var textReport = await xB.CurrentRun.TestRun.WriteToText();
                File.WriteAllText(textPath, textReport);
            //}
        }
    }
}
