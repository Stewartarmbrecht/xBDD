namespace xBDD 
{
    using xBDD.Model;
	/// <summary>
	/// Provides extension methods for the Step object.
	/// </summary>
    public static class StepExtensions
    {
		/// <summary>
		/// Adds an explanation on the end of a Steps name.
		/// </summary>
		/// <param name="step">The step to add the explanation to the end of the name.</param>
		/// <param name="explanation">The explanation that follows the word ' because '.</param>
		/// <returns></returns>
        public static Step Because(this Step step, string explanation)
        {
            step.AppendToName($" because {explanation}");
            return step;
        }
    }
}

