using System;
using System.Linq;
using System.Reflection;
using xBDD.Core;

namespace xBDD.Core
{
    public class AttributeWrapper : IAttributeWrapper
    {
        CustomAttributeData cad;
        public AttributeWrapper(CustomAttributeData customAttributeData)
        {
            cad = customAttributeData;
        }
        public Type AttributeType
        {
            get
            {
                return cad.AttributeType;
            }
        }

        public string[] ConstructorArguments
        {
            get
            {
                return cad.ConstructorArguments.Select(x => x.Value.ToString()).ToArray<string>();
            }
        }
    }
}
