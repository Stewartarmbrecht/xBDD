using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using xBDD.API.Model.Entities;
using xBDD.API.Model.Messages;

namespace xBDD.Reporting.Service.Core
{
    public class TestRunPayloadSaver
    {
        string url;
        PayloadFactory factory;
        public TestRunPayloadSaver(PayloadFactory factory, string url)
        {
            this.factory = factory;
            this.url = url;
        }
        public async Task<int> SaveTestRun(xBDD.Model.TestRun testRun)
        {
            PayloadObjectBuilder payloadObjectBuilder = factory.CreatePayloadObjectBuilder();
            TestRun testRunPayload = payloadObjectBuilder.BuildTestRun(testRun);
            List<Scenario> scenarios = payloadObjectBuilder.BuildScenarios(testRun, testRunPayload);
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "xBDD Test Results Publisher");

            PublishTestRunRequest testRunReq = new PublishTestRunRequest()
            {
                TestRun = testRunPayload
            };

            var testRunJson = JsonConvert.SerializeObject(testRunReq);
            StringContent testRunContent = new StringContent(testRunJson, System.Text.Encoding.UTF8, "application/json");
            var count = testRun.Scenarios.Count;
            var testRunResponse = await client.PostAsync(url + "testrun", testRunContent);
            if(testRunResponse.IsSuccessStatusCode)
            {
                PublishScenarioBatchRequest scenariosReq = new PublishScenarioBatchRequest()
                {
                    Scenarios = scenarios
                };

                var scenariosJson = JsonConvert.SerializeObject(scenariosReq);
                StringContent scenariosContent = new StringContent(scenariosJson, System.Text.Encoding.UTF8, "application/json");
                var scenariosResponse = await client.PostAsync(url + "scenario", scenariosContent);
                if(scenariosResponse.IsSuccessStatusCode)
                {
                    System.Diagnostics.Trace.WriteLine("There were " + count + " scenarios written to the xBDD Publish service listening on '" + url + "'.");
                }
                else 
                {
                    var message = await scenariosResponse.Content.ReadAsStringAsync();
                    System.Diagnostics.Trace.WriteLine(message);
                }
            }
            else 
            {
                var message = await testRunResponse.Content.ReadAsStringAsync();
                System.Diagnostics.Trace.WriteLine(message);
            }

            return count;
        }
    }
}
