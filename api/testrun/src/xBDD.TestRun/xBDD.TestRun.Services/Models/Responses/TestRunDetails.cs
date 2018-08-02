using Newtonsoft.Json;

namespace xBDD.TestRun.Services.Models.Responses
{
    public class TestRunDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string TestRun { get; set; }
    }
}
