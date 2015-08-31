using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public interface IArea
    {
        string Name { get; set; }
        IArea Parent { get; set; }
        List<IArea> Areas { get; set; }

        List<IFeature> Features { get; set; }
    }
}
