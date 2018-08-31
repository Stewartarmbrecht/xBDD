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
		string scenarioExplanation;
		string featureExplanation;

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
        /// <param name="scenarioExplanation">Markdown that provides an explanation for the features area.</param>
        /// <param name="featureExplanation">Markdown that provides an explanation for the feature.</param>
        public CodeDetails(
			string namespaceName, 
			string className, 
			string methodName, 
			string asAAttribute, 
			string youCanAttribute, 
			string byAttribute,
			string scenarioExplanation,
			string featureExplanation) {
            this.namespaceName = namespaceName;
            this.className = className;
            this.methodName = methodName;
            this.asAAttribute = asAAttribute;
            this.youCanAttribute = youCanAttribute;
            this.byAttribute = byAttribute;
			this.scenarioExplanation = scenarioExplanation;
			this.featureExplanation = featureExplanation;
        }

        internal string Name { get { 
            string text = null;
            if(this.methodName != null) {
                text = this.methodName;
            } else if(methodBase != null) {
                text = methodBase.Name; 
            }
            return text;
        } }

        internal string GetClassName()
        {
            string text = null;
            if(this.className != null) {
                text = this.className.AddSpacesToSentence();
            } else if(methodBase != null) {
                text = methodBase.DeclaringType.Name.AddSpacesToSentence();
            }
            return text;
        }

        internal string GetFullClassName()
        {
            string text = null;
            if(this.namespaceName != null && this.className != null) {
                text = $"{this.namespaceName}.{this.className}"; 
            } else {
                text = methodBase.DeclaringType.FullName;
            }
            return text;
        }

        internal string GetFeatureActorAction()
        {
            string text = null;
            if(this.byAttribute != null) {
                text = this.byAttribute;
            } else if(methodBase != null){
                var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<ByAttribute>();
                if(attr != null)
                    text = attr.GetCapabilityStatement();
				if(text == null) {
	                var gattr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<Generated_ByAttribute>();
					if(gattr != null)
						text = gattr.GetCapabilityStatement();
				}
            }
            return text;
        }

        internal string GetFeatureActorValue()
        {
            string text = null;
            if(this.youCanAttribute != null) {
                text = this.youCanAttribute;
            } else if(methodBase != null){
                var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<YouCanAttribute>();
                if(attr != null)
                    text = attr.GetBenefitStatement();
				if(text == null) {
	                var gattr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<Generated_YouCanAttribute>();
					if(gattr != null)
						text = gattr.GetBenefitStatement();
				}
            }
            return text;
        }

        internal string GetFeatureActorName()
        {
            string text = null;
            if(this.asAAttribute != null) {
                text = this.asAAttribute;
            } else if(methodBase != null){
                var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<AsAAttribute>();
                if(attr != null)
                    text = attr.GetName();
				if(text == null) {
	                var gattr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<Generated_AsAAttribute>();
					if(gattr != null)
						text = gattr.GetName();
				}
            }
            return text;
        }

        internal string GetFeatureExplanation()
        {
            string text = null;
            if(this.featureExplanation != null) {
                text = this.featureExplanation;
            } else if(methodBase != null){
                var attr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<ExplanationAttribute>();
                if(attr != null)
                    text = attr.GetExplanation();
				if(text == null) {
	                var gattr = methodBase.DeclaringType.GetTypeInfo().GetCustomAttribute<Generated_ExplanationAttribute>();
					if(gattr != null)
						text = gattr.GetExplanation();
				}
            }
            return text;
        }

        internal string GetScenarioExplanation()
        {
            string text = null;
            if(this.scenarioExplanation != null) {
                text = this.scenarioExplanation;
            } else if(methodBase != null){
                var attr = methodBase.GetCustomAttribute<ExplanationAttribute>();
                if(attr != null)
                    text = attr.GetExplanation();
				if(text == null) {
	                var gattr = methodBase.GetCustomAttribute<Generated_ExplanationAttribute>();
					if(gattr != null)
						text = gattr.GetExplanation();
				}
            }
            return text;
        }

        internal string GetNameSpace()
        {
            string text = null;
            if(this.namespaceName != null) {
                text = this.namespaceName.ConvertNamespaceToAreaName();            
            } else if(methodBase != null){
                text = methodBase.DeclaringType.Namespace.ConvertNamespaceToAreaName();
            }
            return text;
        }
    }
}
