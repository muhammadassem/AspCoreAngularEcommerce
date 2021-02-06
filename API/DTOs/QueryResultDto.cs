using System.Collections.Generic;

namespace API.DTOs
{
    public class QueryResultDto<T>
    {
        public int TotalRecords { get; set; }
        public List<T> Items { get; set; }
    }
}
