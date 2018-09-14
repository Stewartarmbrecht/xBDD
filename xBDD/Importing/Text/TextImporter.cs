namespace xBDD.Importing.Text
{
	using System;
	using System.Text;
	using xBDD.Model;
	using xBDD.Core;
	using xBDD.Utility;
	using xBDD;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	/// <summary>
	/// Imports text files and creates a TestRun object.
	/// </summary>
	public class TextImporter
	{
		private string indentationKey;
		private string rootNamespace;
		private Outcome defaultOutcome;
		private string defaultReason;
		private List<string> featureNames = new List<string>();
		int scenarioCount = 0;

		private void ValidateFollowingLine(LineType currentLineType, LineType previousLineType, int lineNumber, string lineContent) {
			var currentLineTypeName = Enum.GetName(typeof(LineType), currentLineType);
			if(currentLineType == LineType.LastLine) {
				currentLineTypeName = "No Line";
			}
			switch(previousLineType) {
				case LineType.Area:
					if(currentLineType != LineType.AreaExplanationHeader 
						&& currentLineType != LineType.Feature) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following an area line.
								Line {lineNumber}: '{lineContent}'
								Explanation: An area line can only be followed by an indented 'Explanation' header or 
								             indented Feature line.".RemoveIndentation(8));
						}
				break;
				case LineType.AreaExplanationHeader:
					if(currentLineType != LineType.AreaExplanation 
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following an area explanation header line.
								Line {lineNumber}: '{lineContent}'
								Explanation: An area explanation header line can only be followed by an indented 
								             explanation line.".RemoveIndentation(8));
						}
				break;
				case LineType.AreaExplanation:
					if(currentLineType != LineType.AreaExplanation
						&& currentLineType != LineType.Feature 
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following an area explanation line.
								Line {lineNumber}: '{lineContent}'
								Explanation: An area explanation line can only be followed by another explanation line 
								             or an outdented (2x) feature line.".RemoveIndentation(8));
						}
				break;
				case LineType.Feature:
					if(currentLineType != LineType.FeatureExplanationHeader 
						&& currentLineType != LineType.FeatureStatementHeader
						&& currentLineType != LineType.Scenario) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' following a feature line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A feature line can only be followed by an indented scenario name, indented
								             'Explanation' header or indented 'Statement' header.".RemoveIndentation(8));
						}
				break;
				case LineType.FeatureExplanationHeader:
					if(currentLineType != LineType.FeatureExplanation 
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a feature explanation header line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A feature explanation header line can only be followed by an indented 
								             explanation line.".RemoveIndentation(8));
						}
				break;
				case LineType.FeatureExplanation:
					if(currentLineType != LineType.FeatureExplanation
						&& currentLineType != LineType.FeatureStatementHeader 
						&& currentLineType != LineType.Scenario 
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a feature explanation line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A Feature explanation line can only be followed by another explanation 
								             line, a feature statement header line or an outdented (2x) scenario line.".RemoveIndentation(8));
						}
				break;
				case LineType.FeatureStatementHeader:
					if(currentLineType != LineType.FeatureStatement 
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a feature statement header line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A feature statement header line can only be followed by an indented 
								             statement line.".RemoveIndentation(8));
						}
				break;
				case LineType.FeatureStatement:
					if(currentLineType != LineType.FeatureStatement
						&& currentLineType != LineType.FeatureExplanationHeader 
						&& currentLineType != LineType.Scenario 
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a feature Statement line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A feature statement line can only be followed by another statement line, 
								             a feature explanation header line or an outdented (2x) scenario line.".RemoveIndentation(8));
						}
				break;
				case LineType.Scenario:
					if(currentLineType != LineType.ScenarioExplanationHeader 
						&& currentLineType != LineType.Step
						&& currentLineType != LineType.Scenario
						&& currentLineType != LineType.Feature
						&& currentLineType != LineType.Area
						&& currentLineType != LineType.LastLine
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a scenario line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A scenario line can only be followed by another scenario line, an indented
								             'Explanation' header or indented step line, or an outdented feature or 
								             area line.".RemoveIndentation(8));
						}
				break;
				case LineType.ScenarioExplanationHeader:
					if(currentLineType != LineType.ScenarioExplanation 
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following an scenario explanation header line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A scenario explanation header line can only be followed by an indented 
								             explanation line.".RemoveIndentation(8));
						}
				break;
				case LineType.ScenarioExplanation:
					if(currentLineType != LineType.ScenarioExplanation
						&& currentLineType != LineType.Step 
						&& currentLineType != LineType.Scenario 
						&& currentLineType != LineType.Feature 
						&& currentLineType != LineType.Area 
						&& currentLineType != LineType.LastLine
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following an scenario explanation line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A scenario explanation line can only be followed by another explanation 
								             line, an outdeneted (1x) step line, an outdented (2x) scenario line, an 
								             outdented (3x) feature line, or an outdented (4x) area line.".RemoveIndentation(8));
						}
				break;
				case LineType.Step:
					if(currentLineType != LineType.StepExplanationHeader 
						&& currentLineType != LineType.StepInputHeader
						&& currentLineType != LineType.Step
						&& currentLineType != LineType.Scenario
						&& currentLineType != LineType.Feature
						&& currentLineType != LineType.Area
						&& currentLineType != LineType.LastLine
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a step line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A step line can only be followed by another step line or an indented 
								             'Explanation' or 'Input' header line, or outdented scenario, feature, or 
								             area.".RemoveIndentation(8));
						}
				break;
				case LineType.StepExplanationHeader:
					if(currentLineType != LineType.StepExplanation 
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a step explanation header.
								Line {lineNumber}: '{lineContent}'
								Explanation: A step explanation header line can only be followed by an indented 
								             explanation line.".RemoveIndentation(8));
						}
				break;
				case LineType.StepExplanation:
					if(currentLineType != LineType.StepExplanation 
						&& currentLineType != LineType.StepInputHeader
						&& currentLineType != LineType.Step 
						&& currentLineType != LineType.Scenario
						&& currentLineType != LineType.Feature
						&& currentLineType != LineType.Area
						&& currentLineType != LineType.LastLine
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a step explanation line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A step explanation line can only be followed by another step explanation 
								             line or an outdented (1x) input header line, (2x) setp line, (3x) 
								             scenario line (4x) feature line, or (5x) area line.".RemoveIndentation(8));
						}
				break;
				case LineType.StepInputHeader:
					if(currentLineType != LineType.StepInput 
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a step input header.
								Line {lineNumber}: '{lineContent}'
								Explanation: A step input header line can only be followed by an indented input line.".RemoveIndentation(8));
						}
				break;
				case LineType.StepInput:
					if(currentLineType != LineType.StepInput 
						&& currentLineType != LineType.StepExplanationHeader
						&& currentLineType != LineType.Step 
						&& currentLineType != LineType.Scenario
						&& currentLineType != LineType.Feature
						&& currentLineType != LineType.Area
						&& currentLineType != LineType.LastLine
						) {
							throw new TextImportException($@"An invalid line of type '{currentLineTypeName}' is following a step input line.
								Line {lineNumber}: '{lineContent}'
								Explanation: A step input line can only be followed by another step input line or an 
								             outdented (1x) explanation header line, (2x) setp line, (3x) scenario line
								             (4x) feature line, or (5x) area line.".RemoveIndentation(8));
						}
				break;
			}
		}
		private LineType GetLineType(string line, LineType previousLineType, int lineNumber) {
			LineType lineType = new LineType();

			//Step Input Header
			if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}Input")) {
				lineType = LineType.StepInputHeader;
			}
			//Step Explanation Header
			else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}Explanation")) {
				lineType = LineType.StepExplanationHeader;
			}

			//Step Input
			else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.StepInputHeader || previousLineType == LineType.StepInput)) {
				lineType = LineType.StepInput;
			}
			//Step Explanation
			else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.StepExplanationHeader || previousLineType == LineType.StepExplanation)) {
				lineType = LineType.StepExplanation;
			}

			//Scenario Explanation Header
			else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}Explanation")) {
				lineType = LineType.ScenarioExplanationHeader;
			}
			//Scenario Explanation
			else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.ScenarioExplanationHeader || previousLineType == LineType.ScenarioExplanation)) {
				lineType = LineType.ScenarioExplanation;
			}

			//Feature Explanation Header
			else if(line.StartsWith($"{indentationKey}{indentationKey}Explanation")) {
				lineType = LineType.FeatureExplanationHeader;
			}
			//Feature Explanation
			else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.FeatureExplanationHeader || previousLineType == LineType.FeatureExplanation)) {
				lineType = LineType.FeatureExplanation;
			}

			//Feature Statement Header
			else if(line.StartsWith($"{indentationKey}{indentationKey}Statement")) {
				lineType = LineType.FeatureStatementHeader;
			}
			//Feature Explanation
			else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}") 
				&& (previousLineType == LineType.FeatureStatementHeader || previousLineType == LineType.FeatureStatement)) {
				lineType = LineType.FeatureStatement;
			}

			//Area Explanation Header
			else if(line.StartsWith($"{indentationKey}Explanation")) {
				lineType = LineType.AreaExplanationHeader;
			}
			//Area Explanation
			else if(line.StartsWith($"{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.AreaExplanationHeader || previousLineType == LineType.AreaExplanation)) {
					lineType = LineType.AreaExplanation;
				}

			//Step
			else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}")) {
				if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}")) {
					lineType = LineType.Unknown;
				} else {
					lineType = LineType.Step;
				}
			}

			//Scenario
			else if(line.StartsWith($"{indentationKey}{indentationKey}")) {
				lineType = LineType.Scenario;
			}

			//Feature
		   else if(line.StartsWith(indentationKey)) {
				lineType = LineType.Feature;
		   }

			//Area
			else if(!line.StartsWith(indentationKey)) {
				lineType = LineType.Area;
			}

			if(String.IsNullOrEmpty(line)) {
				lineType = LineType.Empty;
			} else {
				this.ValidateFollowingLine(lineType, previousLineType, lineNumber, line);
			}

			return lineType;
		}
		private StepType GetStepType(string step, int lineNumber) {
			StepType StepType = new StepType();
			if(step.ToLower().StartsWith("given"))
				StepType = StepType.Given;
			else if(step.ToLower().StartsWith("when"))
				StepType = StepType.When;
			else if(step.ToLower().StartsWith("then"))
				StepType = StepType.Then;
			else if(step.ToLower().StartsWith("and"))
				StepType = StepType.And;
			else if(step.ToLower().StartsWith("."))
				StepType = StepType.Code;
			else 
				throw new TextImportException($@"Invalid step starter.
					Line {lineNumber}: '{step}'
					Explanation: A step can start with either 'Given', 'When', 'Then', 'And', or '.'
					             Steps that start with '.' will have it's text interpreted as literal code 
					             when generating feature classes.".RemoveIndentation(5));
			return StepType;
		}
		private FeatureStatementType GetFeatureStatementType(string featureStatementLine) {
			FeatureStatementType featureStatement = new FeatureStatementType();
			if(featureStatementLine.ToLower().StartsWith("as a "))
				featureStatement = FeatureStatementType.AsA;
			else if(featureStatementLine.ToLower().StartsWith("you can "))
				featureStatement = FeatureStatementType.YouCan;
			else if(featureStatementLine.ToLower().StartsWith("by "))
				featureStatement = FeatureStatementType.By;
			return featureStatement;
		}
		private string GetStepName(string stepLine, StepType stepType) {
			string stepName = stepLine;
			var stepHasReason = stepName.Contains("#");
			if(stepHasReason) {
				stepName = stepName.Substring(0, stepName.IndexOf("#")-1);
			}
			switch (stepType)
			{
				case StepType.Given:
					stepName = stepName.Substring(6, stepName.Length-6);
				break;
				case StepType.When:
				case StepType.Then:
					stepName = stepName.Substring(5, stepName.Length-5);
				break;
				case StepType.And:
					stepName = stepName.Substring(4, stepName.Length-4);
				break;
			}
			return stepName;
		}
		private string GetFeatureStatement(string featureStatementLine, FeatureStatementType featureStatementType) {
			string featureStatement = null;
			switch (featureStatementType)
			{
				case FeatureStatementType.AsA:
					featureStatement = featureStatementLine.Substring(5, featureStatementLine.Length-5);
				break;
				case FeatureStatementType.YouCan:
					featureStatement = featureStatementLine.Substring(8, featureStatementLine.Length-8);
				break;
				case FeatureStatementType.By:
					featureStatement = featureStatementLine.Substring(3, featureStatementLine.Length-3);
				break;
			}
			return featureStatement;
		}
		private string GetLineContent(string line, LineType lineType, int lineNumber) {
			string lineContent = null;
			var length = $"{this.indentationKey}".Length;
			var areaNameRegex = "^[a-zA-Z][a-zA-Z _0-9\\.]*$";
			var featureAndScenarioNameRegex = "^[a-zA-Z][a-zA-Z _0-9]*$";
			switch (lineType)
			{
				case LineType.Area:
					lineContent = line;
					if(lineContent.Length == 0)
						throw new TextImportException($"Line {lineNumber}: An area is defined with no name.");
					var areaName = lineContent.ConvertAreaNameToNamespace();
					if(!Regex.Match(areaName, areaNameRegex).Success)
						throw new TextImportException($@"An area is defined with invalid characters in the name.
							Line {lineNumber}: '{lineContent}'
							Explanation: An area name must start with a letter and can only contain
							             letters, numbers, spaces, underscores, and ' - '.
							             The ' - ' string is converted to '.' to define the features 
							             namespace in the test project.".RemoveIndentation(7));
				break;
				case LineType.Feature:
					lineContent = line.Substring(length, line.Length-(length));
					if(lineContent.Length == 0)
						throw new TextImportException($"Line {lineNumber}: A feature is defined with no name.");
					var featureName = lineContent.ConvertFeatureNameToClassName(); 
					if(featureName.Length == 0)
						throw new TextImportException($"Line {lineNumber}: A feature is defined with no name.");
					if(!Regex.Match(featureName, featureAndScenarioNameRegex).Success)
						throw new TextImportException($@"A feature is defined with invalid characters in the name.
							Line {lineNumber}: '{lineContent}'
							Explanation: A feature name must start with a letter and can only contain
							             letters, numbers, spaces, and underscores.".RemoveIndentation(7));
				break;
				case LineType.Scenario:
					lineContent = line.Substring(length*2, line.Length-(length*2));
					if(lineContent.Length == 0)
						throw new TextImportException($"Line {lineNumber}: A scenario is defined with no name.");
					var scenarioName = lineContent.ConvertScenarioNameToMethodName();
					if(scenarioName.Length == 0)
						throw new TextImportException($"Line {lineNumber}: A scenario is defined with no name.");
					if(!Regex.Match(scenarioName, featureAndScenarioNameRegex).Success)
						throw new TextImportException($@"A scenario is defined with invalid characters in the name.
							Line {lineNumber}: '{lineContent}'
							Explanation: A scenario name must start with a letter and can only contain
							             letters, numbers, spaces, and underscores.".RemoveIndentation(7));
				break;
				case LineType.AreaExplanation:
					lineContent = line.Substring(length*2, line.Length-(length*2));
				break;
				case LineType.Step:
					lineContent = line.Substring(length*3, line.Length-(length*3));
					if(lineContent.Length == 0)
						throw new TextImportException($"Line {lineNumber}: A step is defined with no name.");
				break; 
				case LineType.FeatureExplanation:
				case LineType.FeatureStatement:
					lineContent = line.Substring(length*3, line.Length-(length*3));
				break;
				case LineType.ScenarioExplanation:
					lineContent = line.Substring(length*4, line.Length-(length*4));
				break;
				case LineType.StepInput:
				case LineType.StepExplanation:
					lineContent = line.Substring(length*5, line.Length-(length*5));
				break;
			}
			if(lineContent != null && lineContent.StartsWith("- "))
				lineContent = lineContent.Substring(2,lineContent.Length-2);
			return lineContent;
		}

		/// <summary>
		/// Imports the Workflowy text formatted export and converts
		/// it to a hydrated test run.  Make sure to delete the first 
		/// 2 lines of the workflowy export so that the first line in your
		/// saved file is an Area name.
		/// </summary>
		/// <param name="text">Workflowy plan text eport to import.</param>
		/// <param name="rootNamespace">The namspace to prepend to each area.</param>
		/// <param name="defaultOutcome">The default outcome for a scenario.</param>
		/// <param name="defaultReason">The default reason for an scenario.</param>
		/// <returns>TestRun object hydrated from the text file outline.</returns>
		public TestRun ImportWorkflowyText(
			string text, 
			string rootNamespace = "", 
			string defaultOutcome = "Skipped", 
			string defaultReason = "Defining") 
		{
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
			return this.ImportText(text, indentation, rootNamespace, defaultOutcome, defaultReason);
		}
		/// <summary>
		/// Creates a test run object from a text file.
		/// </summary>
		/// <param name="text">The text report to import.</param>
		/// <param name="indentationKey">The string used for indentation in the text file.</param>
		/// <param name="rootNamespace">The namspace to prepend to each area.</param>
		/// <param name="defaultOutcome">The default outcome for a scenario.</param>
		/// <param name="defaultReason">The default reason for an scenario.</param>
		/// <returns>TestRun object hydrated from the text file outline.</returns>
		public TestRun ImportText(
			string text, 
			string indentationKey = "\t", 
			string rootNamespace = "", 
			string defaultOutcome = "Skipped", 
			string defaultReason = "Defining") 
		{
			if(text.Length == 0) {
				throw new Exception("The file is empty.");
			}
			this.indentationKey = indentationKey;
			this.defaultOutcome = (Outcome)Enum.Parse(typeof(Outcome), defaultOutcome);
			this.rootNamespace = rootNamespace;
			this.defaultReason = defaultReason;
			string[] lines = text.Split(
				new[] { Environment.NewLine },
				StringSplitOptions.None
			);

			var factory = new CoreFactory();
			var testRunBuilder = factory.CreateTestRunBuilder(Configuration.TestRunName);

			var currentTestRunBuilder = xB.CurrentRun;
			xB.CurrentRun = testRunBuilder;

			try {
				this.ProcessLines(lines);
			} catch {
				xB.CurrentRun = currentTestRunBuilder;
				throw;
			}
			xB.CurrentRun.TestRun.SortTestRunResults(this.featureNames);
			xB.CurrentRun.TestRun.Scenarios.ForEach(scenario => {
				if(scenario.Outcome == Outcome.NotRun)
					scenario.Outcome = this.defaultOutcome;
				if(scenario.Reason == null)
					scenario.Reason = this.defaultReason;
			});
			var testRun = xB.CurrentRun.TestRun;
			xB.CurrentRun = currentTestRunBuilder;
			return testRun;
		}
		private ScenarioBuilder AddScenario(
			string areaName,
			string featureName, 
			string scenarioName, 
			string asAStatement, 
			string youCanStatement, 
			string byStatement, 
			string scenarioExplanation, 
			TextFormat scenarioExplanationFormat,
			string featureExplanation,
			TextFormat featureExplanationFormat) 
		{
			this.scenarioCount++;
			var namespaceName = $"{this.rootNamespace}.{areaName.ConvertAreaNameToNamespace()}";
			var className = featureName.ConvertFeatureNameToClassName();
			var featureAssignments = featureName.ExtractAssignments();
			var featureTags = featureName.ExtractTags();
			var reason = scenarioName.ExtractReason();
			var scenarioAssignments = scenarioName.ExtractAssignments();
			var scenarioTags = scenarioName.ExtractTags();
			var methodName = scenarioName.ConvertScenarioNameToMethodName();
			CodeDetails codeDetails = new CodeDetails(
				namespaceName,
				className, 
				methodName, 
				asAStatement, 
				youCanStatement, 
				byStatement,
				scenarioExplanation,
				scenarioExplanationFormat,
				featureExplanation,
				featureExplanationFormat,
				scenarioAssignments,
				scenarioTags,
				featureAssignments,
				featureTags);
			var scenarioBuilder = xB.CurrentRun.AddScenario(codeDetails,this.scenarioCount * 1000);
			scenarioBuilder.Scenario.Reason = reason;
			if(scenarioBuilder.Scenario.Reason == "Failed") {
				scenarioBuilder.Scenario.Outcome = Outcome.Failed;
			} else if (scenarioBuilder.Scenario.Reason != null) {
				scenarioBuilder.Scenario.Outcome = Outcome.Skipped;
			}
			return scenarioBuilder;
		}

		private void AddStep(ScenarioBuilder scenarioBuilder, StepType stepType, Step step, StringBuilder input, StringBuilder explanation)
		{
			if(input.Length > 0) {
				step.Input = input.ToString();
				input.Clear();
				step.InputFormat = TextFormat.text;
			}
			if(explanation.Length > 0) {
				step.Explanation = explanation.ToString();
				explanation.Clear();
			}
			switch (stepType)
			{
				case StepType.Given:
					scenarioBuilder.Given(step);
				break;
				case StepType.When:
					scenarioBuilder.When(step);
				break;
				case StepType.Then:
					scenarioBuilder.Then(step);
				break;
				case StepType.And:
					scenarioBuilder.And(step);
				break;
				case StepType.Code:
					scenarioBuilder.Code(step);
				break;
			}
		}

		private void ProcessLines(string[] lines) {
			string areaName = null;
			string featureName = null;
			string scenarioName = null;
			string asAStatement = null;
			string youCanStatement = null;
			string byStatement = null;
			StringBuilder stepInput = new StringBuilder();
			StringBuilder stepExplanation = new StringBuilder();
			StringBuilder scenarioExplanation = new StringBuilder();
			StringBuilder featureExplanation = new StringBuilder();
			StringBuilder areaExplanation = new StringBuilder();
			ScenarioBuilder scenarioBuilder = null;
			Step currentStep = null;
			StepType currentStepType = new StepType();
			FeatureStatementType currentFeatureStatementType = new FeatureStatementType();
			LineType previousLineType = new LineType();
			LineType currentLineType = new LineType();
			int areaFeatureCount = 0;
			int featureScenarioCount = 0;
			for(int x = 0; x < lines.Length; x++) //First 2 lines are test run name and blank.
			{
				try {
					previousLineType = currentLineType;
					var currentLine = lines[x];
					string previousLine = null;
					if(x > 0) {
						previousLine = lines[x-1];
					}
					currentLineType = this.GetLineType(currentLine, previousLineType, x+1);
					var currentLineContent = this.GetLineContent(currentLine,currentLineType, x+1);
					switch (currentLineType)
					{
						case LineType.Area:
							if(scenarioName != null) {
								scenarioBuilder = this.AddScenario(
									areaName, 
									featureName, 
									scenarioName, 
									asAStatement, 
									youCanStatement, 
									byStatement, 
									scenarioExplanation.ToString(),
									TextFormat.markdown, 
									featureExplanation.ToString(),
									TextFormat.markdown);
								scenarioName = null;
								scenarioExplanation.Clear();
								featureExplanation.Clear();
							}
							if(currentStep != null) {
								this.AddStep(scenarioBuilder, currentStepType, currentStep, stepInput, stepExplanation);
								currentStep = null;
							}
							if(areaName != null && areaFeatureCount == 0) {
								throw new TextImportException($"Line {x+1}: Area defined with no features.");
							}
							areaFeatureCount = 0;
							areaName = currentLineContent;
						break;
						case LineType.AreaExplanation:
							areaExplanation.AppendLine(currentLineContent);
						break;
						case LineType.FeatureExplanation:
							featureExplanation.AppendLine(currentLineContent);
						break;
						case LineType.ScenarioExplanation:
							scenarioExplanation.AppendLine(currentLineContent);
						break;
						case LineType.StepExplanation:
							stepExplanation.AppendLine(currentLineContent);
						break;
						case LineType.FeatureStatement:
							currentFeatureStatementType = this.GetFeatureStatementType(currentLineContent);
							var featureStatement = this.GetFeatureStatement(currentLineContent, currentFeatureStatementType);
							switch(currentFeatureStatementType) {
								case FeatureStatementType.AsA:
									asAStatement = this.GetFeatureStatement(currentLineContent, currentFeatureStatementType);
								break;
								case FeatureStatementType.YouCan:
									youCanStatement = this.GetFeatureStatement(currentLineContent, currentFeatureStatementType);
								break;
								case FeatureStatementType.By:
									byStatement = this.GetFeatureStatement(currentLineContent, currentFeatureStatementType);
								break;
							}
						break;
						case LineType.Feature:
							areaFeatureCount++;
							if(scenarioName != null) {
								if(featureScenarioCount == 0) {
									throw new TextImportException($"Line {x}: Feature defined with no scenarios.");
								}
								scenarioBuilder = this.AddScenario(
									areaName, 
									featureName, 
									scenarioName, 
									asAStatement, 
									youCanStatement, 
									byStatement, 
									scenarioExplanation.ToString(),
									TextFormat.markdown, 
									featureExplanation.ToString(),
									TextFormat.markdown);
								scenarioName = null;
								scenarioExplanation.Clear();
								featureExplanation.Clear();
							}
							if(currentStep != null) {
								this.AddStep(scenarioBuilder, currentStepType, currentStep, stepInput, stepExplanation);
								currentStep = null;
							}
							this.scenarioCount = 0;
							featureScenarioCount = 0;
							featureName = currentLineContent;
							this.featureNames.Add($"{rootNamespace}.{areaName.ConvertAreaNameToNamespace()}.{featureName.ConvertFeatureNameToClassName()}");
						break;
						case LineType.Scenario:
							featureScenarioCount++;
							if(scenarioName != null) {
								scenarioBuilder = this.AddScenario(
									areaName, 
									featureName, 
									scenarioName, 
									asAStatement, 
									youCanStatement, 
									byStatement, 
									scenarioExplanation.ToString(),
									TextFormat.markdown, 
									featureExplanation.ToString(),
									TextFormat.markdown);
								scenarioName = null;
								scenarioExplanation.Clear();
								featureExplanation.Clear();
							}
							if(currentStep != null) {
								this.AddStep(scenarioBuilder, currentStepType, currentStep, stepInput, stepExplanation);
								currentStep = null;
							}
							scenarioName = currentLineContent;
						break;
						case LineType.Step:
							if(scenarioName != null) {
								scenarioBuilder = this.AddScenario(
									areaName, 
									featureName, 
									scenarioName, 
									asAStatement, 
									youCanStatement, 
									byStatement, 
									scenarioExplanation.ToString(),
									TextFormat.markdown, 
									featureExplanation.ToString(),
									TextFormat.markdown);
								scenarioName = null;
								scenarioExplanation.Clear();
								featureExplanation.Clear();
							}
							if(currentStep != null) {
								this.AddStep(scenarioBuilder, currentStepType, currentStep, stepInput, stepExplanation);
								currentStep = null;
							}
							currentStepType = this.GetStepType(currentLineContent, x+1);
							var stepName = this.GetStepName(currentLineContent, currentStepType);
							var stepReason = currentLineContent.ExtractReason();
							Action<Step> action = (s) => {};
							if(stepReason == "Failed") {
								action = (s) => { 
									throw new Exception("Generated Failure"); 
								};
							}
							currentStep = xB.CreateStep(stepName, action);
							if(stepReason == "Failed") {
								currentStep.Outcome = Outcome.Failed;
							}
						break;
						case LineType.StepInput:
							stepInput.AppendLine(currentLineContent);
						break;
					}
				} catch (TextImportException) {
					throw;
				} catch (Exception) {
					throw new TextImportException(x+1, lines[x], Enum.GetName(typeof(LineType), previousLineType) );
				}
			}
			this.ValidateFollowingLine(LineType.LastLine, currentLineType, lines.Length, "");
			if(scenarioName != null) {
				scenarioBuilder = this.AddScenario(
					areaName, 
					featureName, 
					scenarioName, 
					asAStatement, 
					youCanStatement, 
					byStatement, 
					scenarioExplanation.ToString(),
					TextFormat.markdown, 
					featureExplanation.ToString(),
					TextFormat.markdown);
				scenarioName = null;
				scenarioExplanation.Clear();
				featureExplanation.Clear();
			}
			if(currentStep != null) {
				this.AddStep(scenarioBuilder, currentStepType, currentStep, stepInput, stepExplanation);
				currentStep = null;
			}
		}
	}
}