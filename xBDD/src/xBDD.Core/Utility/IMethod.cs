﻿using System.Collections.Generic;

namespace xBDD.Utility
{
    public interface IMethod
    {
        string Name { get; }

        IEnumerable<IAttributeWrapper> GetCustomAttributesData();
        IEnumerable<IAttributeWrapper> GetReflectedTypeCustomAttributesData();
        string GetClassName();
        string GetNameSpace();
    }
}
