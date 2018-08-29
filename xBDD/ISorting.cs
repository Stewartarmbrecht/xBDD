namespace xBDD 
{
	using System.Collections.Generic;
    /// <summary>
    /// Interface for defining the sort for the features in a project.
    /// </summary>
    public interface ISorting
    {
        /// <summary>
        /// Gets a sorted string array of feature names..
        /// </summary>
        /// <value>Returns the sorted list of feature names.</value>
        List<string> GetSortedFeatureNames();
        /// <summary>
        /// Gets a sorted string array of feature names that was created by the xBDD code generation system.
        /// </summary>
        /// <value>Returns the sorted list of feature names generated from a test run.</value>
        List<string> GetGeneratedSortedFeatureNames();
        /// <summary>
        /// Gets a sorted List of Reasons in order of least to greatest override precedence.
		/// For example: If Scenario Reason A comes before Scenario Reason B then The parent 
		/// feature to both will have Reason B.
        /// </summary>
        /// <value>Returns the sorted list of Reason names.</value>
        List<string> GetSortedReasons();
        /// <summary>
        /// Gets a sorted list of reasons that was created by the xBDD code generation system.
        /// </summary>
        /// <value>Returns the sorted list of Reason names generated from a test run.</value>
        List<string> GetGeneratedReasons();
    }
}
