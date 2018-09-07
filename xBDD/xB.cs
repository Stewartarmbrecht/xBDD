namespace xBDD
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
	using System.IO;
    using xBDD.Core;
    using xBDD.Model;
    using xBDD.Utility;

    /// <summary>
    /// Root class of the testing framework.
    /// </summary>
    public partial class xB
    {
        static CoreFactory factory;
        static TestRunBuilder testRunBuilder;
        /// <summary>
        /// Provides access to the test run builder used across all tests in the test run.
        /// </summary>
        /// <value>TestRunBuilder</value>
        public static TestRunBuilder CurrentRun
        {
            get
            {
                EnsureFactory();
                if (testRunBuilder == null)
                {
                    testRunBuilder = factory.CreateTestRunBuilder(null);
                }
                return testRunBuilder;
            }
            set
            {
                testRunBuilder = value;
            }
        }

        /// <summary>
        /// Creates a step that can be added to a scenario that will executed synchronously.
        /// </summary>
        /// <param name="stepName">The text to display for the step.</param>
        /// <param name="action">The action that will be called when executing the step.</param>
        /// <param name="input">The multiline parameter to display below the step.</param>
        /// <param name="inputFormat">The format to use when displaying the multiline paramter.</param>
        /// <param name="explanation">A explanation of what the step does if needed.true  Html reporting tools will respect markdown syntax.<see cref="TextFormat"/></param>
        /// <returns>New step that can be added to a scenario.</returns>
        public static Step CreateStep(
            string stepName, 
            Action<Step> action = null, 
            string input = "",
            TextFormat inputFormat = TextFormat.text,
			string explanation = null)
        {
            action = action ?? ((s) => { });
            return factory.CreateStep(stepName, action, input, inputFormat, explanation);
        }

        /// <summary>
        /// Creates a step that can be added to a scenario that will executed synchronously.
        /// </summary>
        /// <param name="stepName">The text to display for the step.</param>
        /// <param name="action">The asynchronous function to call.</param>
        /// <param name="input">The multiline parameter to display below the step.</param>
        /// <param name="inputFormat">The format to use when displaying the multiline paramter.</param>
        /// <param name="explanation">A explanation of what the step does if needed.true  Html reporting tools will respect markdown syntax.<see cref="TextFormat"/></param>
        /// <returns>New async step that can be added to a scenario.</returns>
        public static Step CreateAsyncStep(
            string stepName, 
            Func<Step, Task> action = null,
            string input = "",
            TextFormat inputFormat = TextFormat.text,
			string explanation = null)
        {
            action = action ?? ((s) => { return Task.Run(() => { }); });
            return factory.CreateStep(stepName, action, input, inputFormat, explanation);
        }

        /// <summary>
        /// This method should be called from within the test method.
        /// It uses reflection to get the calling method name and it expects
        /// to recieve a reference of the test class to get the name of the 
        /// feature and namespace.
        /// </summary>
        /// <param name="featureClass">
        /// A reference to the parent class that implements the Ifeature interface for the scenario.  
        /// Usually just pass in 'this'.  The test class represents the feature.ß
        /// </param>
        /// <param name="methodName">Optional. The system will attempt to get the method name of the scenario through reflection.</param>
        /// <param name="sortOrder">Optional. Used by the test run when sorting the results
        /// if you call SortTestRunResults on the test run. Default value is 1,000,000.</param>
        /// <returns>The scenario build for a fluent syntax.</returns>
        public static ScenarioBuilder AddScenario(IFeature featureClass, int sortOrder = 1000000, [CallerMemberName]string methodName = "")
        {
            //TODO: Fix hack to ensure factory exists.
            var currentRun = xB.CurrentRun;
            CodeDetails codeDetails = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            var scenarioBuilder = xB.CurrentRun.AddScenario(codeDetails, null, null, null, sortOrder);
            scenarioBuilder.SetOutputWriter(featureClass.OutputWriter);
            return scenarioBuilder;
        }

        /// <summary>
        /// This method should be called from within the test method.
        /// It uses reflection to get the calling method name and it expects
        /// to recieve a reference of the test class to get the name of the 
        /// feature and namespace.
        /// </summary>
        /// <param name="featureClass">
        /// A reference to the parent class that implements the Ifeature interface for the scenario.  
        /// Usually just pass in 'this'.  The test class represents the feature.ß
        /// </param>
        /// <param name="methodName">Optional. The system will attempt to get the method name of the scenario through reflection.</param>
        /// <param name="sortOrder">Optional. Used by the test run when sorting the results
        /// if you call SortTestRunResults on the test run. Default value is 1,000,000.</param>
        /// <returns>The scenario build for a fluent syntax.</returns>
        public static ScenarioBuilder AddScenario(object featureClass, int sortOrder = 0, [CallerMemberName]string methodName = "")
        {
            //TODO: Fix hack to ensure factory exists.
            var currentRun = xB.CurrentRun;
            CodeDetails codeDetails = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            return xB.CurrentRun.AddScenario(codeDetails, null, null, null, sortOrder);
        }

        static void EnsureFactory()
        {
            if (factory == null)
                factory = new CoreFactory();
        }

		/// <summary>
		/// Initializes the xBDD system prior to running tests.
		/// Currenly just reads the Watch Browser setting from the config file.
		/// </summary>
		public static void Initialize() {
			xBDD.Browser.WebBrowser.WatchBrowser = Configuration.WatchBrowswer;
		}

		/// <summary>
		/// Generates standard reports from a test run and 
		/// Closes the shared web driver and 
		/// </summary>
		public static void Complete(string projectName, ISorting sorting, Action<string> writeOutput) {
            xBDD.Browser.WebDriver.Close();

            var directory = System.IO.Directory.GetCurrentDirectory();

            xB.CurrentRun.TestRun.Name = Configuration.TestRunName;

            System.IO.Directory.CreateDirectory($"{directory}/../../../test-results");

            xB.CurrentRun.TestRun.SortTestRunResults(sorting.GetSortedFeatureNames());
            xB.CurrentRun.TestRun.UpdateParentReasonsAndStats(sorting.GetSortedReasons());

            var htmlPath = $"{directory}/../../../test-results/{projectName}.Results.html";
            writeOutput("Writing Html Report to " + htmlPath);
            var htmlReport = xB.CurrentRun.TestRun.WriteToHtmlTestRunReport(Configuration.RemoveFromAreaNameStart, Configuration.FailuresOnly);
            File.WriteAllText(htmlPath, htmlReport);

            var textPath = $"{directory}/../../../test-results/{projectName}.Results.txt";
            writeOutput("Writing Text Report to " + textPath);
            var textReport = xB.CurrentRun.TestRun.WriteToText();
            File.WriteAllText(textPath, textReport);

            var textOutlinePath = $"{directory}/../../../test-results/{projectName}.Results.Outline.txt";
            writeOutput("Writing Text Outline Report to " + textOutlinePath);
            var textOutlineReport = xB.CurrentRun.TestRun.WriteToText(false);
            File.WriteAllText(textOutlinePath, textOutlineReport);

            var jsonPath = $"{directory}/../../../test-results/{projectName}.Results.json";
            writeOutput("Writing Json Report to " + jsonPath);
            var jsonReport = xB.CurrentRun.TestRun.WriteToJson();
            File.WriteAllText(jsonPath, jsonReport);

            var opmlPath = $"{directory}/../../../test-results/{projectName}.Results.opml";
            writeOutput("Writing OPML Report to " + opmlPath);
            var opmlReport = xB.CurrentRun.TestRun.WriteToOpml();
            File.WriteAllText(opmlPath, opmlReport);

		}
    }
}
