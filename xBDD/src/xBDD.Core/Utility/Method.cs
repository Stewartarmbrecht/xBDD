using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace xBDD.Utility
{
    internal class Method
    {
        MethodBase methodBase;
        UtilityFactory factory;

        internal Method(MethodBase methodBase, UtilityFactory factory)
        {
            if (methodBase == null)
                throw new ArgumentNullException("methodBase");
            this.methodBase = methodBase;
            this.factory = factory;
        }

        internal string Name { get { return methodBase.Name; } }

        internal string GetClassName()
        {
            return methodBase.DeclaringType.Name.AddSpacesToSentence(true);
        }
        internal IEnumerable<AttributeWrapper> GetCustomAttributesData()
        {
            List<AttributeWrapper> attr = new List<AttributeWrapper>();
            var attributes = methodBase.GetCustomAttributes().ToList();

            foreach (var ca in attributes)
            {
                attr.Add(this.factory.CreateAttribute(ca));
            }
            return attr;
        }

        internal string GetNameSpace()
        {
            return methodBase.DeclaringType.Namespace;
        }
        internal IEnumerable<TAttribute> GetAttributes<TAttribute>()
            where TAttribute : System.Attribute
        {
            List<TAttribute> attr = new List<TAttribute>();
            methodBase
                .DeclaringType
                .GetTypeInfo()
                .GetCustomAttributes<TAttribute>()
                .ToList();
            return attr;
        }
    }
}
