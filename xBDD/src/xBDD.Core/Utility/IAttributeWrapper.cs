using System;

namespace xBDD.Utility
{
    public interface IAttributeWrapper
    {
        Type AttributeType { get; }
        string[] ConstructorArguments { get; }
    }
}