using xBDD.Core;

namespace xBDD.Utility
{
    public class StepNameReader : IStepNameReader
    {
        public string ReadStepName(string name, IMethod method)
        {
            if (name == null & !method.Name.StartsWith("<"))
            {
                name = ReadAttribute(method);
                if (name == null)
                    name = method.Name.AddSpacesToSentence(true);
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
