using Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.DeleteTask;

public class DeleteTaskCommandResponse : StandardCommandResponse 
{
    public static DeleteTaskCommandResponse Orchestrator(bool wasDeleted)
    {
        var response = new DeleteTaskCommandResponse();

        if (wasDeleted)
            response.IsSuccess("Task deleted successfully");
        else
            response.IsFailure("Task not found or already deleted");

        return response;
    }

    public override object RetrieveObject() => new { Success, Message };
}