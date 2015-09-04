using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Database
{
    public class Scenario
    {
        public int Id { get; set; }
        public int TestRunId { get; set; }
        public virtual TestRun TestRun { get; set; }
        public string Name { get; set; }
        public string FeatureName { get; set; }
        public string AreaPath { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}
