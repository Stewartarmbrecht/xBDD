namespace xBDD.Features.GeneratingCode.GeneratingFeatureFiles.UsingAnXbddFeatureImportFile
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
    using System.Runtime.CompilerServices;
	using xBDD;
	using xBDD.Utility;
	using xBDD.Features.Common;

	[TestClass]
	[AsA("Developer")]
	[SoThat("generate new feature files for an MS Test Project")]
	[YouCan("executing the 'dotnet xbdd project generate MSTest' command in a directory that has an xBDDFeatureImport.txt file")]
	public partial class ForAnMSTestProject: xBDDFeatureBase
	{
		string directory = "./MyGeneratedSample.Features";
		string templateDirectory = "./../../../Interfaces/Files/FeatureFileTemplates";
		string[] xbddToolsCommandArgs = new[] { "project", "generate", "MSTest" };
		Developer you = new Developer();
		private async Task ExecuteStep(int number, string outline, string featureFilePath, bool twice = false, [CallerMemberName]string methodName = null) {
			var outputWrapper = new Wrapper<string>();
			var featureTemplatePath = $"{templateDirectory}/Feature{methodName}.tmpl";
			var scenario = xB.AddScenario(this, number, methodName)
				.Given(you.HaveAnEmptyDirectory("./MyGeneratedSample.Features"))
				.And($"add a scenario outline file with the following content:",
					s => {
						var filePath = "./MyGeneratedSample.Features/xBDDFeatureImport.txt";
						System.IO.File.WriteAllText(filePath, outline);
					}, outline, TextFormat.text)
				.When(you.RunTheXbddToolsCommand(xbddToolsCommandArgs, directory, outputWrapper));
			if(twice) {
				scenario = scenario.And(you.RunTheXbddToolsCommand(xbddToolsCommandArgs, directory, outputWrapper));
			}
			scenario.Then(you.WillFindAMatchingFile(featureFilePath, featureTemplatePath, TextFormat.cs));
			if(twice) {
				scenario.And(you.WillFindAMatchingFile(featureFilePath.Replace(".cs",".xbdd.cs"), featureTemplatePath.Replace(".tmpl",".xbdd.tmpl"), TextFormat.cs));
			}
			
			await scenario.Run();
		}

		[TestMethod]
		public async Task WithAnEmptyScenario()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(100, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAGivenStep()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(200, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAGivenStepWithQuotes()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given ""My"" Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(200, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAWhenStep()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
							When Step 2".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(300, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAThenStep()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
							When Step 2
							Then Step 3".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(400, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAnAndStep()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
							When Step 2
							Then Step 3
							And Step 4".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(500, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithACodeStep()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
							When Step 2
							Then Step 3
							And Step 4
							.And(this.IsSomeCode())".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(600, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAStepInput()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
								Input
									Here Is
									My Multiline Input".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(700, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAStepInputWithQuotes()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
								Input
									Here Is
									""My"" Multiline Input".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(700, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAStepInputSingleLine()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
								Input
									Here Is My Single Line Input".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(800, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAStepInputSingleLineWithQuotes()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
								Input
									Here Is ""My"" Single Line Input".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(800, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAStepExplanation()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
								Explanation
									Here Is
									My Multiline Explanation".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(900, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAStepExplanationWithQuotes()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
								Explanation
									Here Is
									""My"" Multiline Explanation".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(910, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAStepExplanationSingleLine()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
								Explanation
									Here Is My Singleline Explanation".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1000, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAStepExplanationSingleLineWithQuotes()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1
								Explanation
									Here Is ""My"" Singleline Explanation".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1010, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAStepWithTrailingSpaces()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1           ".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1100, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAScenarioExplanation()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Explanation
								Here is my 
								multiline scenario 
								explanation
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1200, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAScenarioExplanationWithQuotes()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Explanation
								Here is ""my"" 
								multiline scenario 
								explanation
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1210, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAScenarioWithTrailingSpaces()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1          
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1300, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithScenarioReasonTags()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1 #R-MyReason
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1400, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithDuplicateScenarioReasonTags()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1 #R-MyReason1 #R-MyReason2
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1410, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithScenarioOwnerTags()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1 @MyOwner1 @MyOwner2
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1500, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithScenarioGeneralTags()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1 #T-MyTag1 #T-MyTag2
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1510, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAnExistingFeature()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1600, outline, featureFilePath, true);
		}

		[TestMethod]
		public async Task WithAFeatureExplanation()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						Explanation
							Here is my 
							multiline feature 
							explanation
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1700, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAFeatureExplanationWithQuotes()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						Explanation
							Here is ""my"" 
							multiline feature 
							explanation
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1700, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAFeatureStatement()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						Explanation
							Here is my 
							multiline feature 
							explanation
						Statement
							As a user
							So that you derive some value
							You can perform some action with the product
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1710, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAFeatureWithTrailingSpaces()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1     
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1800, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithACapabilityWithTrailingSpaces()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1     
					My Feature 1
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(1900, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithIgnoredFeatureReasonTags()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1 #R-IgnoredReasonTag
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2000, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithFeatureGeneralTags()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1 #T-MyFeatureTag #T-MyFeatureTag2
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2100, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithFeatureOwnerTags()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1 @MyFeatureOwner1 @MyFeatureOwner2
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2200, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithIgnoredCapabilityTags()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1 #R-Ignored #T-Ignored @Ignored
					My Feature 1
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2300, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithAWorkflowyTextExport()
		{
			var outline = $@"
				- My Capability 1 - My Sub Capability 1
				  - My Feature 1
				    - My Scenario 1
				      - Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2400, outline, featureFilePath);
		}
		[TestMethod]
		public async Task WithDuplicateCapabilityAndFeature()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 2
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2500, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithDuplicateCapabilityAndFeatureNonconsecutive()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
				My Capability 2 - My Sub Capability 1
					My Feature 1
						My Scenario 1
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 2
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2510, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithDuplicateCapability()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 0
						My Scenario 1
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 2
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2600, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithDuplicateFeature()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
					My Feature 1
						My Scenario 2
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2700, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithDuplicateFeatureNonconsecutive()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
					My Feature 2
						My Scenario 1
					My Feature 1
						My Scenario 2
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2800, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithDuplicateScenario()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(2900, outline, featureFilePath);
		}

		[TestMethod]
		public async Task WithDuplicateScenarioNonconsecutive()
		{
			var outline = $@"
				My Capability 1 - My Sub Capability 1
					My Feature 1
						My Scenario 1
						My Scenario 2
						My Scenario 1
							Given Step 1".RemoveIndentation(4, true);

			var featureFilePath = $"{directory}/Features/MyCapability1/MySubCapability1/MyFeature1.cs";
			
			await this.ExecuteStep(3000, outline, featureFilePath);
		}

    }
}
