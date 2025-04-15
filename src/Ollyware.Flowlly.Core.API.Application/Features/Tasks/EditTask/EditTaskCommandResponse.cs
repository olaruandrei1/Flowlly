using Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.EditTask;

public class EditTaskCommandResponse : StandardCommandResponse 
{
    public static EditTaskCommandResponse Orchestrator(bool updated)
    {
        var response = new EditTaskCommandResponse();

        if (updated)
            response.IsSuccess("Task updated successfully");
        else
            response.IsFailure("Task not found or failed to update");

        return response;
    }

    public override object RetrieveObject() => new { Success, Message };
}