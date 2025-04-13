namespace Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

public class PaginationResult<T>
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int TotalItems { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
