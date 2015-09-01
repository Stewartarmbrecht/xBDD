using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Stats
{
    public interface IFeature
    {
        string Name { get; set; }
        IArea Area { get; set; }
        List<IScenario> Scenarios { get; set; }
    }
}
