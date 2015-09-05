using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Stats
{
    public interface ITimeStats
    {
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        TimeSpan Duration { get; }
        TimeSpan Time { get; set; }
    }
}
