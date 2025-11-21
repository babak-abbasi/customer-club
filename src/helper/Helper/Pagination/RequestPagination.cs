namespace Helper.Pagination;

public abstract class RequestPagination
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
