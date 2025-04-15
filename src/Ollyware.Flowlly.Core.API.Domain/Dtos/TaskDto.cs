using Ollyware.Flowlly.Core.API.Domain.Constants;

namespace Ollyware.Flowlly.Core.API.Domain.Dtos;

public class TaskDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public TaskPriority Priority { get; set; }
    public Constants.TaskStatus Status { get; set; }
    public List<string>? Tags { get; set; }
    public double? EstimatedTime { get; set; }
    public string? Category { get; set; }
    public bool Recurring { get; set; }
    public int? RepeatIntervalDays { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
