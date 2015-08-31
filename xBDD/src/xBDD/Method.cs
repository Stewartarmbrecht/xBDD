using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace xBDD
{
    public class Method : IMethod
    {
        MethodBase methodBase;
        IFactory factory;
        public Method(MethodBase methodBase, IFactory factory)
        {
            this.methodBase = methodBase;
            this.factory = factory;
        }
        public string Name { get { return methodBase.Name; } }

        public string GetClassName()
        {
            return methodBase.DeclaringType.Name.AddSpacesToSentence(true);
        }

        public IEnumerable<IAttribute> GetCustomAttributesData()
        {
            List<IAttribute> attr = new List<IAttribute>();
            methodBase.GetCustomAttributesData().ToList().ForEach(data =>
            {
                attr.Add(this.factory.CreateAttribute(data));
            });
            return attr;
        }

        public string GetNameSpace()
        {
            return methodBase.DeclaringType.Namespace;
        }

        public IEnumerable<IAttribute> GetDeclaringTypeCustomAttributesData()
        {
            List<IAttribute> attr = new List<IAttribute>();
            methodBase.DeclaringType.GetCustomAttributesData().ToList().ForEach(data =>
            {
                attr.Add(this.factory.CreateAttribute(data));
            });
            return attr;
        }
    }
}
