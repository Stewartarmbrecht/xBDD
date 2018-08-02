using System;
using xBDD.API.Model.Entities;

namespace xBDD.API.Model.Messages
{
    public class GetTestRunsRequest
    {
        public Guid ConfigurationId { get; set; }
    }
}
