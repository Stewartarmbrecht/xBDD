using System;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Model;

namespace xBDD
{
    /// <summary>
    /// Root class of the testing framework.
    /// </summary>
    public partial class xB
    {
        static CoreFactory factory;
        static TestRunBuilder testRunBuilder;
        /// <summary>
        /// Provides access to the test run builder used across all tests in the test run.
        /// </summary>
        /// <value>TestRunBuilder</value>
        public static TestRunBuilder CurrentRun
        {
            get
            {
                EnsureFactory();
                if (testRunBuilder == null)
                {
                    testRunBuilder = factory.CreateTestRunBuilder(null);
                }
                return testRunBuilder;
            }
            set
            {
                testRunBuilder = value;
            }
        }

        /// <summary>
        /// Creates a step that can be added to a scenario that will executed synchronously.
        /// </summary>
        /// <param name="stepName">The text to display for the step.</param>
        /// <param name="action">The action that will be called when executing the step.</param>
        /// <param name="multilineParameter">The multiline parameter to display below the step.</param>
        /// <param name="multilineParameterFormat">The format to use when displaying the multiline paramter.</param>
        /// <returns>New step that can be added to a scenario.</returns>
        public static Step CreateStep(
            string stepName, 
            Action<Step> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            action = action ?? ((s) => { });
            return factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
        }

        /// <summary>
        /// Creates a step that can be added to a scenario that will executed synchronously.
        /// </summary>
        /// <param name="stepName">The text to display for the step.</param>
        /// <param name="action">The asynchronous function to call.</param>
        /// <param name="multilineParameter">The multiline parameter to display below the step.</param>
        /// <param name="multilineParameterFormat">The format to use when displaying the multiline paramter.</param>
        /// <returns>New async step that can be added to a scenario.</returns>
        public static Step CreateAsyncStep(
            string stepName, 
            Func<Step, Task> action = null,
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            action = action ?? ((s) => { return Task.Run(() => { }); });
            return factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
        }

        static void EnsureFactory()
        {
            if (factory == null)
                factory = new CoreFactory();
        }
    }
}
