using Ollyware.Flowlly.Core.API.Domain.Constants;

namespace Ollyware.Flowlly.Core.API.Domain.Requests.Tasks;

public class EditTaskRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public TaskPriority Priority { get; set; } = TaskPriority.Low;
    public Constants.TaskStatus Status { get; set; } = Constants.TaskStatus.ToDo;
    public List<string>? Tags { get; set; }
    public double? EstimatedTime { get; set; }
    public Guid? AssignedToUserId { get; set; }
    public string? Category { get; set; }
    public bool Recurring { get; set; }
    public int? RepeatIntervalDays { get; set; }
    public string? Comment { get; set; }
}
