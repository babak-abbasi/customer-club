namespace Helper.Pagination;

public class ResponsePagination<T>
{
    public List<T>? Data { get; set; } = new();

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int CurrentSize { get; set; }
    public long TotalCount { get; set; }

    public bool HasPreviuos { get; set; }
    public bool HasNext { get; set; }
}
