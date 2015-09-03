using Xunit;
using Xunit.Sdk;

namespace xBDD
{
    [XunitTestCaseDiscoverer("xBDD.Core.ScenarioTheoryDiscoverer", "xBDD")]
    public class ScenarioTheoryAttribute : TheoryAttribute { }
}
