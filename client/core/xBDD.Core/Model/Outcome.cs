namespace xBDD.Model
{
    /// <summary>
    /// The outcome from testing.
    /// </summary>
    public enum Outcome
    {
        ///<Summary>One or more tests not run, none skipped, none failed.</Summary>
        NotRun = 0,
        ///<Summary>All tests passed.</Summary>
        Passed = 1,
        ///<Summary>One or more tests failed.</Summary>
        Failed = 2,
        ///<Summary>One or more tests skipped, none failed.</Summary>
        Skipped = 3
    }
}