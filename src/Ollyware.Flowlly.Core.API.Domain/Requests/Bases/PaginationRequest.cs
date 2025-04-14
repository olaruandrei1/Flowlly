namespace Ollyware.Flowlly.Core.API.Domain.Requests.Bases;

public class PaginationRequest<TFilter>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public TFilter? Filter { get; set; }
}
