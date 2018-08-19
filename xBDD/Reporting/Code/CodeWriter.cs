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
        public async Task WriteToCode(TestRun testRun, string rootNamespace, string directory, string removeFromAreaNameStart)
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
                await WriteScenario(rootNamespace, directory, lastScenario, scenario, sb, sbFeatureSort);
                lastScenario = scenario;
            }
            if(sortedScenarios.Count() > 0) {
                await WriteFeatureFile(directory, rootNamespace, lastScenario.Feature.ClassName, sb);
                await WriteFeatureSortFile(directory, rootNamespace, sbFeatureSort);
            }
        }

        private async Task WriteFeatureFile(string directory, string rootNamespace, string featureFullClassName, StringBuilder sb)
        {
            await Task.Run(() => {
                    sb.AppendLine($@"    }}
}}
");
                var featureFolder = $"{directory}{featureFullClassName.Replace(rootNamespace,"").Substring(0, featureFullClassName.Replace(rootNamespace,"").LastIndexOf(".")).Replace(".","/")}/";
                var featureClassName = featureFullClassName.Substring(featureFullClassName.LastIndexOf(".")+1, featureFullClassName.Length - (featureFullClassName.LastIndexOf(".")+1));
                System.IO.Directory.CreateDirectory(featureFolder);
                System.IO.File.WriteAllText($"{featureFolder}/{featureClassName}.cs", sb.ToString());
            });
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
        private async Task WriteFeatureSortFile(string directory, string rootNamespace, StringBuilder sb)
        {
            await Task.Run(() => {
                sb.AppendLine($@"            }};

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }}
    }}
}}");
                var filePath = $"{directory}/FeatureSort.cs";
                System.IO.File.WriteAllText(filePath, sb.ToString());
            });
        }

        /// <summary>
        /// Writes all project files.
        /// </summary>
        /// <param name="directory">The directory to write the files in.</param>
        /// <param name="rootNamespace">The root namspace to use.</param>
        /// <param name="removeFromAreaNameStart">The value for this config setting.</param>
        /// <returns>Nothing. Files are written to disck.</returns>
        public void WriteProjectFiles(TestRun testRun, string directory, string rootNamespace, string removeFromAreaNameStart)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(this.WriteProjectFile(directory, rootNamespace));
            tasks.Add(this.WriteConfigJson(testRun, directory, removeFromAreaNameStart));
            tasks.Add(this.WriteTestContextWriter(directory, rootNamespace));
            tasks.Add(this.WriteTestSetupAndBreakdown(directory, rootNamespace));
            tasks.Add(this.WriteTestConfiguration(directory, rootNamespace));
            tasks.Add(this.WriteFeatureTestClass(directory, rootNamespace));
            Task.WaitAll(tasks.ToArray());
        }

        /// <summary>
        /// Writes a project file to the specified directory.
        /// </summary>
        /// <param name="directory">The directory to write the project file to.</param>
        /// <param name="rootNamespace">The root namespace to use.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public async Task WriteFeatureTestClass(string directory, string rootNamespace)
        {
            await Task.Run(() =>{
                var content = $@"namespace {rootNamespace}
{{
    using xBDD;

    public class FeatureTestClass: IFeature
    {{
        public IOutputWriter OutputWriter {{ get; private set; }}

		public FeatureTestClass()
		{{
			this.OutputWriter = new TestContextWriter();
		}}
    }}
}}
";
                System.IO.File.WriteAllText($"{directory}/FeatureTestClass.cs",content);
            });
        }

        /// <summary>
        /// Writes a project file to the specified directory.
        /// </summary>
        /// <param name="directory">The directory to write the project file to.</param>
        /// <param name="rootNamespace">The root namespace to use.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public async Task WriteProjectFile(string directory, string rootNamespace)
        {
            await Task.Run(() =>{
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
    <PackageReference Include=""xBDD"" Version=""0.0.4-alpha"" />
  </ItemGroup>

  <ItemGroup>
    <None Update=""config.json"" CopyToOutputDirectory=""PreserveNewest"" />
  </ItemGroup>

</Project>
";
                System.IO.File.WriteAllText($"{directory}/{rootNamespace}.csproj",content);
            });
        }

        /// <summary>
        /// Writes a config.json file.
        /// </summary>
        /// <param name="directory">Direcotry to write the file in.</param>
        /// <param name="testRun">The test run to build the configuration for.</param>
        /// <param name="removeFromAreaNameStart">The string to remove from the beginning of the area name.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public async Task WriteConfigJson(TestRun testRun, string directory, string removeFromAreaNameStart)
        {
            await Task.Run(() =>{
                var content = $@"{{
    ""xBDD"": {{
        ""TestRunName"": ""{testRun.Name}"",
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
            });
        }

        /// <summary>
        /// Writes a test setup and breakdown class to run 
        /// code before and after the test run.
        /// </summary>
        /// <param name="directory">The directory to write the file.</param>
        /// <param name="namespaceRoot">The root namespace to use.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public async Task WriteTestSetupAndBreakdown(string directory, string namespaceRoot)
        {
            await Task.Run(() => {
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
        public async static Task TestRunComplete()
        {{
            WebDriver.Close();

            var directory = System.IO.Directory.GetCurrentDirectory();

            xB.CurrentRun.TestRun.Name = TestConfiguration.TestRunName;

            System.IO.Directory.CreateDirectory($""{{directory}}/../../../test-results"");

            xB.CurrentRun.SortTestRunResults(new FeatureSort().SortedFeatureNames);

            var htmlPath = directory + $""/../../../test-results/{namespaceRoot}.Results.html"";
            Logger.LogMessage(""Writing Html Report to "" + htmlPath);
            var htmlReport = await xB.CurrentRun.TestRun.WriteToHtml(TestConfiguration.RemoveFromAreaNameStart, TestConfiguration.FailuresOnly);
            File.WriteAllText(htmlPath, htmlReport);

            var textPath = directory + $""/../../../test-results/{namespaceRoot}.Results.txt"";
            Logger.LogMessage(""Writing Text Report to "" + textPath);
            var textReport = await xB.CurrentRun.TestRun.WriteToText();
            File.WriteAllText(textPath, textReport);

            var jsonPath = directory + $""/../../../test-results/{namespaceRoot}.Results.json"";
            Logger.LogMessage(""Writing Json Report to "" + jsonPath);
            var jsonReport = xB.CurrentRun.TestRun.WriteToJson();
            File.WriteAllText(jsonPath, jsonReport);

            var opmlPath = $""{{directory}}/../../../test-results/{namespaceRoot}.Results.opml"";
            Logger.LogMessage(""Writing OPML Report to "" + opmlPath);
            var opmlReport = await xB.CurrentRun.TestRun.WriteToOpml();
            File.WriteAllText(opmlPath, opmlReport);

        }}
    }}
}}
";   
                System.IO.File.WriteAllText($"{directory}/TestSetupAndBreakdown.cs",content);

            });
        }

        /// <summary>
        /// Writes a test context writer that is used to log test results to the testing 
        /// framework.
        /// </summary>
        /// <param name="directory">The directory to write the file to.</param>
        /// <param name="rootNamespace">The root namespace to use for the class.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public async Task WriteTestContextWriter(string directory, string rootNamespace)
        {
            await Task.Run(() => {
                var testContextWriter = $@"namespace {rootNamespace}
{{
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
    using xBDD;

    public class TestContextWriter : IOutputWriter
    {{
        public void WriteLine(string text)
        {{
            text = text.Replace(""{{"", ""{{{{"").Replace(""}}"",""}}}}"");
            Logger.LogMessage(text);
        }}
    }}
}}";
                System.IO.File.WriteAllText($"{directory}/TestContextWriter.cs",testContextWriter);
            });

        }

        /// <summary>
        /// Writes a test configuration file that is used to access
        /// xBDD configuration information in the config.json.
        /// </summary>
        /// <param name="directory">The directory to write the file in.</param>
        /// <param name="rootNamespace">The root namespace to use for the class.</param>
        /// <returns>Returns the task for writing the file to the direcotry.</returns>
        public async Task WriteTestConfiguration(string directory, string rootNamespace)
        {
            await Task.Run(() => {
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
            });
        }

        private async Task WriteScenario(string rootNamespace, string directory, Scenario lastScenario, Scenario scenario, StringBuilder sb, StringBuilder sbFeatureSort)
        {
            if (lastScenario == null || (lastScenario != null && lastScenario.Feature.Name != scenario.Feature.Name))
            {
                if(lastScenario != null) {
                    var lastFeatureFullClassName = lastScenario.Feature.ClassName;
                    await this.WriteFeatureFile(directory, rootNamespace, lastFeatureFullClassName, sb);
                    sb.Clear();
                }
                var feature = scenario.Feature;
                var featureFullClassName = scenario.Feature.ClassName;
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
            sb.AppendLine($@"                {(scenario.Outcome == Outcome.Skipped ? skip : run)}
        }}");
        }

        private void WriteStep(Step step, StringBuilder sb)
        {
            var exception = "throw new Exception();";
            sb.AppendLine($@"                .{Enum.GetName(typeof(ActionType),step.ActionType)}(""{step.Name.Replace(System.Environment.NewLine,"")}"", (s) => {{ {(step.Outcome == Outcome.Failed ? exception : "" )} }})");
        }
    }
}
