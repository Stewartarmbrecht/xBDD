namespace xBDD
{
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading;
    using xBDD.Model;
    using xBDD.Reporting;
    using xBDD.Reporting.Html;
    using xBDD.Reporting.TextFile;
    using xBDD.Reporting.Database;
    using xBDD.Reporting.Database.Core;

    /// <summary>
    /// List of extension methods for the TestRun class.
    /// </summary>
    public static class TestRunExtensions
    {
        /// <summary>
        /// Calculates the start and end time for the test run, 
        /// areas, and features.
        /// </summary>
        /// <param name="testrun">The test run to set the start and end times for.</param>
        public static void CalculateStartAndEndTimes(this xBDD.Model.TestRun testrun)
        {
            testrun.Areas.ForEach(area => {
                var featuresStart = area.Features.OrderBy(feature => feature.StartTime);
                featuresStart.ToList().ForEach(feature => {
                    var scenariosStart = feature.Scenarios.OrderBy(scenario => scenario.StartTime);
                    feature.StartTime = scenariosStart.First().StartTime;
                    var scenariosEnd = feature.Scenarios.OrderByDescending(scenario => scenario.EndTime);
                    feature.EndTime = scenariosEnd.First().EndTime;
                });
                area.StartTime = featuresStart.First().StartTime;
                var featuresEnd = area.Features.OrderByDescending(feature => feature.EndTime);
                area.EndTime = featuresEnd.First().EndTime;
            });
            if(testrun.Areas.Count > 0) {
                var areasStart = testrun.Areas.OrderBy(area => area.StartTime);
                testrun.StartTime = areasStart.First().StartTime;
                var areasEnd = testrun.Areas.OrderByDescending(area => area.EndTime);
                testrun.EndTime = areasEnd.First().EndTime;
            }
        }
        /// <summary>
        /// Writes a text representation of a test run's test results.
        /// </summary>
        /// <param name="testRun">The test run whose results you want to write to text.</param>
        /// <returns>String that is a multiline text format of the test results.</returns>
        public static async Task<string> WriteToText(this xBDD.Model.TestRun testRun)
        {
            ReportingFactory factory = new ReportingFactory();
            TextWriter saver = factory.GetTextFileWriter();
            return await saver.WriteToString(testRun);
        }

        /// <summary>
        /// Writes a text representation of a test run's test results.
        /// </summary>
        /// <param name="testRun">The test run whose results you want to write to text.</param>
        /// <param name="areaNameSkip">The starting part of the area names you want to remove.</param>
        /// <param name="failuresOnly">Tells the html writer to only write out failed scenarios.</param>
        /// <returns>String that is a multiline text format of the test results.</returns>
        public static async Task<string> WriteToHtml(this xBDD.Model.TestRun testRun, string areaNameSkip = "", bool failuresOnly = false)
        {
            ReportingFactory factory = new ReportingFactory();
            HtmlWriter saver = factory.GetHtmlFileWriter(areaNameSkip, failuresOnly);
            return await saver.WriteToString(testRun);
        }
        /// <summary>
        /// Writes a a test run's test results to a sql database.
        /// </summary>
        /// <param name="testRun">The test run whose results you want to write to the database.</param>
        /// <param name="connectionName">The name of the connection string to use to connect to the database.</param>
        /// <remarks>By default xBDD will look for a connection string in a config.json file or the 
        /// environment variables settings with a name: Data:DefaultConnection:ConnectionString</remarks>
        /// <returns>Count of scenarios written to the database.</returns>
        public static int SaveToDatabase(this xBDD.Model.TestRun testRun, string connectionName)
        {
            DatabaseFactory factory = new DatabaseFactory();
            TestRunDatabaseSaver saver = factory.CreateTestRunDatabaseSaver(connectionName);
            return saver.SaveTestRun(testRun);
        }
        /// <summary>
        /// Writes the test run results to json.
        /// Only writes the bare minimum properties and does not 
        /// write calculated properties like test stats.
        /// </summary>
        /// <param name="testRun">The test run to serialize.</param>
        /// <param name="addIndentation">Adds indentation to the json.</param>
        /// <returns>A json string representation of the test results.</returns>
        public static string WriteToJson(this xBDD.Model.TestRun testRun, bool addIndentation = false)
        {
            var json = "";
            using(var ms = new System.IO.MemoryStream()) {
                using(var writer = JsonReaderWriterFactory.CreateJsonWriter(ms, Encoding.UTF8, true, addIndentation))
                {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                    try {
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Model.TestRun));  
                        ser.WriteObject(writer, testRun);
                        writer.Flush();
                        byte[] jsonBytes = ms.ToArray();
                        json = Encoding.UTF8.GetString(jsonBytes, 0, jsonBytes.Length);
                    } finally {
                        Thread.CurrentThread.CurrentCulture = currentCulture;
                    }
                }
            }
            return json;
        }
    }
}
