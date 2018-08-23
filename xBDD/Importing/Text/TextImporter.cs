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
        private string skipReason;
        private List<string> featureNames = new List<string>(); 
        private LineType GetLineType(string line, string previousLine) {
            LineType lineType = new LineType();
            if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}{indentationKey}"))
                lineType = LineType.MultilineText;
            else if(line.StartsWith($"{indentationKey}{indentationKey}{indentationKey}"))
                lineType = LineType.Step;
            else if(line.StartsWith($"{indentationKey}{indentationKey}"))
                lineType = LineType.Scenario;
            else if(line.StartsWith(indentationKey))
                lineType = LineType.Feature;
            else if(!line.StartsWith(indentationKey))
                lineType = LineType.Area;

            if(lineType == LineType.MultilineText && previousLine.StartsWith(indentationKey) && !previousLine.StartsWith($"{indentationKey}{indentationKey}"))
                lineType = LineType.FeatureStatement;
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
            return StepType;
        }
        private string GetStepName(string stepLine, StepType stepType) {
            string stepName = null;
            switch (stepType)
            {
                case StepType.Given:
                    stepName = stepLine.Substring(6, stepLine.Length-6);
                break;
                case StepType.When:
                case StepType.Then:
                    stepName = stepLine.Substring(5, stepLine.Length-5);
                break;
                case StepType.And:
                    stepName = stepLine.Substring(4, stepLine.Length-4);
                break;
            }
            return stepName;
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
                case LineType.MultilineText:
                case LineType.FeatureStatement:
                    lineContent = line.Substring(length*4, line.Length-(length*4));
                break;
                case LineType.Scenario:
                    lineContent = line.Substring(length*2, line.Length-(length*2));
                break;
                case LineType.Step:
                    lineContent = line.Substring(length*3, line.Length-(length*3));
                break;
            }
            return lineContent;
        }
        /// <summary>
        /// Creates a test run object from a text file.
        /// </summary>
        /// <param name="text">The text report to import.</param>
        /// <param name="indentationKey">The string used for indentation in the text file.</param>
        /// <param name="rootNamespace">The namspace to prepend to each area.<param>
        /// <param name="skipReason">The namspace to prepend to each area.<param>
        /// <returns>TestRun object hydrated from the text file outline.</returns>
        public TestRun ImportText(string text, string indentationKey = "\t", string rootNamespace = "", string skipReason = "Defining") {
            this.indentationKey = indentationKey;
            this.rootNamespace = rootNamespace;
            this.skipReason = skipReason;
            string[] lines = text.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            var testRunName = lines[0];

            var factory = new CoreFactory();
            var testRunBuilder = factory.CreateTestRunBuilder(testRunName);

            var currentTestRunBuilder = xB.CurrentRun;
            xB.CurrentRun = testRunBuilder;

            try {
                this.ProcessLines(lines);
            } catch {
                xB.CurrentRun = currentTestRunBuilder;
                throw;
            }
            xB.CurrentRun.SortTestRunResults(this.featureNames.ToArray());
            xB.CurrentRun.TestRun.Scenarios.ForEach(scenario => {
                if(scenario.Outcome == Outcome.NotRun)
                    scenario.Outcome = Outcome.Skipped;
                if(scenario.Reason == null)
                    scenario.Reason = this.skipReason;
            });
            var testRun = xB.CurrentRun.TestRun;
            xB.CurrentRun = currentTestRunBuilder;
            return testRun;
        }

        private void AddStep(ScenarioBuilder scenarioBuilder, StepType stepType, Step step, StringBuilder multilineParameter)
        {
            if(multilineParameter.Length > 0) {
                step.MultilineParameter = multilineParameter.ToString();
                multilineParameter.Clear();
                step.MultilineParameterFormat = TextFormat.text;
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
            }
        }

        private void ProcessLines(string[] lines) {
            string areaName = null;
            string featureName = null;
            string scenarioName = null;
            StringBuilder multilineParameter = new StringBuilder();
            ScenarioBuilder scenarioBuilder = null;
            Step currentStep = null;
            StepType currentStepType = new StepType();
            LineType previousLineType = new LineType();
            LineType currentLineType = new LineType();
            for(int x = 2; x < lines.Length; x++) //First 2 lines are test run name and blank.
            {
                try {
                    previousLineType = currentLineType;
                    var currentLine = lines[x];
                    var previousLine = lines[x-1];
                    currentLineType = this.GetLineType(currentLine, previousLine);
                    var currentLineContent = this.GetLineContent(currentLine,currentLineType);
                    switch (currentLineType)
                    {
                        case LineType.Area:
                            if(currentStep != null) {
                                this.AddStep(scenarioBuilder, currentStepType, currentStep, multilineParameter);
                                currentStep = null;
                            }
                            areaName = currentLineContent;
                        break;
                        case LineType.Feature:
                            if(currentStep != null) {
                                this.AddStep(scenarioBuilder, currentStepType, currentStep, multilineParameter);
                                currentStep = null;
                            }
                            featureName = currentLineContent;
                            this.featureNames.Add($"{areaName.ConvertAreaNameToNamespace()}.{featureName.ConvertFeatureNameToClassName()}");
                        break;
                        case LineType.Scenario:
                            if(currentStep != null) {
                                this.AddStep(scenarioBuilder, currentStepType, currentStep, multilineParameter);
                                currentStep = null;
                            }
                            scenarioName = currentLineContent;
                            var namespaceName = $"{this.rootNamespace}.{areaName.ConvertAreaNameToNamespace()}";
                            var className = featureName.ConvertFeatureNameToClassName();
                            var reason = scenarioName.ExtractReason();
                            var methodName = scenarioName.ConvertScenarioNameToMethodName();
                            CodeDetails codeDetails = new CodeDetails(
                                namespaceName,
                                className, 
                                methodName, 
                                null, 
                                null, 
                                null);
                            scenarioBuilder = xB.CurrentRun.AddScenario(codeDetails,x);
                            scenarioBuilder.Scenario.Reason = reason;
                        break;
                        case LineType.Step:
                            if(currentStep != null) {
                                this.AddStep(scenarioBuilder, currentStepType, currentStep, multilineParameter);
                                currentStep = null;
                            }
                            currentStepType = this.GetStepType(currentLineContent);
                            var stepName = this.GetStepName(currentLineContent, currentStepType);
                            currentStep = xB.CreateStep(stepName, (s) => {});
                        break;
                        case LineType.MultilineText:
                            multilineParameter.AppendLine(currentLineContent);
                        break;
                    }
                } catch (Exception) {
                    throw new TextImportException(x, lines[x], Enum.GetName(typeof(LineType), previousLineType) );
                }
            }
            if(currentStep != null) {
                this.AddStep(scenarioBuilder, currentStepType, currentStep, multilineParameter);
                currentStep = null;
            }
        }
    }
}