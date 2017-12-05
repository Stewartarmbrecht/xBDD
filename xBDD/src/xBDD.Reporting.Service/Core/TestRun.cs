using System;
using System.Collections.Generic;

namespace xBDD.Reporting.Service.Core
{
    public class TestRun
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Scenario> Scenarios = new List<Scenario>();

    }
}
