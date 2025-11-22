namespace Helper.Pagination;

public abstract class RequestPagination
{
    int _pagenumber = 1;
    public int PageNumber 
    {
        get => _pagenumber;
        set
        {
            if (value <= 0)
                _pagenumber = 1;
            else _pagenumber = value;
        } 
    }
    int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (value <= 0)
                _pageSize = 10;
            else _pageSize = value;
        }
    }
}
