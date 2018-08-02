using Newtonsoft.Json;

namespace xBDD.TestRun.Services.Models.Requests
{
    public class UpdateTestRunRequest
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("text")]
        public string TestRun;
    }
}