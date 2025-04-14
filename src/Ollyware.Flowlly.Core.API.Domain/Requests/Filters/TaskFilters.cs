using Ollyware.Flowlly.Core.API.Domain.Constants;

namespace Ollyware.Flowlly.Core.API.Domain.Requests.Filters;

public class TaskFilters
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public TaskPriority? Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public bool? IsDeleted { get; set; }
}
