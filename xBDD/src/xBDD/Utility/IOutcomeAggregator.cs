namespace xBDD.Utility
{
    public interface IOutcomeAggregator
    {
        Outcome GetNewParentOutcome(Outcome currentParentOutcome, Outcome childOutcome);
    }
}