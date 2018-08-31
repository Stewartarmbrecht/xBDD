using System.Collections.Generic;

namespace xBDD.Reporting.Database.Core
{
    internal class TestRun
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal virtual ICollection<Scenario> TestData { get; set; }
    }
}
