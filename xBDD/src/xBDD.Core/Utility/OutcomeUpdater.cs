namespace xBDD.Utility
{
    public class OutcomeAggregator : IOutcomeAggregator
    {
        public Outcome GetNewParentOutcome(Outcome currentParentOutcome, Outcome childOutcome)
        {
            Outcome newOutcome = currentParentOutcome;
            switch (childOutcome)
            {
                case Outcome.NotRun:
                    break;
                case Outcome.Skipped:
                    switch (currentParentOutcome)
                    {
                        case Outcome.NotRun:
                            newOutcome = Outcome.Skipped;
                            break;
                        case Outcome.Passed:
                            newOutcome = Outcome.Skipped;
                            break;
                    }
                    break;
                case Outcome.Failed:
                    switch (currentParentOutcome)
                    {
                        case Outcome.NotRun:
                            newOutcome = Outcome.Failed;
                            break;
                        case Outcome.Skipped:
                            newOutcome = Outcome.Failed;
                            break;
                        case Outcome.Passed:
                            newOutcome = Outcome.Failed;
                            break;
                    }
                    break;
                case Outcome.Passed:
                    switch (currentParentOutcome)
                    {
                        case Outcome.NotRun:
                            newOutcome = Outcome.Passed;
                            break;
                    }
                    break;
            }
            return newOutcome;
        }
    }
}
