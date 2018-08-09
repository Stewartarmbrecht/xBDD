namespace xBDD
{

    using System.Threading.Tasks;
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
    }
}
