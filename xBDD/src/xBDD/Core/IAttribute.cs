using System;

namespace xBDD.Core
{
    public interface IAttribute
    {
        Type AttributeType { get; }
        string[] ConstructorArguments { get; }
    }
}