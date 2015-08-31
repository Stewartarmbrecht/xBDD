using System;

namespace xBDD
{
    [AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Method)]
    public class StepNameAttribute : Attribute
    {
        public string StepName { get; set; }

        public StepNameAttribute(string stepName)
        {
            this.StepName = stepName;
        }
    }
}