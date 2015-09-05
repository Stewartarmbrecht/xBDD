using System;

namespace xBDD
{
    [AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Method)]
    public class StepNameAttribute : Attribute
    {
        public string Name { get; set; }

        public StepNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}