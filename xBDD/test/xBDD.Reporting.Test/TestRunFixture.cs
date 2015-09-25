using xBDD.Test;
using Xunit;

namespace xBDD.Reporting.Test
{
    public class xBDDReportingTestTestRunFixture : TestRunFixture
    {
        public xBDDReportingTestTestRunFixture()
            : base("xBDD.Reporting.Test")
        {

        }
    }
    [CollectionDefinition("xBDDReportingTest")]
    public class TestRunCollection : ICollectionFixture<xBDDReportingTestTestRunFixture>
    {

    }
}
