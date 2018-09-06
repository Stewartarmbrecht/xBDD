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
	[YouCan("quickly troubleshoot an invalid feature import outline")]
	[By("reviewing the detailed error messages in the xBDD tools output")]
	public partial class WithAnInvalidOutline: xBDDFeatureBase
	{

		string directory = "./MyGeneratedSample.Features";
		string[] xbddToolsCommandArgs = new[] { "project", "generate", "MSTest" };
		Developer you = new Developer();
		private async Task ExecuteStep(int number, string outline, string outputTemplate, [CallerMemberName]string methodName = null) {
			var outputWrapper = new Wrapper<string>();
			await xB.AddScenario(this, number, methodName)
				.Given(you.HaveAnEmptyDirectory("./MyGeneratedSample.Features"))
				.And($"add a scenario outline file with the following content:",
					s => {
						var filePath = "./MyGeneratedSample.Features/xBDDFeatureImport.txt";
						System.IO.File.WriteAllText(filePath, outline);
					}, outline, TextFormat.text)
				.When(you.RunTheXbddToolsCommand(xbddToolsCommandArgs, directory, outputWrapper))
				.Then(you.WillSeeOutput(outputTemplate, outputWrapper))
				.Run();
		}

		[TestMethod]
		public async Task WithInvalidCharactersInAreaName() {
			var outline = $@"
				My Area 1 - My $%^& Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1 #R-Committed @Stewart #T-LoveIT
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1 #R-Committed @Jane #T-HateIT
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation
									Here is my 
									step explanation
								Input
									Here is my 
									step input
							When step 2
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An area is defined with invalid characters in the name.
				Line 1: 'My Area 1 - My $%^& Sub Area 1'
				Explanation: An area name must start with a letter and can only contain
				             letters, numbers, spaces, underscores, and ' - '.
				             The ' - ' string is converted to '.' to define the features 
				             namespace in the test project.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(1, outline, outputTemplate);
		}

		[TestMethod]
		public async Task WithInvalidCharactersInFeatureName() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My $%^& Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation
									Here is my 
									step explanation
								Input
									Here is my 
									step input
							When step 2
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: A feature is defined with invalid characters in the name.
				Line 6: 'My $%^& Feature 1'
				Explanation: A feature name must start with a letter and can only contain
				             letters, numbers, spaces, and underscores.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(2, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithInvalidCharactersInScenarioName() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1 #R-Committed @Stewart #T-LoveIT
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My $%^& Scenario 1
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation
									Here is my 
									step explanation
								Input
									Here is my 
									step input
							When step 2
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: A scenario is defined with invalid characters in the name.
				Line 15: 'My $%^& Scenario 1'
				Explanation: A scenario name must start with a letter and can only contain
				             letters, numbers, spaces, and underscores.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(3, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithEmptyFeatureLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1 #R-Committed @Stewart #T-LoveIT
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation
									Here is my 
									step explanation
								Input
									Here is my 
									step input
							When step 2
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: Line 6: A feature is defined with no name.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(4, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithEmptyScenarioLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation
									Here is my 
									step explanation
								Input
									Here is my 
									step input
							When step 2
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: Line 15: A scenario is defined with no name.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(5, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithEmptyStepLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation
									Here is my 
									step explanation
								Input
									Here is my 
									step input
							When step 2
							
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: Line 27: A step is defined with no name.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(6, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithStepInputHeaderOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation
									Here is my 
									step explanation
								Input".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following a step input header.
				Line 23: ''
				Explanation: A step input header line can only be followed by an indented input line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(7, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithStepExplanationHeaderOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following a step explanation header.
				Line 20: ''
				Explanation: A step explanation header line can only be followed by an indented 
				             explanation line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(8, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithScenarioExplanationHeaderOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following an scenario explanation header line.
				Line 16: ''
				Explanation: A scenario explanation header line can only be followed by an indented 
				             explanation line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(9, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithFeatureExplanationOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following a feature explanation line.
				Line 13: ''
				Explanation: A Feature explanation line can only be followed by another explanation 
				             line, a feature statement header line or an outdented (2x) scenario line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(10, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithFeatureExplanationHeaderOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following a feature explanation header line.
				Line 11: ''
				Explanation: A feature explanation header line can only be followed by an indented 
				             explanation line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(11, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithFeatureStatementOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following a feature Statement line.
				Line 10: ''
				Explanation: A feature statement line can only be followed by another statement line, 
				             a feature explanation header line or an outdented (2x) scenario line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(12, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithFeatureStatementHeaderOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following a feature statement header line.
				Line 7: ''
				Explanation: A feature statement header line can only be followed by an indented 
				             statement line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(13, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithFeatureOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' following a feature line.
				Line 6: ''
				Explanation: A feature line can only be followed by an indented scenario name, indented
				             'Explanation' header or indented 'Statement' header.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(14, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithAreaExplanationOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following an area explanation line.
				Line 4: ''
				Explanation: An area explanation line can only be followed by another explanation line 
				             or an outdented (2x) feature line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(15, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithAreaExplanationHeaderOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following an area explanation header line.
				Line 2: ''
				Explanation: An area explanation header line can only be followed by an indented 
				             explanation line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(16, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithAreaOnLastLine() {
			var outline = $@"
				My Area 1 - My Sub Area 1".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'No Line' is following an area line.
				Line 1: ''
				Explanation: An area line can only be followed by an indented 'Explanation' header or 
				             indented Feature line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(17, outline, outputTemplate);
		}

 		[TestMethod]
		public async Task WithNoLines() {
			var outline = "";

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: The file is empty.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(18, outline, outputTemplate);
		}

		[TestMethod]
		public async Task WithInvalidLineAfterStepInputHeader() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation
									Here is my 
									step explanation
								Input
							When step 2 Is Invalid Line
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Step' is following a step input header.
				Line 24: '			When step 2 Is Invalid Line'
				Explanation: A step input header line can only be followed by an indented input line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(19, outline, outputTemplate);
		}
		[TestMethod]
		public async Task WithInvalidLineAfterStepExplanationHeader() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Explanation
								Input
									Here is the
									Step input 
							When step 2
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'StepInputHeader' is following a step explanation header.
				Line 21: '				Input'
				Explanation: A step explanation header line can only be followed by an indented 
				             explanation line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(20, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidLineAfterStep() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation
								Here is my 
								scenario explanation
							Given step 1
								Invalid Line
							When step 2
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Unknown' is following a step line.
				Line 20: '				Invalid Line'
				Explanation: A step line can only be followed by another step line or an indented 
				             'Explanation' or 'Input' header line, or outdented scenario, feature, or 
				             area.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(21, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidStepLineAfterStep() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation
								Here is my 
								scenario explanation
							Given step 1
							Invalid Line
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: Invalid step starter.
				Line 20: 'Invalid Line'
				Explanation: A step can start with either 'Given', 'When', 'Then', 'And', or '.'
				             Steps that start with '.' will have it's text interpreted as literal code 
				             when generating feature classes.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(22, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidLineAfterScenarioExplanationHeader() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Explanation
							Given step 1
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Step' is following an scenario explanation header line.
				Line 17: '			Given step 1'
				Explanation: A scenario explanation header line can only be followed by an indented 
				             explanation line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(23, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidLineAfterScenario() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
							Invalid Line
							Given step 1
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: Invalid step starter.
				Line 16: 'Invalid Line'
				Explanation: A step can start with either 'Given', 'When', 'Then', 'And', or '.'
				             Steps that start with '.' will have it's text interpreted as literal code 
				             when generating feature classes.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(24, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidIndentedStepLineAfterScenario() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
				
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
							Here is my 
							feature explanation
				
						My Scenario 1
								Given step 1
							Then step 3
							And step 4".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Unknown' is following a scenario line.
				Line 16: '				Given step 1'
				Explanation: A scenario line can only be followed by another scenario line, an indented
				             'Explanation' header or indented step line, or an outdented feature or 
				             area line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(25, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidLineAfterFeatureExplanationHeader() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
					My Feature 1
						Statement
							As a user
							You can get some value
							By doing something
						Explanation
						My Scenario 1".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Scenario' is following a feature explanation header line.
				Line 11: '		My Scenario 1'
				Explanation: A feature explanation header line can only be followed by an indented 
				             explanation line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(26, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidLineAfterFeatureStatementHeader() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
					My Feature 1
						Statement
						My Scenario 1".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Scenario' is following a feature statement header line.
				Line 7: '		My Scenario 1'
				Explanation: A feature statement header line can only be followed by an indented 
				             statement line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(27, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidLineAfterFeature() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
						Here is 
						my explanation
					My Feature 1
					My Feature 2
						My Scenario 1".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Feature' following a feature line.
				Line 6: '	My Feature 2'
				Explanation: A feature line can only be followed by an indented scenario name, indented
				             'Explanation' header or indented 'Statement' header.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(28, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidLineAfterAreaExplanationHeader() {
			var outline = $@"
				My Area 1 - My Sub Area 1
					Explanation
					My Feature 1".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Feature' is following an area explanation header line.
				Line 3: '	My Feature 1'
				Explanation: An area explanation header line can only be followed by an indented 
				             explanation line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(29, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidLineAfterArea() {
			var outline = $@"
				My Area 1 - My Sub Area 1
				My Area 1 - My Sub Area 2".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Area' is following an area line.
				Line 2: 'My Area 1 - My Sub Area 2'
				Explanation: An area line can only be followed by an indented 'Explanation' header or 
				             indented Feature line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(30, outline, outputTemplate);
		}
 		[TestMethod]
		public async Task WithInvalidIndentedLineAfterArea() {
			var outline = $@"
				My Area 1 - My Sub Area 1
						Invalid Line".RemoveIndentation(4, true);

			var outputTemplate = $@"
				{{{{.*}}}}/rl
				Error: An invalid line of type 'Scenario' is following an area line.
				Line 2: '		Invalid Line'
				Explanation: An area line can only be followed by an indented 'Explanation' header or 
				             indented Feature line.
				".RemoveIndentation(4, true);
			
			await this.ExecuteStep(31, outline, outputTemplate);
		}
   }
}
