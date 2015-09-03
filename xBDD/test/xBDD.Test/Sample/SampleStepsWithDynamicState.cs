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
        public void the_user_logs_in_as_UserName(IStep step)
        {
            string userName = step.State.UserName;
            step.SetNameWithReplacement("UserName", userName.Quote());
        }
        /// <summary>
        /// Requires:
        /// UserName - string
        /// </summary>
        /// <param name="step"></param>
        public async Task the_user_logs_in_as_UserName_async(IStep step)
        {
            string userName = step.State.UserName;
            step.SetNameWithReplacement("UserName", userName.Quote());
            await Task.Run(() => { });
        }
        /// <summary>
        /// Requires:
        /// PageName - string
        /// Adds:
        /// Response - string - Body of the page that was retrived.
        /// </summary>
        /// <param name="step"></param>
        public void the_user_loads_the_PageName_page(IStep step)
        {
            string pageName = step.State.PageName;
            step.SetNameWithReplacement("PageName", pageName.Quote());
            if (((IDictionary<string, object>)step.State).ContainsKey("PageLoadShouldFail") && step.State.PageLoadShouldFail)
                throw new System.Exception("Page load failed.");
            if (((IDictionary<string, object>)step.State).ContainsKey("PageLoadShouldSkip") && step.State.PageLoadShouldSkip)
                throw new System.Exception("Not Implemented.");
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
        public async Task the_user_loads_the_PageName_page_async(IStep step)
        {
            string pageName = step.State.PageName;
            step.SetNameWithReplacement("PageName", pageName.Quote());
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
        public void the_loaded_page_should_have_a_header_of_ExpectedHeader(IStep step)
        {
            string header = step.State.Header;
            step.SetNameWithReplacement("ExpectedHeader", header.Quote());
        }

        /// <summary>
        /// Requires: Header - string - Class name to find header.
        /// </summary>
        /// <param name="step"></param>
        public async Task the_loaded_page_should_have_a_header_of_ExpectedHeader_async(IStep step)
        {
            string header = step.State.Header;
            step.SetNameWithReplacement("ExpectedHeader", header.Quote());
            await Task.Run(() => { });
        }
    }
}
