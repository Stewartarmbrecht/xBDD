namespace MySample.Features.TestRun4SkippedReady
{
    using System;
    using System.Collections.Generic;
    public class ReasonSort
    {
        public List<string> SortedReasons { get; private set; }

        public ReasonSort()
        {
            this.SortedReasons = new List<string>() {
                "Untested",
                "Building",
                "Ready",
                "Defining"
            };
        }
    }
}