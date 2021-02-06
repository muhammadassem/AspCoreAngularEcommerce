namespace API.DTOs
{
    public class ProductQueryDto
    {
        public string Name { get; set; }
        public bool IsAscending { get; set; }
        public string SortBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}