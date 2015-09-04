﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Database
{
    public class Step
    {
        public int Id { get; set; }
        public int ScenarioId { get; set; }
        public virtual Scenario Scenario { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Outcome Outcome { get; set; }
        public string Reason { get; set; }
        public string Exception { get; set; }
    }
}
