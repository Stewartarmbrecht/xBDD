using Xunit;
using Xunit.Sdk;

namespace xBDD
{
    [XunitTestCaseDiscoverer("xBDD.xUnit.ScenarioTheoryDiscoverer", "xBDD.xUnit")]
    public class ScenarioTheoryAttribute : TheoryAttribute { }
}
