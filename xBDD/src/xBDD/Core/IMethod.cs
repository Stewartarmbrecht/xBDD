using System.Collections.Generic;

namespace xBDD.Core
{
    public interface IMethod
    {
        string Name { get; }

        IEnumerable<IAttribute> GetCustomAttributesData();
        IEnumerable<IAttribute> GetReflectedTypeCustomAttributesData();
        string GetClassName();
        string GetNameSpace();
    }
}
