﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using xBDD.Utility;

namespace xBDD.Core
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
            return methodBase.ReflectedType.Name.AddSpacesToSentence(true);
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
            return methodBase.ReflectedType.Namespace;
        }

        public IEnumerable<IAttribute> GetReflectedTypeCustomAttributesData()
        {
            List<IAttribute> attr = new List<IAttribute>();
            methodBase.ReflectedType.GetCustomAttributesData().ToList().ForEach(data =>
            {
                attr.Add(this.factory.CreateAttribute(data));
            });
            return attr;
        }
    }
}
