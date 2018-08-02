using System;
using System.Collections.Generic;
using xBDD.API.Model.Entities;

namespace xBDD.API.Model.Messages
{
    public class PublishScenarioBatchRequest
    {
        public List<Scenario> Scenarios { get; set; }
    }
}
