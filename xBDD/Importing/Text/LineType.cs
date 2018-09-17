namespace xBDD.Importing.Text
{
    enum LineType
    {
        Unknown,
        LastLine,
        Empty,
        Capability,
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
		CapabilityExplanationHeader,
		CapabilityExplanation,
        StepInputHeader,
        StepInput
    }
}