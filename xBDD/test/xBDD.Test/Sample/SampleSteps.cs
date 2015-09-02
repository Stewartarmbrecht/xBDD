using xBDD;
using System.Collections.Generic;

namespace xBDD.Test.Sample
{
    [StepLibrary]
    public class SampleSteps
    {
        public int FailAttempts { get; set; }
        public string PageName { get; set; }
        public string Response { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Requires:
        /// UserName - string
        /// </summary>
        /// <param name="step"></param>
        public void the_user_logs_in_as_x(IStep step)
        {
            string userName = step.State.UserName;
            step.SetNameWithReplacement("X", userName.Quote());
        }
        /// <summary>
        /// Requires:
        /// PageName - string
        /// Adds:
        /// Response - string - Body of the page that was retrived.
        /// </summary>
        /// <param name="step"></param>
        public void the_user_loads_the_x_page(IStep step)
        {
            if (((IDictionary<string, object>)step.State).ContainsKey("PageLoadShouldFail") && step.State.PageLoadShouldFail)
                throw new System.Exception("Page load failed.");
            string pageName = step.State.PageName;
            step.SetNameWithReplacement("X", pageName.Quote());
            step.State.Response = "Here you go!";
        }
        /// <summary>
        /// Requires: Header - string - Class name to find header.
        /// </summary>
        /// <param name="step"></param>
        public void the_loaded_page_should_have_a_header_of_x(IStep step)
        {
            string header = step.State.Header;
            step.SetNameWithReplacement("X", header.Quote());
        }

        public void the_user_successfully_logs_in_after_x_failed_attempts(IStep step)
        {
            step.SetNameWithReplacement("X", FailAttempts.ToString());
        }
        public void the_user_navigates_to_the_x_page(IStep step)
        {
            step.SetNameWithReplacement("X", PageName.Quote());
            Response = "Here you go!";
        }
        public void the_loaded_page_should_have_a_title_of_x(IStep step)
        {
            step.SetNameWithReplacement("X", Title.Quote());
        }
        public void the_loaded_page_should_have_a_message_of_x(IStep step)
        {
            step.SetNameWithReplacement("X", Message.Quote());
        }
    }
}
