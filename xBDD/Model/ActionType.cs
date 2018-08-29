namespace xBDD.Model
{
    /// <summary>
    /// The action for a step in a scenario.
    /// </summary>
    public enum ActionType
    {
        ///<Summary>Given</Summary>
        Given,
        ///<Summary>When</Summary>
        When,
        ///<Summary>Then</Summary>
        Then,
        ///<Summary>And: used after a Given, When, or Then if multiple steps take place before the transition.</Summary>
        And,
        ///<Summary>Code: used internally by the system to generate a step whose name represents actual code that should 
		/// be written for a test when generating a feature file.</Summary>
		Code
    }
}