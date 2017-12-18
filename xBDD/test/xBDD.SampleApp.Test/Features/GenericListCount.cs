using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using xBDD;

namespace xBDD.SampleApp.Test.Features.HomePage
{
    [InOrderTo("know how many items are in a List<T>")]
    [AsA("Developer")]
    [IWouldLikeTo("use a Count property on the list object.")]
    [TestClass]
    public class GenericListCount
    {
        [TestMethod]
        public async Task CallWhenPopulated()
        {
            List<string> list = new List<string>();
            int? count = -1;
            await xB.CurrentRun
                .AddScenario(this)
                .Given("A generic list of type string with two string in it", (s) => {
                    list.Add("String 1");
                    //list.Add("String 2");
                })
                .When("I call the Count property", (s) => {
                    count = list.Count;
                })
                .Then("the return value should be 2;", (s) => {
                    Assert.AreEqual(2, count);
                })
                .Run();
        }
    }
}
