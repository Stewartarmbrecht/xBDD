using System;

namespace xBDD.API.Model.Entities
{
    public class Step
    {
        public string PartitionKey { get; set; }
        public string RowKey { get { return Id.ToString(); } }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ActionType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Outcome Outcome { get; set; }
        public string Reason { get; set; }
        public string Exception { get; set; }
        public string MultilineParameter { get; set; }
    }
}
