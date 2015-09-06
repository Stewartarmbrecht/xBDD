using System.Collections.Generic;

namespace xBDD.Utility
{
    public class StepNameReader : IStepNameReader
    {
        public string ReadStepName(IStep step, string name, IMethod method)
        {
            if (name == null & !method.Name.StartsWith("<"))
            {
                name = ReadAttribute(method);
                if (name == null)
                {
                    name = method.Name.ReplaceUnderscores();
                }
            }
            return name;
        }

        public string ReadStepNameWithReplacement(IStep step, string stepName, IMethod method, Dictionary<string, string> replacements)
        {
            string name = ReadStepName(step, stepName, method);
            foreach(var pair in replacements)
            {
                //if the name came from the method name then it was cast to lower case and the key should be as well.
                var key = (stepName == null ? pair.Key.ReplaceUnderscores() : pair.Key);

                name = name.Replace(key, pair.Value);
            }
            return name;
        }

        string ReadAttribute(IMethod method)
        {
            string name = null;
            foreach (var data in method.GetCustomAttributesData())
            { 
            
                if (data.AttributeType == typeof(StepNameAttribute))
                {
                    var args = data.ConstructorArguments;
                    name = args[0];
                }
            }
            return name;
        }
    }
}
