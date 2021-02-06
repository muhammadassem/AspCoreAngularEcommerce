using Core.Extensions;

namespace Core.Entities
{
    public class ProductQuery : IQueryObject
    {
        public string Name { get; set; }
        public bool IsAscending { get; set; }
        public string SortBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}