namespace xBDD.Utility
{
    internal class AreaPathReader
    {
        internal string ReadAreaPath(string name, Method method)
        {
            if (name == null)
            {
                name = ReadAttribute(method);
                if (name == null)
                    name = method.GetNameSpace();
            }

            return name;
        }

        string ReadAttribute(Method method)
        {
            string name = null;
            foreach (var data in method.GetAttributes<AreaPathAttribute>())
            {
                name = data.Path;
            }
            return name;
        }
    }
}
