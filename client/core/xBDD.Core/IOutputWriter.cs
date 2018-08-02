namespace xBDD
{
    /// <summary>
    /// Used by xBDD to write output while running.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Writes a line of output.
        /// </summary>
        /// <param name="text">The text to write.</param>
        void WriteLine(string text);
    }
}
