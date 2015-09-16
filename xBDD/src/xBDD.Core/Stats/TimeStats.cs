using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Stats
{
    internal class TimeStats
    {
        internal DateTime StartTime { get; set; }
        internal DateTime EndTime { get; set; }
        internal TimeSpan Duration { get; }
        internal TimeSpan Time { get; set; }
    }
}
