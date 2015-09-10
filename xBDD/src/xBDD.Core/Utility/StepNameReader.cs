using System.Collections.Generic;

namespace xBDD.Utility
{
    public class StepNameReader : IStepNameReader
    {
        public string ReadStepName(IMethod method)
        {
            var name = ReadAttribute(method);
            if (name == null)
            {
                name = method.Name.ReplaceUnderscores();
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
