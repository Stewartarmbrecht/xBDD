using System;
using System.Collections.Generic;
using xBDD.API.Model.Entities;

namespace xBDD.API.Model.Events
{
    public class ScenarioBatchPublishedEvent
    {
        public Guid RowKey { get; set; }
        public List<Scenario> Scenarios { get; set; }
    }
}
