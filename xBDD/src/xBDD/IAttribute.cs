using System;

namespace xBDD
{
    public interface IAttribute
    {
        Type AttributeType { get; }
        string[] ConstructorArguments { get; }
    }
}