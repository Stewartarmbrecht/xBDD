using System;
using System.Threading.Tasks;

namespace xBDD.Model
{
    /// <summary>
    /// Holds details about a step.
    /// </summary>
    public class Step
    {

        /// <summary>
        /// The scenario the step is a part of.
        /// </summary>
        /// <value><see cref="Scenario"/></value>
        public Scenario Scenario { get; internal set; }
        
        /// <summary>
        /// The name of the step.
        /// </summary>
        /// <value><see cref="string"/></value>
        public string Name { get; internal set; }

        /// <summary>
        /// Adds text to the end of the step name.
        /// </summary>
        /// <param name="text"></param>
        public void AppendToName(string text)
        {
            this.Name = this.Name + text;
        }
        
        /// <summary>
        /// The full name of the step that will displayed to the user in the scenario.
        /// Includes the action: Given, When, Then, And etc.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public string FullName { get { return Enum.GetName(typeof(ActionType), ActionType) + " " + Name; } }

        /// <summary>
        /// Multiline string value displayed below the step to explain the input to the step.
        /// </summary>
        /// <value><see cref="string"/></value>
        public string MultilineParameter { get; internal set; }

        /// <summary>
        /// The format for the multiline parameter.
        /// This is used to set the Prettify option in the browser if the text is a programming language.
        /// </summary>
        /// <value><see cref="TextFormat"/></value>
        public TextFormat MultilineParameterFormat { get; internal set; }

        /// <summary>
        /// The action to execute if the step is a synchronous action.
        /// </summary>
        /// <value><see cref="Action{Step}"/></value>
        public Action<Step> Action { get; internal set; }

        /// <summary>
        /// The function to execute if the step is an asynchronous action.
        /// </summary>
        /// <value><see cref="Func{Step,Task}"/></value>
        public Func<Step, Task> ActionAsync { get; internal set; }

        /// <summary>
        /// The type of action for the steps.
        /// This can be either Given, When, Then, or And.
        /// </summary>
        /// <value><see cref="ActionType"/></value>
        public ActionType ActionType { get; internal set; }

        /// <summary>
        /// The time when the step started execution.
        /// </summary>
        /// <value><see cref="DateTime"/></value>
        public DateTime StartTime { get; internal set; }

        /// <summary>
        /// The time when the step completed execution.
        /// </summary>
        /// <value></value>
        public DateTime EndTime { get; internal set; }

        /// <summary>
        /// The duration of the step execution.
        /// </summary>
        /// <value><see cref="TimeSpan"/></value>
        public TimeSpan Time { get; internal set; }

        /// <summary>
        /// The outcome of the step.
        /// </summary>
        /// <value></value>
        public Outcome Outcome { get; internal set; }

        /// <summary>
        /// The reason the step had the outcome it did.
        /// </summary>
        /// <value><see cref="String"/></value>
        public string Reason { get; internal set; }

        /// <summary>
        /// The execption thrown by the step if it threw an exception when executing.
        /// </summary>
        /// <value><see cref="Exception"/></value>
        public Exception Exception { get; internal set; }

        /// <summary>
        /// Any output created by the step during execution.
        /// </summary>
        /// <value><see cref="String"/></value>
        public string Output { get; set; }

        /// <summary>
        /// The format to use when displaying the output to the user.
        /// </summary>
        /// <value><see cref="TextFormat"/></value>
        public TextFormat OutputFormat { get; set; }
    }
}