using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace xBDD
{
    public class FeatureNameReader : IFeatureNameReader
    {
        public string ReadFeatureName(IMethod method)
        {
            var name = ReadAttribute(method);
            if(name == null)
            {
                name = method.GetClassName();
            }
            return name;
        }

        string ReadAttribute(IMethod method)
        {
            string name = null;
            foreach (var data in method.GetDeclaringTypeCustomAttributesData())
            { 
            
                if (data.AttributeType == typeof(FeatureNameAttribute))
                {
                    var args = data.ConstructorArguments;
                    name = args[0];
                }
            }
            return name;
        }
    }
}
