using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace xBDD.Utility
{
    public class Method : IMethod
    {
        MethodBase methodBase;
        IUtilityFactory factory;

        public Method(MethodBase methodBase, IUtilityFactory factory)
        {
            this.methodBase = methodBase;
            this.factory = factory;
        }

        public string Name { get { return methodBase.Name; } }

        public string GetClassName()
        {
            return methodBase.ReflectedType.Name.AddSpacesToSentence(true);
        }
        public IEnumerable<IAttributeWrapper> GetCustomAttributesData()
        {
            List<IAttributeWrapper> attr = new List<IAttributeWrapper>();
            methodBase.GetCustomAttributesData().ToList().ForEach(data =>
            {
                attr.Add(this.factory.CreateAttribute(data));
            });
            return attr;
        }
        public string GetNameSpace()
        {
            return methodBase.ReflectedType.Namespace;
        }
        public IEnumerable<IAttributeWrapper> GetReflectedTypeCustomAttributesData()
        {
            List<IAttributeWrapper> attr = new List<IAttributeWrapper>();
            methodBase.ReflectedType.GetCustomAttributesData().ToList().ForEach(data =>
            {
                attr.Add(this.factory.CreateAttribute(data));
            });
            return attr;
        }
    }
}
