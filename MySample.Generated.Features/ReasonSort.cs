namespace MySample.Generated.Features
{
    using System;
    using System.Collections.Generic;
    public class ReasonSort
    {
        public List<string> SortedReasons { get; private set; }

        public ReasonSort()
        {
            this.SortedReasons = new List<string>() {
                "Removing",
                "Building",
                "Untested",
                "Ready",
                "Defining"
            };
        }
    }
}