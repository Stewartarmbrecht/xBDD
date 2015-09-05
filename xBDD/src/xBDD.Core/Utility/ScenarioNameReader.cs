using xBDD.Core;

namespace xBDD.Utility
{
    public class ScenarioNameReader : IScenarioNameReader
    {
        public string ReadScenarioName(string scenarioName, IMethod method)
        {
            if (scenarioName == null)
            {
                scenarioName = ReadAttribute(method);
                if (scenarioName == null)
                    scenarioName = method.Name.AddSpacesToSentence(true);
            }

            return scenarioName;
        }

        string ReadAttribute(IMethod method)
        {
            string name = null;
            foreach (var data in method.GetCustomAttributesData())
            { 
            
                if (data.AttributeType == typeof(ScenarioNameAttribute))
                {
                    var args = data.ConstructorArguments;
                    name = args[0];
                }
            }
            return name;
        }
    }
}
