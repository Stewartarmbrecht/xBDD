using Xunit;
using Xunit.Sdk;

namespace xBDD
{
    [XunitTestCaseDiscoverer("xBDD.xUnit.ScenarioFactDiscoverer", "xBDD.xUnit")]
    public class ScenarioFactAttribute : FactAttribute { }
}
