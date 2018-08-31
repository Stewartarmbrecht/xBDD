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
        private LineType GetLineType(string line, LineType previousLineType) {
            LineType lineType = new LineType();

			//Step Input Header
            if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}Input"))
                lineType = LineType.StepInputHeader;
			//Step Explanation Header
            else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}Explanation"))
                lineType = LineType.StepExplanationHeader;

			//Step Input
            else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.StepInputHeader || previousLineType == LineType.StepInput))
                lineType = LineType.StepInput;
			//Step Explanation
            else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.StepExplanationHeader || previousLineType == LineType.StepExplanation))
                lineType = LineType.StepExplanation;

			//Scenario Explanation Header
            else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}Explanation"))
                lineType = LineType.ScenarioExplanationHeader;
			//Scenario Explanation
            else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.ScenarioExplanationHeader || previousLineType == LineType.ScenarioExplanation))
                lineType = LineType.ScenarioExplanation;

			//Feature Explanation Header
            else if(line.StartsWith($"{indentationKey}{indentationKey}Explanation"))
                lineType = LineType.FeatureExplanationHeader;
			//Feature Explanation
            else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.FeatureExplanationHeader || previousLineType == LineType.FeatureExplanation))
                lineType = LineType.FeatureExplanation;

			//Feature Statement Header
            else if(line.StartsWith($"{indentationKey}{indentationKey}Statement"))
                lineType = LineType.FeatureStatementHeader;
			//Feature Explanation
            else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.FeatureStatementHeader || previousLineType == LineType.FeatureStatement))
                lineType = LineType.FeatureStatement;

			//Area Explanation Header
            else if(line.StartsWith($"{indentationKey}Explanation"))
                lineType = LineType.AreaExplanation;
			//Area Explanation
            else if(line.StartsWith($"{indentationKey}{indentationKey}")
				&& (previousLineType == LineType.AreaExplanationHeader || previousLineType == LineType.AreaExplanation))
                lineType = LineType.AreaExplanation;

			//Step
            else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}"))
                lineType = LineType.Step;

			//Scenario
            else if(line.StartsWith($"{indentationKey}{indentationKey}"))
                lineType = LineType.Scenario;

			//Feature
            else if(line.StartsWith(indentationKey))
                lineType = LineType.Feature;

			//Area
            else if(!line.StartsWith(indentationKey))
                lineType = LineType.Area;

            return lineType;
        }
        private StepType GetStepType(string step) {
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
        private string GetLineContent(string line, LineType lineType) {
            string lineContent = null;
            var length = $"{this.indentationKey}".Length;
            switch (lineType)
            {
                case LineType.Area:
                    lineContent = line;
                break;
                case LineType.Feature:
                    lineContent = line.Substring(length, line.Length-(length));
                break;
                case LineType.Scenario:
                case LineType.AreaExplanation:
                    lineContent = line.Substring(length*2, line.Length-(length*2));
                break;
                case LineType.Step:
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
			string featureExplanation) 
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
				scenarioExplanation.ToString(),
				featureExplanation.ToString(),
				scenarioAssignments,
				scenarioTags,
				featureAssignments,
				featureTags);
			var scenarioBuilder = xB.CurrentRun.AddScenario(codeDetails,this.scenarioCount + 1000);
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
            for(int x = 0; x < lines.Length; x++) //First 2 lines are test run name and blank.
            {
                try {
                    previousLineType = currentLineType;
                    var currentLine = lines[x];
					string previousLine = null;
					if(x > 0) {
	                    previousLine = lines[x-1];
					}
                    currentLineType = this.GetLineType(currentLine, previousLineType);
                    var currentLineContent = this.GetLineContent(currentLine,currentLineType);
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
									featureExplanation.ToString());
								scenarioName = null;
								scenarioExplanation.Clear();
								featureExplanation.Clear();
							}
                            if(currentStep != null) {
                                this.AddStep(scenarioBuilder, currentStepType, currentStep, stepInput, stepExplanation);
                                currentStep = null;
                            }
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
							if(scenarioName != null) {
								scenarioBuilder = this.AddScenario(
									areaName, 
									featureName, 
									scenarioName, 
									asAStatement, 
									youCanStatement, 
									byStatement, 
									scenarioExplanation.ToString(), 
									featureExplanation.ToString());
								scenarioName = null;
								scenarioExplanation.Clear();
								featureExplanation.Clear();
							}
                            if(currentStep != null) {
                                this.AddStep(scenarioBuilder, currentStepType, currentStep, stepInput, stepExplanation);
                                currentStep = null;
                            }
							this.scenarioCount = 0;
                            featureName = currentLineContent;
                            this.featureNames.Add($"{rootNamespace}.{areaName.ConvertAreaNameToNamespace()}.{featureName.ConvertFeatureNameToClassName()}");
                        break;
                        case LineType.Scenario:
							if(scenarioName != null) {
								scenarioBuilder = this.AddScenario(
									areaName, 
									featureName, 
									scenarioName, 
									asAStatement, 
									youCanStatement, 
									byStatement, 
									scenarioExplanation.ToString(), 
									featureExplanation.ToString());
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
									featureExplanation.ToString());
								scenarioName = null;
								scenarioExplanation.Clear();
								featureExplanation.Clear();
							}
                            if(currentStep != null) {
                                this.AddStep(scenarioBuilder, currentStepType, currentStep, stepInput, stepExplanation);
                                currentStep = null;
                            }
                            currentStepType = this.GetStepType(currentLineContent);
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
                } catch (Exception) {
                    throw new TextImportException(x, lines[x], Enum.GetName(typeof(LineType), previousLineType) );
                }
            }
			if(scenarioName != null) {
				scenarioBuilder = this.AddScenario(
					areaName, 
					featureName, 
					scenarioName, 
					asAStatement, 
					youCanStatement, 
					byStatement, 
					scenarioExplanation.ToString(), 
					featureExplanation.ToString());
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