﻿using System.Collections.Generic;

namespace xBDD.Database.Core
{
    public class TestRun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Scenario> TestData { get; set; }
    }
}
