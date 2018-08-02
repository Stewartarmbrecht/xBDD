namespace xBDD.Model
{
    /// <summary>
    /// Standardized stats for a object in the test execution hierarchy.
    /// </summary>
    public class OutcomeStats
    {
        /// <summary>
        /// Gets and sets the total number of child objects that peformed tests.
        /// </summary>
        /// <value>Integer</value>
        public int Total { get; internal set; }
        /// <summary>
        /// Gets and sets the total number of child objects that passed all tests.
        /// </summary>
        /// <value>Integer</value>
        public int Passed { get; internal set; }
        /// <summary>
        /// Gets and sets the total number of child objects that skipped one or more tests and failed none.
        /// </summary>
        /// <value>Integer</value>
        public int Skipped { get; internal set; }
        /// <summary>
        /// Gets and sets the total number of child objects that failed one or more tests.
        /// </summary>
        /// <value>Integer</value>
        public int Failed { get; internal set; }
    }
}
