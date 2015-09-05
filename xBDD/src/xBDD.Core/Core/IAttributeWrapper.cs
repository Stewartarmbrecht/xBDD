using System;

namespace xBDD.Core
{
    public interface IAttributeWrapper
    {
        Type AttributeType { get; }
        string[] ConstructorArguments { get; }
    }
}