using System;
using System.Reflection;

namespace xBDD.Utility
{
    /// <summary>
    /// Provides details about the code for xBDD
    /// to use in constructing a scenario.
    /// </summary>
    public class CodeDetails
    {
        MethodBase methodBase;
        UtilityFactory factory;
        string namespaceName;
        string className;
        string methodName;
        string asAAttribute;
        string youCanAttribute;
        string byAttribute;

        internal CodeDetails(MethodBase methodBase, UtilityFactory factory)
        {
            if (methodBase == null)
                throw new ArgumentNullException("methodBase");
            this.methodBase = methodBase;
            this.factory = factory;
        }

        /// <summary>
        /// Creates a code details object.
        /// </summary>
        /// <param name="namespaceName">The namespace for the feature class.</param>
        /// <param name="className">The class name for the feature.</param>
        /// <param name="methodName">The method name for the scenario that is called by the testing framework.</param>
        /// <param name="asAAttribute">The value of the As A attribute on the feature.</param>
        /// <param name="youCanAttribute">The value of the You Can attribute on the feature.</param>
        /// <param name="byAttribute">The value of the By attribute on the feature.</param>
        public CodeDetails(string namespaceName, string className, string methodName, string asAAttribute, string youCanAttribute, string byAttribute) {
            this.namespaceName = namespaceName;
            this.className = className;
            this.methodName = methodName;
            this.asAAttribute = asAAttribute;
            this.youCanAttribute = youCanAttribute;
            this.byAttribute = byAttribute;
        }

        internal string Name { get { 
            if(this.methodName != null) {
                return this.methodName;
            } else {
                return methodBase.Name; 
            }
        } }

        internal string GetClassName()
        {
            if(this.className != null) {
                return this.className.AddSpacesToSentence();
            } else {
                return methodBase.DeclaringType.Name.AddSpacesToSentence();
            }
        }

        internal string GetFullClassName()
        {
            if(this.namespaceName != null && this.className != null) {
                return $"{this.namespaceName}.{this.className}"; 
            } else {
                return methodBase.DeclaringType.FullName;
            }
        }

        internal string GetFeatureActorAction()
        {
            string text = null;
            if(this.byAttribute != null) {
                text = this.byAttribute;
            } else {
                var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<ByAttribute>();
                if(attr != null)
                    text = attr.GetCapabilityStatement();
            }
            return text;
        }

        internal string GetFeatureActorValue()
        {
            string text = null;
            if(this.youCanAttribute != null) {
                text = this.youCanAttribute;
            } else {
                var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<YouCanAttribute>();
                if(attr != null)
                    text = attr.GetBenefitStatement();
            }
            return text;
        }

        internal string GetFeatureActorName()
        {
            string text = null;
            if(this.asAAttribute != null) {
                text = this.asAAttribute;
            } else {
                var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<AsAAttribute>();
                if(attr != null)
                    text = attr.GetName();
            }
            return text;
        }

        internal string GetNameSpace()
        {
            if(this.namespaceName != null) {
                return this.namespaceName;            
            } else {
                return methodBase.DeclaringType.Namespace.ConvertNamespaceToAreaName();
            }
        }
    }
}
