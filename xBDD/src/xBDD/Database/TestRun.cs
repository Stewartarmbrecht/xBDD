using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Database
{
    public class TestRun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Scenario> TestData { get; set; }
    }
}
