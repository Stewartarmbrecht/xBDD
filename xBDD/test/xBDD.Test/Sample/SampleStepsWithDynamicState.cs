using xBDD;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace xBDD.Test.Sample
{
    [StepLibrary]
    public class SampleStepsWithDynamicState
    {
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
        /// UserName - string
        /// </summary>
        /// <param name="step"></param>
        public async Task the_user_logs_in_as_x_async(IStep step)
        {
            string userName = step.State.UserName;
            step.SetNameWithReplacement("X", userName.Quote());
            await Task.Run(() => { });
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
            string pageName = step.State.PageName;
            step.SetNameWithReplacement("X", pageName.Quote());
            if (((IDictionary<string, object>)step.State).ContainsKey("PageLoadShouldFail") && step.State.PageLoadShouldFail)
                throw new System.Exception("Page load failed.");
            step.State.Response = "Here you go!";
        }

        internal void the_time_is_captured_and_the_step_fails(IStep step)
        {
            System.Threading.Thread.Sleep(10);
            step.State.CapturedTime = DateTime.Now;
            System.Threading.Thread.Sleep(10);
            throw new Exception("Deliberate");
        }

        internal void the_time_is_captured(IStep step)
        {
            System.Threading.Thread.Sleep(10);
            step.State.CapturedTime = DateTime.Now;
            System.Threading.Thread.Sleep(10);
        }

        /// <summary>
        /// Requires:
        /// PageName - string
        /// Adds:
        /// Response - string - Body of the page that was retrived.
        /// </summary>
        /// <param name="step"></param>
        public async Task the_user_loads_the_x_page_async(IStep step)
        {
            string pageName = step.State.PageName;
            step.SetNameWithReplacement("X", pageName.Quote());
            await Task.Run(() => {
                if (((IDictionary<string, object>)step.State).ContainsKey("PageLoadShouldFail") && step.State.PageLoadShouldFail)
                    throw new System.Exception("Page load failed.");
                step.State.Response = "Here you go!";
            });
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

        /// <summary>
        /// Requires: Header - string - Class name to find header.
        /// </summary>
        /// <param name="step"></param>
        public async Task the_loaded_page_should_have_a_header_of_x_async(IStep step)
        {
            string header = step.State.Header;
            step.SetNameWithReplacement("X", header.Quote());
            await Task.Run(() => { });
        }
    }
}
