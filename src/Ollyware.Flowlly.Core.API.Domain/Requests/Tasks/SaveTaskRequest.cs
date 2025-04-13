namespace Ollyware.Flowlly.Core.API.Domain.Requests.Tasks;

public class SaveTaskRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
}
