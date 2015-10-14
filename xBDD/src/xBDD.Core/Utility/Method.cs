using System;
using System.Reflection;

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

        internal string GetNameSpace()
        {
            return methodBase.DeclaringType.Namespace.ConvertNamespaceToAreaName();
        }
    }
}
