namespace xBDD.Tools
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    internal class CodeWriter
    {
        internal void WriteProjectFiles(string directory, string rootNamespace, string removeFromAreaNameStart)
        {
            this.WriteProjectFile(directory, rootNamespace);
            this.WriteConfigJson(rootNamespace, directory, removeFromAreaNameStart);
            this.WriteTestSetupAndBreakdown(directory, rootNamespace);
            this.WriteTestConfiguration(directory, rootNamespace);
            this.WriteFeatureTestClass(directory, rootNamespace);
            this.WriteFeatureSort(directory, rootNamespace);
            this.WriteSampleFeature(directory, rootNamespace);
        }

        private void WriteSampleFeature(string directory, string rootNamespace)
        {
            System.IO.Directory.CreateDirectory("MyArea");
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

            System.IO.File.WriteAllText($"{directory}/MyArea/MyFeature.cs",content);
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
        private void WriteFeatureTestClass(string directory, string rootNamespace)
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

        private void WriteProjectFile(string directory, string rootNamespace)
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
    <PackageReference Include=""xBDD"" Version=""0.0.4-alpha"" />
  </ItemGroup>

  <ItemGroup>
    <None Update=""config.json"" CopyToOutputDirectory=""PreserveNewest"" />
  </ItemGroup>

</Project>
";
            System.IO.File.WriteAllText($"{directory}/{rootNamespace}.csproj",content);
        }

        private void WriteConfigJson(string rootNamespace, string directory, string removeFromAreaNameStart)
        {
            var content = $@"{{
    ""xBDD"": {{
        ""TestRunName"": ""{rootNamespace}"",
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

        private void WriteTestSetupAndBreakdown(string directory, string namespaceRoot)
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
        }

        private void WriteTestConfiguration(string directory, string rootNamespace)
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
    }
}
