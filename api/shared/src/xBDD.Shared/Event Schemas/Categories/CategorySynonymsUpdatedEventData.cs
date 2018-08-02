using System.Collections.Generic;

namespace xBDD.Shared.EventSchemas.Categories
{
    public class CategorySynonymsUpdatedEventData
    {
        public string Name { get; set; }
        public IEnumerable<string> Synonyms { get; set; }
    }
}