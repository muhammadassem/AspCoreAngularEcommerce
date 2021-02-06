namespace Core.Extensions
{
    public interface IQueryObject
    {
        string Name { get; set; }
        bool IsAscending { get; set; }
        string SortBy { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
    }
}