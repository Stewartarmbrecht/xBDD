using Newtonsoft.Json;

namespace xBDD.TestRun.Services.Models.Responses
{
    public class TestRunSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }
    }
}