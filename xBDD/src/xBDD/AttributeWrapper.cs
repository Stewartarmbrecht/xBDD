using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace xBDD
{
    public class AttributeWrapper : IAttribute
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
