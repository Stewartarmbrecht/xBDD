using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace xBDD.API.Model.Entities
{
    public class TestRun : TableEntity 
    {
        public Guid ConfigurationId { get; set; }
        public Guid Id { get; set; }
        public string Number { get; set; }
    }
}
