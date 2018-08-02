using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace xBDD.API.Model.Entities
{
    public class Scenario : TableEntity
    {
        public Guid TestRunId { get; set; }
        public Guid Id { get; set; }
        public string AreaPath { get; set; }
        public string FeatureName { get; set; }
        public string Name { get; set; }
        public Outcome Outcome { get; set; }
        public string Reason { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Step> Steps = new List<Step>();
    }
}
