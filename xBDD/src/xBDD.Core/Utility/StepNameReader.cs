using System.Collections.Generic;

namespace xBDD.Utility
{
    internal class StepNameReader
    {
        internal string ReadStepName(Method method)
        {
            var name = ReadAttribute(method);
            if (name == null)
            {
                name = method.Name.ReplaceUnderscores();
            }
            return name;
        }

        string ReadAttribute(Method method)
        {
            string name = null;
            foreach (var data in method.GetAttributes<StepNameAttribute>())
            {
                name = data.Name;
            }
            return name;
        }
    }
}
