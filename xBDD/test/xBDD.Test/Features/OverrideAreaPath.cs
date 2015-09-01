﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Stories
{
    [AreaPath("My.Custom.Path")]
    public class OverrideAreaPath
    {
        [Fact]
        public void WithAreaPathAttribute()
        {
            var scenario = xBDD.CurrentRun.AddScenario();
            Assert.Equal("My.Custom.Path", scenario.AreaPath);
        }
        [Fact]
        public void WhenAddingScenario()
        {
            var areaPath = "Custom.Area";
            var scenario = xBDD.CurrentRun.AddScenario(null, null, areaPath);
            Assert.Equal(areaPath, scenario.AreaPath);
        }
    }
}
