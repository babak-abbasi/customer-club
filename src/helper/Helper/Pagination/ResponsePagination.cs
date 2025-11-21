namespace Helper.Pagination;

public abstract class ResponsePagination
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int CurrentSize { get; set; }
    public int TotalCount { get; set; }

    public bool HasPreviuos { get; set; }
    public bool HasNext { get; set; }
}
