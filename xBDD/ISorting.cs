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
        /// Gets a sorted List of Reasons in order of least to greatest override precedence.
		/// For example: If Scenario Reason A comes before Scenario Reason B then The parent 
		/// feature to both will have Reason B.
        /// </summary>
        /// <value>Returns the sorted list of Reason names.</value>
        List<string> GetSortedReasons();
    }
}
