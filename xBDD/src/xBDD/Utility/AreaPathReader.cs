using xBDD.Core;

namespace xBDD.Utility
{
    public class AreaPathReader : IAreaPathReader
    {
        public string ReadAreaPath(string name, IMethod method)
        {
            if (name == null)
            {
                name = ReadAttribute(method);
                if (name == null)
                    name = method.GetNameSpace();
            }

            return name;
        }

        string ReadAttribute(IMethod method)
        {
            string name = null;
            foreach (var data in method.GetDeclaringTypeCustomAttributesData())
            {

                if (data.AttributeType == typeof(AreaPathAttribute))
                {
                    var args = data.ConstructorArguments;
                    name = args[0];
                }
            }
            return name;
        }
    }
}
