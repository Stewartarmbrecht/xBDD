using System;
using System.Linq;
using System.Reflection;

namespace xBDD.Utility
{
    internal class AttributeWrapper
    {
        Attribute cad;
        internal AttributeWrapper(Attribute customAttributeData)
        {
            cad = customAttributeData;
        }
        internal Type AttributeType
        {
            get
            {
                return cad.GetType();
            }
        }
    }
}
