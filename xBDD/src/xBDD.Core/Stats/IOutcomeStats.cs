using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Stats
{
    public interface IOutcomeStats
    {
        int Total { get; set; }
        int Passed { get; set; }
        int Failed { get; set; }
    }
}
