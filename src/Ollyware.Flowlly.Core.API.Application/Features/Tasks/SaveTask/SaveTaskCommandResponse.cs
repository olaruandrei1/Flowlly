using Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.SaveTask;

public class SaveTaskCommandResponse : StandardCommandResponse 
{
    public Guid TaskId { get; set; }

    public override object RetrieveObject()
    => new { Success, Message, TaskId };

    public static SaveTaskCommandResponse Orchestrator((int saveChangesValue, Guid taskId) values)
    {
        var response = Orchestrator<SaveTaskCommandResponse>(
            values.saveChangesValue,
            "Task created successfully",
            "Failed to create task"
        );

        response.TaskId = values.taskId;

        return response;
    }
}