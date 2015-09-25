using xBDD.Test;
using Xunit;

namespace xBDD.Reporting.Database.Test
{
    public class xBDDReportingDatabaseTestTestRunFixture : TestRunFixture
    {
        public xBDDReportingDatabaseTestTestRunFixture()
            : base("xBDD.Reporting.Database.Test")
        {

        }
    }
    [CollectionDefinition("xBDDReportingDatabaseTest")]
    public class TestRunCollection : ICollectionFixture<xBDDReportingDatabaseTestTestRunFixture>
    {

    }
}



