namespace xBDD.Reporting.Code
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using xBDD.Model;

    /// <summary>
    /// Writes code files that can be used to recreate the test run provided.
    /// This will allow other tools to build test runs so that you can use this 
    /// class to generate new files in your test project.
    /// </summary>
    public class CodeWriter
    {
        /// <summary>
        /// Writes all files necessary to build and run a project that would produce the same results as captured in the test run.
        /// </summary>
        /// <param name="testRun">The test run to use to build feature classes and scenario methods.</param>
        /// <param name="rootNamespace">The root namspace to use.</param>
        /// <param name="directory">The root directory to write the files to.</param>
        /// <param name="removeFromAreaNameStart">The value for this xBDD config setting.</param>
        /// <returns>Nothing, the files are written to disk.</returns>
        public void WriteToCode(TestRun testRun, string rootNamespace, string directory, string removeFromAreaNameStart)
        {
            System.IO.Directory.CreateDirectory(directory);
            this.WriteProjectFiles(testRun, directory, rootNamespace, removeFromAreaNameStart);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbFeatureSort = new StringBuilder();
            this.WriteFeatureSortStart(sbFeatureSort, rootNamespace);
            Scenario lastScenario = null;
            var sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Area.Name).ThenBy(x => x.Feature.Name).ThenBy(x => x.Name);
            if(testRun.Sorted)
                sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Sort).ThenBy(x => x.Sort);
            foreach(var scenario in sortedScenarios)
            {
                this.WriteScenario(rootNamespace, directory, lastScenario, scenario, sb, sbFeatureSort);
                lastScenario = scenario;
            }
            if(sortedScenarios.Count() > 0) {
                this.WriteFeatureFile(directory, rootNamespace, lastScenario.Feature.FullClassName, sb);
                this.WriteFeatureSortEnd(directory, rootNamespace, sbFeatureSort);
            }
        }

        /// <summary>
        /// Writes out feature files.
        /// </summary>
        /// <param name="testRun">The test run to use to build feature classes and scenario methods.</param>
        /// <param name="rootNamespace">The root namspace to use.</param>
        /// <param name="directory">The root directory to write the files to.</param>
        /// <returns>Nothing, the files are written to disk.</returns>
        public void WriteFeaturesToCode(TestRun testRun, string rootNamespace, string directory)
        {
            System.IO.Directory.CreateDirectory(directory);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbFeatureSort = new StringBuilder();
            this.WriteFeatureSortStart(sbFeatureSort, rootNamespace);
            Scenario lastScenario = null;
            var sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Area.Name).ThenBy(x => x.Feature.Name).ThenBy(x => x.Name);
            if(testRun.Sorted)
                sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Sort).ThenBy(x => x.Sort);
            foreach(var scenario in sortedScenarios)
            {
                this.WriteScenario(rootNamespace, directory, lastScenario, scenario, sb, sbFeatureSort);
                lastScenario = scenario;
            }
            if(sortedScenarios.Count() > 0) {
                this.WriteFeatureFile(directory, rootNamespace, lastScenario.Feature.FullClassName, sb);
                this.WriteFeatureSortEnd(directory, rootNamespace, sbFeatureSort);
            }
        }
        private void WriteSampleFeature(string directory, string rootNamespace)
        {
            System.IO.Directory.CreateDirectory("Features/MyArea");
            var content = $@"namespace {rootNamespace}.MyArea
{{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA(""sample user"")]
    [YouCan(""have my feature value"")]
    [By(""execute my feature"")]
    public class MyFeature: FeatureTestClass
    {{

        [TestMethod]
        public async Task MyScenario()
        {{
			var input = $""Here{{System.Environment.NewLine}} is{{System.Environment.NewLine}} my{{System.Environment.NewLine}} Input!"";
			var format = TextFormat.text;
            await xB.CurrentRun.AddScenario(this, 1)
                .Given(""my step 1"", (s) => {{ 
                    //Add code to perform action.
                 }})
                .When(""my step 2 with multiline input"", (s) => {{ 
                    //Add code to perform action.
                 }}, input, format)
                .Then(""my step 3 with output"", (s) => {{ 
                    //Add code to perform action.
                    s.Output = input;
                    s.OutputFormat = format;
                 }})
                .Run();
        }}
    }}
}}";

            System.IO.File.WriteAllText($"{directory}/Features/MyArea/MyFeature.cs",content);
        }
        private void WriteFeatureFile(string directory, string rootNamespace, string featureFullClassName, StringBuilder sb)
        {
            sb.AppendLine($@"    }}
}}
");
            var featureFolder = $"{directory}Features/{featureFullClassName.Replace(rootNamespace,"").Substring(0, featureFullClassName.Replace(rootNamespace,"").LastIndexOf(".")).Replace(".","/")}/";
            var featureClassName = featureFullClassName.Substring(featureFullClassName.LastIndexOf(".")+1, featureFullClassName.Length - (featureFullClassName.LastIndexOf(".")+1));
            System.IO.Directory.CreateDirectory(featureFolder);
            System.IO.File.WriteAllText($"{featureFolder}/{featureClassName}.cs", sb.ToString());
        }
        private void WriteFeatureSortStart(StringBuilder sb, string rootNamespace)
        {
            sb.AppendLine($@"namespace {rootNamespace}
{{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {{
        public string[] SortedFeatureNames {{ get; private set; }}

        public FeatureSort()
        {{
            List<string> SortedFeatureNames = new List<string>() {{");
        }
        private void WriteFeatureSortEnd(string directory, string rootNamespace, StringBuilder sb)
        {
            sb.AppendLine($@"            }};

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }}
    }}
}}");
            var filePath = $"{directory}/FeatureSort.cs";
            System.IO.File.WriteAllText(filePath, sb.ToString());
        }

        /// <summary>
        /// Writes all project files.
        /// </summary>
        /// <param name="directory">The directory to write the files in.</param>
        /// <param name="rootNamespace">The root namspace to use.</param>
        /// <param name="removeFromAreaNameStart">The value for this config setting.</param>
        /// <param name="testRun">The test run to create the features for.</param>
        /// <returns>Nothing. Files are written to disck.</returns>
        public void WriteProjectFiles(TestRun testRun, string directory, string rootNamespace, string removeFromAreaNameStart)
        {
            this.WriteProjectFile(directory, rootNamespace);
            this.WriteConfigJson(testRun.Name, directory, removeFromAreaNameStart);
            this.WriteTestSetupAndBreakdown(directory, rootNamespace);
            this.WriteTestConfiguration(directory, rootNamespace);
            this.WriteReasonSort(directory, rootNamespace);
            this.WriteFeatureTestClass(directory, rootNamespace);
        }
        /// <summary>
        /// Writes out files to create a MSTest project that uses 
        /// best practices for xBDD.
        /// </summary>
        /// <param name="directory">The directory to write the files in.</param>
        /// <param name="rootNamespace">The root namspace to use.</param>
        /// <param name="removeFromAreaNameStart">The value for this config setting.</param>
        public void WriteProjectFiles(string directory, string rootNamespace, string removeFromAreaNameStart)
        {
            this.WriteProjectFile(directory, rootNamespace);
            this.WriteConfigJson(rootNamespace, directory, removeFromAreaNameStart);
            this.WriteTestSetupAndBreakdown(directory, rootNamespace);
            this.WriteTestConfiguration(directory, rootNamespace);
            this.WriteFeatureTestClass(directory, rootNamespace);
            this.WriteFeatureSort(directory, rootNamespace);
            this.WriteReasonSort(directory, rootNamespace);
            this.WriteSampleFeature(directory, rootNamespace);
        }

        private void WriteFeatureSort(string directory, string rootNamespace)
        {
            var content = $@"namespace {rootNamespace}
{{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {{
        public string[] SortedFeatureNames {{ get; private set; }}

        public FeatureSort()
        {{
            List<string> SortedFeatureNames = new List<string>() {{
                typeof({rootNamespace}.MyArea.MyFeature).FullName,
            }};

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }}
    }}
}}";
            System.IO.File.WriteAllText($"{directory}/FeatureSort.cs",content);
        }

        private void WriteReasonSort(string directory, string rootNamespace)
        {
            var content = $@"namespace {rootNamespace}
{{
    using System;
    using System.Collections.Generic;
    public class ReasonSort
    {{
        public List<string> SortedReasons {{ get; private set; }}

        public ReasonSort()
        {{
            this.SortedReasons = new List<string>() {{
                ""Untested"",
                ""Building"",
                ""Ready"",
                ""Defining""
            }};
        }}
    }}
}}";
            System.IO.File.WriteAllText($"{directory}/ReasonSort.cs",content);
        }

        /// <summary>
        /// Writes a project file to the specified directory.
        /// </summary>
        /// <param name="directory">The directory to write the project file to.</param>
        /// <param name="rootNamespace">The root namespace to use.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public void WriteFeatureTestClass(string directory, string rootNamespace)
        {
            var content = $@"namespace {rootNamespace}
{{
    using xBDD;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;


    public class FeatureTestClass: IFeature, IOutputWriter
    {{
        public IOutputWriter OutputWriter {{ get {{ return this; }} }}

        public void WriteLine(string text) {{
            text = text.Replace(""{{"", ""{{{{"").Replace(""}}"",""}}}}"");
            Logger.LogMessage(text);
        }}
    }}
}}
";
            System.IO.File.WriteAllText($"{directory}/FeatureTestClass.cs",content);
        }

        /// <summary>
        /// Writes a project file to the specified directory.
        /// </summary>
        /// <param name="directory">The directory to write the project file to.</param>
        /// <param name="rootNamespace">The root namespace to use.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public void WriteProjectFile(string directory, string rootNamespace)
        {
            var content = $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.1</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.Extensions.Configuration"" Version=""2.1.1"" />
    <PackageReference Include=""Microsoft.Extensions.Configuration.EnvironmentVariables"" Version=""2.1.1"" />
    <PackageReference Include=""Microsoft.Net.Test.Sdk"" Version=""15.8.0"" />
    <PackageReference Include=""MSTEst.TestAdapter"" Version=""1.3.2"" />
    <PackageReference Include=""MSTEst.TestFramework"" Version=""1.3.2"" />
    <PackageReference Include=""Selenium.WebDriver.ChromeDriver"" Version=""2.41.0"" />
    <PackageReference Include=""Selenium.WebDriver"" Version=""3.14.0"" />
    <PackageReference Include=""xBDD"" Version=""0.0.6-alpha"" />
  </ItemGroup>

  <ItemGroup>
    <None Update=""config.json"" CopyToOutputDirectory=""PreserveNewest"" />
  </ItemGroup>

</Project>
";
            System.IO.File.WriteAllText($"{directory}/{rootNamespace}.csproj",content);
        }

        /// <summary>
        /// Writes a config.json file.
        /// </summary>
        /// <param name="directory">Direcotry to write the file in.</param>
        /// <param name="testRunName">Value for the TestRunName setting.</param>
        /// <param name="removeFromAreaNameStart">The string to remove from the beginning of the area name.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public void WriteConfigJson(string testRunName, string directory, string removeFromAreaNameStart)
        {
            var content = $@"{{
    ""xBDD"": {{
        ""TestRunName"": ""{testRunName}"",
        ""Browser"": {{
            ""Watch"": ""false""
        }},
        ""HtmlReport"": {{
            ""RemoveFromAreaNameStart"": ""{removeFromAreaNameStart}"",
            ""FailuresOnly"": ""false""
        }}
    }}
}}            
";
            System.IO.File.WriteAllText($"{directory}/config.json",content);
        }

        /// <summary>
        /// Writes a test setup and breakdown class to run 
        /// code before and after the test run.
        /// </summary>
        /// <param name="directory">The directory to write the file.</param>
        /// <param name="namespaceRoot">The root namespace to use.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public void WriteTestSetupAndBreakdown(string directory, string namespaceRoot)
        {
            var content = $@"namespace {namespaceRoot}
{{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using xBDD;
    using xBDD.Browser;

    [TestClass]
    public class TestSetupAndBreakdown
    {{

        [AssemblyInitialize]
        public static void TestRunStart(TestContext context)
        {{
            xBDD.Browser.WebBrowser.WatchBrowser = TestConfiguration.WatchBrowswer;
        }}
        [AssemblyCleanup()]
        public static void TestRunComplete()
        {{
            WebDriver.Close();

            var directory = System.IO.Directory.GetCurrentDirectory();

            xB.CurrentRun.TestRun.Name = TestConfiguration.TestRunName;

            System.IO.Directory.CreateDirectory($""{{directory}}/../../../test-results"");

            xB.CurrentRun.SortTestRunResults(new FeatureSort().SortedFeatureNames);
            xB.CurrentRun.UpdateParentReasonsAndStats(new ReasonSort().SortedReasons);

            var htmlPath = directory + $""/../../../test-results/{namespaceRoot}.Results.html"";
            Logger.LogMessage(""Writing Html Report to "" + htmlPath);
            var htmlReport = xB.CurrentRun.TestRun.WriteToHtml(TestConfiguration.RemoveFromAreaNameStart, TestConfiguration.FailuresOnly);
            File.WriteAllText(htmlPath, htmlReport);

            var textPath = directory + $""/../../../test-results/{namespaceRoot}.Results.txt"";
            Logger.LogMessage(""Writing Text Report to "" + textPath);
            var textReport = xB.CurrentRun.TestRun.WriteToText();
            File.WriteAllText(textPath, textReport);

            var jsonPath = directory + $""/../../../test-results/{namespaceRoot}.Results.json"";
            Logger.LogMessage(""Writing Json Report to "" + jsonPath);
            var jsonReport = xB.CurrentRun.TestRun.WriteToJson();
            File.WriteAllText(jsonPath, jsonReport);

            var opmlPath = $""{{directory}}/../../../test-results/{namespaceRoot}.Results.opml"";
            Logger.LogMessage(""Writing OPML Report to "" + opmlPath);
            var opmlReport = xB.CurrentRun.TestRun.WriteToOpml(TestConfiguration.RemoveFromAreaNameStart);
            File.WriteAllText(opmlPath, opmlReport);

        }}
    }}
}}
";   
            System.IO.File.WriteAllText($"{directory}/TestSetupAndBreakdown.cs",content);
        }

        /// <summary>
        /// Writes a test configuration file that is used to access
        /// xBDD configuration information in the config.json.
        /// </summary>
        /// <param name="directory">The directory to write the file in.</param>
        /// <param name="rootNamespace">The root namespace to use for the class.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public void WriteTestConfiguration(string directory, string rootNamespace)
        {
            var testConfiguration = $@"namespace {rootNamespace}
{{
    using Microsoft.Extensions.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
    using xBDD;
    using System.IO;
    using System.Threading.Tasks;

    public static class TestConfiguration
    {{
        private static IConfigurationRoot configHolder;
        private static IConfigurationRoot config 
        {{
            get 
            {{
                if(configHolder == null)
                {{
                    ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                    configurationBuilder
                        .AddJsonFile(""Config.json"",true)
                        .AddEnvironmentVariables(); // Bool indicates file is optional

                    configHolder = configurationBuilder.Build();
                }}
                return configHolder;
            }}
        }}
        public static bool FailuresOnly 
        {{
            get 
            {{
                var value = false;
                bool.TryParse(config[""xBDD:HtmlReport:FailuresOnly""], out value);
                return value;
            }}
        }}
        public static string TestRunName
        {{
            get 
            {{
                return config[""xBDD:TestRunName""];
            }}
        }}
        public static bool WatchBrowswer
        {{
            get 
            {{
                var value = false;
                bool.TryParse(config[""xBDD:Browser:Watch""], out value);
                return value;
            }}
        }}
        public static string RemoveFromAreaNameStart
        {{
            get 
            {{
                return config[""xBDD:HtmlReport:RemoveFromAreaNameStart""];
            }}
        }}
    }}
}}
";
            System.IO.File.WriteAllText($"{directory}/TestConfiguration.cs",testConfiguration);
        }

        private void WriteScenario(string rootNamespace, string directory, Scenario lastScenario, Scenario scenario, StringBuilder sb, StringBuilder sbFeatureSort)
        {
            if (lastScenario == null || (lastScenario != null && lastScenario.Feature.FullClassName != scenario.Feature.FullClassName))
            {
                if(lastScenario != null) {
                    var lastFeatureFullClassName = lastScenario.Feature.FullClassName;
                    this.WriteFeatureFile(directory, rootNamespace, lastFeatureFullClassName, sb);
                    sb.Clear();
                }
                var feature = scenario.Feature;
                var featureFullClassName = scenario.Feature.FullClassName;
                var featureNamespace = featureFullClassName.Substring(0, featureFullClassName.LastIndexOf("."));
                var featureClassName = featureFullClassName.Substring(featureFullClassName.LastIndexOf(".")+1, featureFullClassName.Length - (featureFullClassName.LastIndexOf(".")+1));
                sbFeatureSort.AppendLine($@"                typeof({featureNamespace}.{featureClassName}).FullName,");
                sb.AppendLine($@"
namespace {featureNamespace}
{{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA(""{feature.Actor}"")]
    [YouCan(""{feature.Value}"")]
    [By(""{feature.Capability}"")]
    public class {featureClassName}: FeatureTestClass
    {{");
            }
            sb.AppendLine($@"
        [TestMethod]
        public async Task {scenario.MethodName}()
        {{
            await xB.CurrentRun.AddScenario(this, {scenario.Sort})");
            foreach(var step in scenario.Steps)
            {
                WriteStep(step, sb);
            }
            var skip = $".Skip(\"{scenario.Reason}\", Assert.Inconclusive);";
            var run = ".Run();";
            string action = null;
            switch (scenario.Outcome)
            {
                case Outcome.NotRun:
                    action = ".Skip(\"Not Run\", Assert.Inconclusive);";
                break;
                case Outcome.Skipped:
                    action = $".Skip(\"{scenario.Reason}\", Assert.Inconclusive);";
                break;
                default:
                    action = ".Run();";
                break;
            }
            sb.AppendLine($@"                {action}
        }}");
        }

        private void WriteStep(Step step, StringBuilder sb)
        {
            var exception = "throw new Exception();";
            sb.AppendLine($@"                .{Enum.GetName(typeof(ActionType),step.ActionType)}(""{step.Name.Replace(System.Environment.NewLine,"")}"", (s) => {{ {(step.Outcome == Outcome.Failed ? exception : "" )} }})");
        }
    }
}
