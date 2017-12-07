using System;
using System.Collections.Generic;

namespace xBDD.API.Model.Entities
{
    public class TestRun
    {
        public string PartitionKey { get { return ConfigurationId.ToString(); } }
        public string RowKey { get { return Id.ToString(); } }
        public Guid ConfigurationId { get; set; }
        public Guid Id { get; set; }
        public string Number { get; set; }
    }
}
