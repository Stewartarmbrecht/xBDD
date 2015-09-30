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
        
        public override void Dispose()
        {
            base.Dispose();
            Browser.Close();
        }
    }
    [CollectionDefinition("xBDDReportingTest")]
    public class TestRunCollection : ICollectionFixture<xBDDReportingTestTestRunFixture>
    {

    }
}
