using System;

namespace xBDD
{
    /// <summary>
    /// Thrown when a step experiences an exception during execution.
    /// </summary>
    public class TextImportException : Exception
    {
        /// <summary>
        /// Creates a new step exception.
        /// </summary>
        /// <param name="lineNumber">The number of the line that failed.</param>
        /// <param name="lineContent">The content of the line that failed.</param>
        /// <param name="previousLineType">The type of line processed before the failing line.</param>
        internal TextImportException(int lineNumber, string lineContent, string previousLineType)
            : base($@"The text importer failed to proces line number {lineNumber}.
            The line type for the line before it was for a {previousLineType}.
            The content of the line was:
            '{lineContent}'")
        {
        }
        internal TextImportException(string message)
            : base(message)
        {
        }
    }
}