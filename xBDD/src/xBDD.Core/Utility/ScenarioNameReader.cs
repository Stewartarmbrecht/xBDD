namespace xBDD.Utility
{
    internal class ScenarioNameReader
    {
        internal string ReadScenarioName(string scenarioName, Method method)
        {
            if (scenarioName == null)
            {
                scenarioName = ReadAttribute(method);
                if (scenarioName == null)
                    scenarioName = method.Name.AddSpacesToSentence(true);
            }

            return scenarioName;
        }

        string ReadAttribute(Method method)
        {
            string name = null;
            foreach (var data in method.GetAttributes<ScenarioNameAttribute>())
            {
                name = data.Name;
            }
            return name;
        }
    }
}
