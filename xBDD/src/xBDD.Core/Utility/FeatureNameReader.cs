namespace xBDD.Utility
{
    internal class FeatureNameReader
    {
        internal string ReadFeatureName(string name, Method method)
        {
            if (name == null)
            {
                name = ReadAttribute(method);
                if (name == null)
                    name = method.GetClassName().AddSpacesToSentence(true);
            }

            return name;
        }

        string ReadAttribute(Method method)
        {
            string name = null;
            foreach (var data in method.GetAttributes<FeatureNameAttribute>())
            {
                name = data.Name;
            }
            return name;
        }
    }
}
