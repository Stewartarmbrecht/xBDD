using System;

namespace xBDD
{
    [AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Method)]
    public class FeatureNameAttribute : Attribute
    {
        public string Name { get; set; }

        public FeatureNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}