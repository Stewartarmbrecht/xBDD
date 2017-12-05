using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

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
            var count = 0;
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "xBDD Test Results Publisher");

            var json = JsonConvert.SerializeObject(testRunPayload);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var postTask = client.PostAsync(url, content);

            var response = await postTask;
            if(response.IsSuccessStatusCode)
            {
                System.Diagnostics.Trace.WriteLine("There were " + testRunPayload.Scenarios.Count + " scenarios written to the xBDD Publish service listening on '" + url + "'.");
            }
            else 
            {
                var message = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Trace.WriteLine(message);
            }


            return count;
        }
    }
}
