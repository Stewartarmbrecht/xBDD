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
            return methodBase.DeclaringType.Name.AddSpacesToSentence();
        }

        internal string GetFullClassName()
        {
            return methodBase.DeclaringType.FullName;
        }

        internal string GetFeatureActorAction()
        {
            string text = null;
            var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<ByAttribute>();
            if(attr != null)
                text = attr.GetCapabilityStatement();
            return text;
        }

        internal string GetFeatureActorValue()
        {
            string text = null;
            var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<YouCanAttribute>();
            if(attr != null)
                text = attr.GetBenefitStatement();
            return text;
        }

        internal string GetFeatureActorName()
        {
            string text = null;
            var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<AsAAttribute>();
            if(attr != null)
                text = attr.GetName();
            return text;
        }

        internal string GetNameSpace()
        {
            return methodBase.DeclaringType.Namespace.ConvertNamespaceToAreaName();
        }
    }
}
