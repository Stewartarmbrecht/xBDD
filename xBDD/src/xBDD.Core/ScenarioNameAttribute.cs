using System;

namespace xBDD
{
    [AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Method)]
    public class ScenarioNameAttribute : Attribute
    {
        public string Name { get; set; }

        public ScenarioNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}