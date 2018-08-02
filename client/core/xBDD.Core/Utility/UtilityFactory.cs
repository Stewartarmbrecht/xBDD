using System.Reflection;
using xBDD.Core;

namespace xBDD.Utility
{
    internal class UtilityFactory
    {
        internal MethodRetriever GetMethodRetriever()
        {
            return new MethodRetriever(this);
        }

        internal Method CreateMethod(MethodBase methodBase)
        {
            return new Method(methodBase, this);
        }

        internal OutcomeAggregator CreateOutcomeAggregator()
        {
            return new OutcomeAggregator();
        }

        internal StatsCascader CreateStatsCascader()
        {
            return new StatsCascader(this);
        }
    }
}
