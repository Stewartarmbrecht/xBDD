using System;
using System.Collections.Generic;

namespace xBDD.API.Model.Entities
{
    public class TestRun
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Scenario> Scenarios = new List<Scenario>();

    }
}
