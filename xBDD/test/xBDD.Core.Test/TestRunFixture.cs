using xBDD.Test;
using Xunit;

namespace xBDD.Core.Test
{
    public class xBDDCoreTestTestRunFixture : TestRunFixture
    {
        public xBDDCoreTestTestRunFixture()
            : base("xBDD.Core.Test")
        {

        }
    }
    [CollectionDefinition("xBDDCoreTest")]
    public class TestRunCollection : ICollectionFixture<xBDDCoreTestTestRunFixture>
    {

    }
}
