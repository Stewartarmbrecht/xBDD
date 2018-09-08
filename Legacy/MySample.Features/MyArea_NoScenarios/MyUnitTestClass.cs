
namespace MySample.Features.MyArea_NoScenarios
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    public class MyUnitTestClass
    {

        [TestMethod]
        public async Task MyScenario_0_Unsorted()
        {
            await Task.Run(() => {});
        }
    }
}

