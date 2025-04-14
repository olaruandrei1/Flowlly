using Ollyware.Flowlly.Core.API.Domain.Requests.Bases;
using Ollyware.Flowlly.Core.API.Domain.Requests.Filters;

namespace Ollyware.Flowlly.Core.API.Domain.Requests.Tasks;

public class GetAllTasksRequest
{
    public PaginationRequest<TaskFilters> PaginationRequest { get; set; }
}
