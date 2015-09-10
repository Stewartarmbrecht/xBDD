using xBDD;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace xBDD.Test.Sample
{
    [StepLibrary]
    public class SampleStepsWithTypedState
    {
        public string UserName { get; set; }
        public string PageName { get; set; }
        public bool PageLoadShouldFail { get; set; }
        public string Response { get; set; }
        public DateTime CapturedTime { get; set; }
        public string Header { get; set; }
        public bool PageLoadShouldSkip { get; internal set; }

        /// <summary>
        /// Requires:
        /// UserName - string
        /// </summary>
        /// <param name="step"></param>
        public void the_user_logs_in_as_UserName(IStep step)
        {
            step.ReplaceNameParameters("UserName", UserName.Quote());
        }
        /// <summary>
        /// Requires:
        /// UserName - string
        /// </summary>
        /// <param name="step"></param>
        public async Task the_user_logs_in_as_UserName_async(IStep step)
        {
            step.ReplaceNameParameters("UserName", UserName.Quote());
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
            step.ReplaceNameParameters("PageName", PageName.Quote());
            if (PageLoadShouldFail)
                throw new System.Exception("Page load failed.");
            if (PageLoadShouldSkip)
                throw new SkipStepException("Not Implemented.");
            Response = "Here you go!";
        }

        internal void the_time_is_captured_and_the_step_fails(IStep step)
        {
            System.Threading.Thread.Sleep(10);
            CapturedTime = DateTime.Now;
            System.Threading.Thread.Sleep(10);
            throw new Exception("Deliberate");
        }

        internal void the_time_is_captured(IStep step)
        {
            System.Threading.Thread.Sleep(10);
            CapturedTime = DateTime.Now;
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
            step.ReplaceNameParameters("PageName", PageName.Quote());
            await Task.Run(() => {
                if (PageLoadShouldFail)
                    throw new System.Exception("Page load failed.");
                Response = "Here you go!";
            });
        }
        /// <summary>
        /// Requires: Header - string - Class name to find header.
        /// </summary>
        /// <param name="step"></param>
        public void the_loaded_page_should_have_a_header_of_ExpectedHeader(IStep step)
        {
            step.ReplaceNameParameters("ExpectedHeader", Header.Quote());
        }

        /// <summary>
        /// Requires: Header - string - Class name to find header.
        /// </summary>
        /// <param name="step"></param>
        public async Task the_loaded_page_should_have_a_header_of_ExpectedHeader_async(IStep step)
        {
            step.ReplaceNameParameters("ExpectedHeader", Header.Quote());
            await Task.Run(() => { });
        }
    }
}
