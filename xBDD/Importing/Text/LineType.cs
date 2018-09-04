namespace xBDD.Importing.Text
{
    enum LineType
    {
        Unknown,
        LastLine,
        Empty,
        Area,
        Feature,
        Scenario,
        Step,
        FeatureStatementHeader,
        FeatureStatement,
		ScenarioExplanationHeader,
		ScenarioExplanation,
		FeatureExplanationHeader,
		FeatureExplanation,
		StepExplanationHeader,
		StepExplanation,
		AreaExplanationHeader,
		AreaExplanation,
        StepInputHeader,
        StepInput
    }
}