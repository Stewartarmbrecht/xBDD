using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public interface IMethod
    {
        string Name { get; }

        IEnumerable<IAttribute> GetCustomAttributesData();
        IEnumerable<IAttribute> GetDeclaringTypeCustomAttributesData();
        string GetClassName();
        string GetNameSpace();
    }
}
