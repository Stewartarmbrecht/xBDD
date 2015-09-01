using xBDD.Core;

namespace xBDD.Utility
{
    public class FeatureNameReader : IFeatureNameReader
    {
        public string ReadFeatureName(string name, IMethod method)
        {
            if (name == null)
            {
                name = ReadAttribute(method);
                if (name == null)
                    name = method.GetClassName().AddSpacesToSentence(true);
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
