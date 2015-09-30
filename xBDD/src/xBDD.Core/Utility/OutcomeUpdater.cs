using xBDD.Model;

namespace xBDD.Utility
{
    internal class OutcomeAggregator
    {
        internal Outcome GetNewParentOutcome(Outcome currentParentOutcome, Outcome childOutcome)
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
        internal Outcome GetNewScenarioOutcome(Outcome scenarioOutcome, Outcome stepOutcome)
        {
            Outcome newOutcome = scenarioOutcome;
            switch (stepOutcome)
            {
                case Outcome.NotRun:
                    break;
                case Outcome.Skipped:
                    switch (scenarioOutcome)
                    {
                        case Outcome.NotRun:
                            newOutcome = Outcome.Failed;
                            break;
                        case Outcome.Passed:
                            newOutcome = Outcome.Failed;
                            break;
                    }
                    break;
                case Outcome.Failed:
                    switch (scenarioOutcome)
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
                    switch (scenarioOutcome)
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
