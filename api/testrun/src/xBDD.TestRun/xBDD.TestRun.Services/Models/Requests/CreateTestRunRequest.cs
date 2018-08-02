namespace xBDD.TestRun.Services.Models.Requests
{
    using System;
    using Newtonsoft.Json;

    public class CreateTestRunRequest
    {
        [JsonProperty("test")]
        public Guid ConfigurationId { get; set; }
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}