using System.Reflection;

namespace xBDD.Utility
{
    internal class MethodRetriever
    {
        UtilityFactory factory;
        internal MethodRetriever(UtilityFactory factory)
        {
            this.factory = factory;
        }

        internal Method GetScenarioMethod(object featureClass, string methodName)
        {

            var method = featureClass.GetType().GetTypeInfo().GetDeclaredMethod(methodName);
            if (method == null)
                throw new StepMethodNotFoundException();
            return factory.CreateMethod(method);

        }
    }
}
