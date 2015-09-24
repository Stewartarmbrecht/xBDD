using System.Collections.Generic;

namespace xBDD.Stats
{
    internal class AreaStats
    {
        internal AreaStats Parent { get; set; }
        internal string Name { get; set; }
        internal TimeStats TimeStats { get; }
        internal Outcome Outcome { get; set; }
        internal OutcomeStats ChildAreaStats { get; set; }
        internal ICollection<AreaStats> ChildAreas { get; set; }

        internal OutcomeStats ChildFeatureStats { get; set; }
        internal OutcomeStats DescendentFeatureStats { get; set; }
        internal ICollection<FeatureStats> ChildFeatures { get; set; }
        internal ICollection<FeatureStats> DescendentFeatures { get; set; }

        internal OutcomeStats ChildScenarioStats { get; set; }
        internal OutcomeStats DescendentScenarioStats { get; set; }
        internal ICollection<ScenarioStats> ChildScenarios { get; set; }
        internal ICollection<ScenarioStats> DescendentScenarios { get; set; }

        internal OutcomeStats ChildStepStats { get; set; }
        internal OutcomeStats DescendentStepStats { get; set; }
        internal ICollection<StepStats> ChildSteps { get; set; }
        internal ICollection<StepStats> DescendentSteps { get; set; }
    }
}