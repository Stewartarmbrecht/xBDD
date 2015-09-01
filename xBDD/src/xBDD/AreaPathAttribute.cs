using System;

namespace xBDD
{
    [AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Method)]
    public class AreaPathAttribute : Attribute
    {
        public string Path { get; set; }

        public AreaPathAttribute(string path)
        {
            this.Path = path;
        }
    }
}