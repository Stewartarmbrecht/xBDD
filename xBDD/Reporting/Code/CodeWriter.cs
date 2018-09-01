namespace xBDD.Reporting.Code
{
	using System;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using xBDD.Model;
	using xBDD.Utility;

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
			this.WriteCode(testRun, rootNamespace, directory, removeFromAreaNameStart, true);
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
			this.WriteCode(testRun, rootNamespace, directory, null, false);
		}

		/// <summary>
		/// Writes out files to create a MSTest project that uses 
		/// best practices for xBDD.
		/// </summary>
		/// <param name="directory">The directory to write the files in.</param>
		/// <param name="rootNamespace">The root namspace to use.</param>
		/// <param name="removeFromAreaNameStart">The value for this config setting.</param>
		public void WriteProjectFiles(
			string directory, 
			string rootNamespace, 
			string removeFromAreaNameStart) 
		{
			var featureImportPath = $"{directory}/xBDDFeatureImport.txt";
			if(System.IO.File.Exists(featureImportPath)) {
				var textImporter = new Importing.Text.TextImporter();
				var text = System.IO.File.ReadAllText(featureImportPath);
				var indentation = "\t";
				if(text.StartsWith("- ")) { //Workflowy export.
					var lines = text.Split(new[] { System.Environment.NewLine }, StringSplitOptions.None);
					StringBuilder formattedText = new StringBuilder();
					for(int i =0; i < lines.Length; i++) {
						var line = lines[i];
						var dashIndex = line.IndexOf('-');
						var lineStart = dashIndex +2;
						var lineCount = line.Length;
						var lineIndentation = line.Substring(0, dashIndex);
						var lineContent = line.Substring(lineStart, lineCount - lineStart);
						var newLineIndentation = lineIndentation.Replace("  ", "\t");
						formattedText.Append(newLineIndentation);
						formattedText.AppendLine(lineContent);
					}
					text = formattedText.ToString();
				}
				TestRun testRun = textImporter.ImportText(text, indentation, rootNamespace);
				this.WriteToCode(testRun,rootNamespace, directory,removeFromAreaNameStart);

			} else {
				var writeSample = true;
				if(System.IO.Directory.Exists($"{directory}/Features")) {
					writeSample = false;
				}
				this.WriteProjectFiles(directory, rootNamespace, removeFromAreaNameStart, writeSample, null, null);
			}
		}
		private void WriteProjectFiles(
			string directory, 
			string rootNamespace, 
			string removeFromAreaNameStart, 
			bool writeSample, 
			List<string> sortedFeatureNames, 
			List<string> sortedReasons)
		{
			this.WriteProjectFile(directory, rootNamespace);
			this.WriteXbddFeatureImportTxt(directory,rootNamespace);
			this.WriteXbddConfigJson(rootNamespace.ConvertNamespaceToAreaName(), directory, removeFromAreaNameStart);
			this.WriteXbddInitializeAndCompleteClass(directory, rootNamespace);
			this.WriteXbddFeatureBaseClass(directory, rootNamespace);
			if(sortedFeatureNames == null) {
				sortedFeatureNames = new List<string>() {
					$"{rootNamespace}.MyArea.MyFeature"
				};
			}
			if(sortedReasons == null) {
				sortedReasons = new List<string>() {
					"Removing",
					"Untested",
					"Committed",
					"Ready",
					"Defining"
				};
			}
			this.WriteXbddSortingClass(directory, rootNamespace, sortedFeatureNames, sortedReasons);
			if(writeSample) {
				this.WriteSampleFeature(directory, rootNamespace);
			}
		}

		private void WriteCode(TestRun testRun, string rootNamespace, string directory, string removeFromAreaNameStart, bool writeProjectFiles)
		{
			System.IO.Directory.CreateDirectory(directory);
			StringBuilder sb = new StringBuilder();
			Scenario lastScenario = null;
			List<string> sortedFeatureNames = new List<string>();
			List<string> reasons = new List<string>();
			var sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Area.Name).ThenBy(x => x.Feature.Name).ThenBy(x => x.Name);
			if(testRun.Sorted)
				sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Sort).ThenBy(x => x.Sort);
			foreach(var scenario in sortedScenarios)
			{
				var featureNameAndReason = this.WriteScenario(rootNamespace, directory, lastScenario, scenario, sb);
				if(!sortedFeatureNames.Contains(featureNameAndReason.featureName)) {
					sortedFeatureNames.Add(featureNameAndReason.featureName);
				}
				if(!reasons.Contains(featureNameAndReason.reason)) {
					reasons.Add(featureNameAndReason.reason);
				}
				lastScenario = scenario;
			}
			if(sortedScenarios.Count() > 0) {
				this.WriteFeatureClass(directory, rootNamespace, lastScenario.Feature.FullClassName, sb);
			}
			if(writeProjectFiles) {
				this.WriteProjectFiles(directory, rootNamespace, removeFromAreaNameStart, false, sortedFeatureNames, reasons);
			}
		}


		private void WriteProjectFile(string directory, string rootNamespace)
		{
			var content = this.GetProjectFile();
			if(!System.IO.File.Exists($"{directory}/{rootNamespace}.csproj")) {
				System.IO.File.WriteAllText($"{directory}/{rootNamespace}.csproj",content);
			}
			System.IO.File.WriteAllText($"{directory}/{rootNamespace}.csproj.xbdd",content);
		}

		private void WriteXbddFeatureImportTxt(string directory, string rootNamespace)
		{
			var content = this.GetXbddFeatureImportFile();
			if(!System.IO.File.Exists($"{directory}/xBDDFeatureImport.txt")) {
				System.IO.File.WriteAllText($"{directory}/xBDDFeatureImport.txt",content);
			}
		}

		private void WriteXbddConfigJson(string testRunName, string directory, string removeFromAreaNameStart)
		{
			if(!System.IO.File.Exists($"{directory}/xBDDConfig.json")) {
				var content = this.GetXbddConfigJson(testRunName, removeFromAreaNameStart);
				System.IO.File.WriteAllText($"{directory}/xBDDConfig.json",content);
			}
		}

		private void WriteXbddInitializeAndCompleteClass(string directory, string namespaceRoot)
		{
			if(!System.IO.File.Exists($"{directory}/xBDDInitializeAndComplete.cs")) {
				var content = this.GetXbddInitializeAndComplete(namespaceRoot);
				System.IO.File.WriteAllText($"{directory}/xBDDInitializeAndComplete.cs",content);
			}
		}

		private void WriteXbddFeatureBaseClass(string directory, string rootNamespace)
		{
			var content = this.GetXbddFeatureBaseClass(rootNamespace);
			System.IO.File.WriteAllText($"{directory}/xBDDFeatureBase.xbdd.cs",content);
		}

		private void WriteSampleFeature(string directory, string rootNamespace)
		{
			System.IO.Directory.CreateDirectory("Features/MyArea");
			var content = GetSampleFeature(rootNamespace);
			System.IO.File.WriteAllText($"{directory}/Features/MyArea/MyFeature.cs",content);
		}
		private void WriteFeatureCustomClass(string directory, string rootNamespace, Feature feature)
		{
			var featureFullClassName = feature.FullClassName;
			var featureNamespace = featureFullClassName.Substring(0, featureFullClassName.LastIndexOf("."));
			var featureClassName = featureFullClassName.Substring(featureFullClassName.LastIndexOf(".")+1, featureFullClassName.Length - (featureFullClassName.LastIndexOf(".")+1));
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(this.GetFeatureClassStart(feature, false));
			sb.AppendLine(this.GetFeatureClassEnd());
			var featureFolder = $"{directory}/Features/{featureFullClassName.Replace(rootNamespace,"").Substring(0, featureFullClassName.Replace(rootNamespace,"").LastIndexOf(".")).Replace(".","/")}/";
			System.IO.Directory.CreateDirectory(featureFolder);
			System.IO.File.WriteAllText($"{featureFolder}/{featureClassName}.cs", sb.ToString());
		}
		private void WriteFeatureClass(string directory, string rootNamespace, string featureFullClassName, StringBuilder sb)
		{
			sb.AppendLine(this.GetFeatureClassEnd());
			var featureFolder = $"{directory}/Features/{featureFullClassName.Replace(rootNamespace,"").Substring(0, featureFullClassName.Replace(rootNamespace,"").LastIndexOf(".")).Replace(".","/")}/";
			var featureClassName = featureFullClassName.Substring(featureFullClassName.LastIndexOf(".")+1, featureFullClassName.Length - (featureFullClassName.LastIndexOf(".")+1));
			System.IO.Directory.CreateDirectory(featureFolder);
			System.IO.File.WriteAllText($"{featureFolder}/{featureClassName}.xbdd.cs", sb.ToString());
		}
		private void WriteXbddSortingClass(string directory, string rootNamespace, List<string> features, List<string> reasons)
		{
			var filePath = $"{directory}/xBDDSorting.cs";
			var generatedFilePath = $"{directory}/xBDDSorting.xbdd.cs";
			if(!System.IO.File.Exists(filePath)) {
				System.IO.File.WriteAllText(filePath, this.GetXbddSortingFile(rootNamespace, features, reasons));
			}
			System.IO.File.WriteAllText(generatedFilePath, this.GetXbddSortingGeneratedFile(rootNamespace, features, reasons));
		}
		private (string featureName, string reason) WriteScenario(
			string rootNamespace, 
			string directory, 
			Scenario lastScenario, 
			Scenario scenario, 
			StringBuilder sb)
		{
			if (lastScenario == null || (lastScenario != null && lastScenario.Feature.FullClassName != scenario.Feature.FullClassName))
			{
				if(lastScenario != null) {
					var lastFeatureFullClassName = lastScenario.Feature.FullClassName;
					this.WriteFeatureCustomClass(directory, rootNamespace, lastScenario.Feature);
					this.WriteFeatureClass(directory, rootNamespace, lastFeatureFullClassName, sb);
					sb.Clear();
				}
				var feature = scenario.Feature;
				sb.AppendLine(this.GetFeatureClassStart(feature, true));
			}

			sb.AppendLine(this.GetScenarioMethodStart(scenario));
			foreach(var step in scenario.Steps)
			{
				WriteStep(step, sb);
			}
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
			sb.AppendLine(this.GetScenarioMethodEnd(action));
			return (scenario.Feature.FullClassName, scenario.Reason);
		}

		private void WriteStep(Step step, StringBuilder sb)
		{
			var exception = "throw new Exception();";
			if(step.ActionType == ActionType.Code) {
				sb.AppendLine($"//				{step.Name}");
				if(!String.IsNullOrEmpty(step.Input)) {
					if(step.Input.Contains(System.Environment.NewLine)) {
						sb.AppendLine($"//					Input");
						sb.AppendLine($"{step.Input.PrependLines("//						")}");
					} else {
						sb.AppendLine($"//					Input: {step.Input}");
					}
				}
				if(!String.IsNullOrEmpty(step.Explanation)) {
					if(step.Explanation.Contains(System.Environment.NewLine)) {
						sb.AppendLine($"//					Explanation");
						sb.AppendLine($"{step.Explanation.PrependLines("//						")}");
					} else {
						sb.AppendLine($"//					Explanation: {step.Explanation}");
					}
				}
			} else {
				var inputAndExplanation = "";
				if(!String.IsNullOrEmpty(step.Input)) {
					if(step.Input.Contains(System.Environment.NewLine)) {
						inputAndExplanation = $@",
												@""
													{step.Input.AddIndentation(13)}"".RemoveIndentation(6,true), 
												TextFormat.{Enum.GetName(typeof(TextFormat), step.InputFormat)}".RemoveIndentation(7);
					} else {
						inputAndExplanation = $@",
												@""{step.Input}"", 
												TextFormat.{Enum.GetName(typeof(TextFormat), step.InputFormat)}".RemoveIndentation(7);
					}
				}
				if(!String.IsNullOrEmpty(step.Explanation)) {
					if(inputAndExplanation.Length == 0) {
						inputAndExplanation = $@", 
												null, 
												null".RemoveIndentation(7);
					}
					if(step.Explanation.Contains(System.Environment.NewLine)) {
						inputAndExplanation = $@"{inputAndExplanation.AddIndentation(7)},
												@""
													{step.Explanation.AddIndentation(13)}"".RemoveIndentation(6,true)".RemoveIndentation(7);
					} else {
						inputAndExplanation = $@"{inputAndExplanation.AddIndentation(7)},
												@""{step.Explanation}""".RemoveIndentation(7);
					}
				}
				sb.AppendLine($@"				
									.{Enum.GetName(typeof(ActionType),step.ActionType)}(""{step.Name.Replace(System.Environment.NewLine,"")}"", 
										(s) => {{ 
											{(step.Outcome == Outcome.Failed ? exception : "// Enter your code here." )} 
										}}{inputAndExplanation.AddIndentation(5)})".RemoveIndentation(5, true));
			}
		}

		private string GetProjectFile() {
			return $@"
				<Project Sdk=""Microsoft.NET.Sdk"">

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
						<PackageReference Include=""xBDD"" Version=""0.0.7-alpha"" />
					</ItemGroup>

					<ItemGroup>
						<None Update=""xBDDConfig.json"" CopyToOutputDirectory=""PreserveNewest"" />
					</ItemGroup>

				</Project>".RemoveIndentation(4, true);
		}

		private string GetXbddFeatureImportFile() {
			return $@"
				MyImportedArea1
					MyImportedFeature
						MyImportedScenario #R-Ready
							Given you have the xbdd tools installed
							And you have an xBDDFeatureImport.txt file defined in the root of the project
							When you execute 'dotnet xbdd project generate MSTest'
							Then a new feature will be defined in the project with two partial class files
							And you can finish the import by moving the scenarios from the feature.xbdd.cs file to the feature.cs file
							And you can delete the .xbdd.cs file and clear out the xBDDFeatureImport.txt file of the feature".RemoveIndentation(4, true);
		}

		private string GetXbddConfigJson(string testRunName, string removeFromAreaNameStart) {
			return $@"
				{{
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
				}}".RemoveIndentation(4, true);			
		}

		private string GetXbddInitializeAndComplete(string namespaceRoot) {
			return $@"
				namespace {namespaceRoot}
				{{
					using Microsoft.VisualStudio.TestTools.UnitTesting;
					using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
					using xBDD;

					[TestClass]
					public class TestSetupAndBreakdown
					{{

						[AssemblyInitialize]
						public static void TestRunStart(TestContext context)
						{{
							xB.Initialize();
						}}
						[AssemblyCleanup()]
						public static void TestRunComplete()
						{{
							xB.Complete(""{namespaceRoot}"", new xBDDSorting(), (message) => {{ Logger.LogMessage(message); }});
						}}
					}}
				}}".RemoveIndentation(4, true);   			
		}

		private string GetXbddFeatureBaseClass(string rootNamespace) {
			return $@"
				namespace {rootNamespace}
				{{
					using xBDD;
					using Microsoft.VisualStudio.TestTools.UnitTesting;
					using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;


					public partial class xBDDFeatureBase: IFeature, IOutputWriter
					{{
						public IOutputWriter OutputWriter {{ get {{ return this; }} }}

						public void WriteLine(string text) {{
							text = text.Replace(""{{"", ""{{{{"").Replace(""}}"",""}}}}"");
							Logger.LogMessage(text);
						}}
					}}
				}}".RemoveIndentation(4, true);			
		}

		private string GetSampleFeature(string rootNamespace) {
			return $@"
				namespace {rootNamespace}.MyArea
				{{
					using Microsoft.VisualStudio.TestTools.UnitTesting;
					using System;
					using System.Threading.Tasks;
					using xBDD;
					using xBDD.Utility;

					[TestClass]
					[AsA(""sample user"")]
					[YouCan(""have my feature value"")]
					[By(""execute my feature"")]
					[Explanation(@""
						# My Explanation
						This is a
						multiline explanation of the feature.
						**And it uses markdown!**"")]
					public partial class MyFeature: xBDDFeatureBase
					{{

						[TestMethod]
						[Explanation(""This is an explanation of the scenario."")]
						public async Task MyScenario()
						{{
							await xB.CurrentRun.AddScenario(this, 1)
								.Given(""my step 1"", (s) => {{ 

									//Add code to perform action.

								}})
								.When(""my step 2 with multiline input"", (s) => {{ 

									//Add code to perform action.

									}}, @""
										Here 
										is 
										my 
										Input!"".RemoveIndentation(6, true), TextFormat.text
								)
								.And(""my step 3 with an explanation"", (s) => {{ 

									//Add code to perform action.

									}}, null, TextFormat.text, @""
										# Step 3 Explanation 
										This is a multiline explanation of 
										Step 3.  It uses markdown.  It will
										be printed out along with the step name in the
										html report.""
								)
								.Then(""my step 3 with output"", (s) => {{ 

									//Add code to perform action.

									s.Output = ""Here is my output."";
									s.OutputFormat = TextFormat.text;

								}})
								.Run();
						}}
					}}
				}}".RemoveIndentation(4, true);			
		}

		private string GetXbddSortingFile(string rootNamespace, List<string> features, List<string> reasons) {
			var featuresString = new StringBuilder();
			features.ForEach(x => {
				if(features.Last() == x ) {
					featuresString.Append($"typeof({x}).FullName,");
				} else {
					featuresString.AppendLine($"typeof({x}).FullName,");
				}
			});
			var reasonsString = new StringBuilder();
			reasons.ForEach(x => {
				if(reasons.Last() == x) {
					reasonsString.Append($"\"{x}\",");
				} else {
					reasonsString.AppendLine($"\"{x}\",");
				}
			});
			return $@"
				namespace {rootNamespace}
				{{
					using System;
					using System.Collections.Generic;
					using xBDD;

					public partial class xBDDSorting: ISorting
					{{
						public List<string> GetSortedFeatureNames() {{
							return new List<string>() {{
								{featuresString.ToString().AddIndentation(8)}
							}};
						}}
						public List<string> GetSortedReasons() {{
							return new List<string>() {{
								{reasonsString.ToString().AddIndentation(8)}
							}};
						}}
					}}
				}}".RemoveIndentation(4, true);
		}

		private string GetXbddSortingGeneratedFile(string rootNamespace, List<string> features, List<string> reasons) {
			var featuresString = new StringBuilder();
			features.ForEach(x => {
				featuresString.AppendLine($"typeof({x}).FullName,");
			});
			var reasonsString = new StringBuilder();
			reasons.ForEach(x => {
				reasonsString.AppendLine($"\"{x}\",");
			});
			return $@"
				namespace {rootNamespace}
				{{
					using System;
					using System.Collections.Generic;
					using xBDD;

					public partial class xBDDSorting: ISorting
					{{
						public List<string> GetGeneratedSortedFeatureNames() {{
							return new List<string>() {{
								{featuresString.ToString().AddIndentation(8)}
							}};
						}}
						public List<string> GetGeneratedReasons() {{
							return new List<string>() {{
								{reasonsString.ToString().AddIndentation(8)}
							}};
						}}
					}}
				}}".RemoveIndentation(4, true);
		}

		private string GetFeatureClassStart(Feature feature, bool generated) {
			var featureFullClassName =feature.FullClassName;
			var featureNamespace = featureFullClassName.Substring(0, featureFullClassName.LastIndexOf("."));
			var featureClassName = featureFullClassName.Substring(featureFullClassName.LastIndexOf(".")+1, featureFullClassName.Length - (featureFullClassName.LastIndexOf(".")+1));
			var explanation = "";
			if(!String.IsNullOrEmpty(feature.Explanation)) {
				var isMultiline = feature.Explanation.Contains(System.Environment.NewLine);
				if(isMultiline) {
					explanation = $@"
							[{(generated ? "Generated_" : "")}Explanation(@""
								{feature.Explanation.AddIndentation(8)}"",2)]".RemoveIndentation(6);
				} else {
					explanation = $@"
							[{(generated ? "Generated_" : "")}Explanation(@""{feature.Explanation}"")]".RemoveIndentation(6);
				}
			}

			return $@"
				namespace {featureNamespace}
				{{
					using Microsoft.VisualStudio.TestTools.UnitTesting;
					using System;
					using System.Threading.Tasks;
					using xBDD;
					using xBDD.Utility;

					{(generated ? "" : "[TestClass]")}
					[{(generated ? "Generated_" : "")}AsA(""{feature.Actor}"")]
					[{(generated ? "Generated_" : "")}YouCan(""{feature.Value}"")]
					[{(generated ? "Generated_" : "")}By(""{feature.Capability}"")]{explanation.AddIndentation(4)}
					public partial class {featureClassName}: xBDDFeatureBase
					{{".RemoveIndentation(4, true);
		}
		private string GetFeatureClassEnd() {
			return $@"
					}}
				}}".RemoveIndentation(4);
		}

		private string GetScenarioMethodStart(Scenario scenario) {
			var explanation = "";
			if(!String.IsNullOrEmpty(scenario.Explanation)) {
				var isMultiline = scenario.Explanation.Contains(System.Environment.NewLine);
				if(isMultiline) {
					explanation = $@"
								[Explanation(@""
									{scenario.Explanation.AddIndentation(9)}"",3)]".RemoveIndentation(6);
				} else {
					explanation = $@"
								[Explanation(@""{scenario.Explanation}"")]".RemoveIndentation(6);
				}
			}

			var assignments = "";
			if(scenario.Assignments.Length > 0) {
				assignments = $@"
							[Assignments(""{string.Join("\",\"",scenario.Assignments)}"")]".RemoveIndentation(5);
			}
			var tags = "";
			if(scenario.Tags.Length > 0) {
				tags = $@"
							[Tags(""{string.Join("\",\"",scenario.Tags)}"")]".RemoveIndentation(5);
			}
			return $@"
						[TestMethod]{explanation.AddIndentation(4)}{assignments.AddIndentation(4)}{tags.AddIndentation(4)}
						public async Task {scenario.MethodName}()
						{{
							await xB.AddScenario(this, {scenario.Sort})".RemoveIndentation(4);	
		}

		private string GetScenarioMethodEnd(string action) {
			return $@"
								{action}
						}}".RemoveIndentation(4, true);
		}
	}
}
