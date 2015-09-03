using Xunit;
using Xunit.Sdk;

namespace xBDD
{
    [XunitTestCaseDiscoverer("xBDD.Core.ScenarioFactDiscoverer", "xBDD")]
    public class ScenarioFactAttribute : FactAttribute { }
}
