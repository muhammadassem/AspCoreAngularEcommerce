using System.Collections.Generic;

namespace Core.Entities
{
    public class QueryResult<T>
    {
        public int TotalRecords { get; set; }
        public List<T> Items { get; set; }
    }
}
