using Newtonsoft.Json;

namespace xBDD.TestRun.Services.Models.Data
{
    public class TestRunDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("text")]
        public string TestRun { get; set; }

        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }
    }
}
