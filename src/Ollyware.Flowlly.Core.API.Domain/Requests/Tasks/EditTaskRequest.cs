namespace Ollyware.Flowlly.Core.API.Domain.Requests.Tasks;

public class EditTaskRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
}
