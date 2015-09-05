using System.Collections.Generic;

namespace xBDD.Stats
{
    public interface IAreaStats
    {
        IAreaStats Parent { get; set; }
        string Name { get; set; }
        ITimeStats TimeStats { get; }
        Outcome Outcome { get; set; }
        IOutcomeStats ChildAreaStats { get; set; }
        ICollection<IAreaStats> ChildAreas { get; set; }

        IOutcomeStats ChildFeatureStats { get; set; }
        IOutcomeStats DescendentFeatureStats { get; set; }
        ICollection<IFeatureStats> ChildFeatures { get; set; }
        ICollection<IFeatureStats> DescendentFeatures { get; set; }

        IOutcomeStats ChildScenarioStats { get; set; }
        IOutcomeStats DescendentScenarioStats { get; set; }
        ICollection<IScenarioStats> ChildScenarios { get; set; }
        ICollection<IScenarioStats> DescendentScenarios { get; set; }

        IOutcomeStats ChildStepStats { get; set; }
        IOutcomeStats DescendentStepStats { get; set; }
        ICollection<IStepStats> ChildSteps { get; set; }
        ICollection<IStepStats> DescendentSteps { get; set; }
    }
}