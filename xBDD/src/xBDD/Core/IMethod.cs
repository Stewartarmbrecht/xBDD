using System.Collections.Generic;

namespace xBDD.Core
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
