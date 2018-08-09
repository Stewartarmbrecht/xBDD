namespace xBDD 
{
    /// <summary>
    /// Interface the festure class should implement if it would like to have 
    /// the scenario output to a specific output writer. 
    /// </summary>
    public interface IFeature 
    {
        /// <summary>
        /// Gets the output writer the scenario should use for
        /// writing output during the text execution.
        /// </summary>
        /// <value>Returns the output writer.</value>
        IOutputWriter OutputWriter { get; } 
    }
}
