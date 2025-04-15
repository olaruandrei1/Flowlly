using Ollyware.Flowlly.Core.API.Domain.Dtos;
using Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.RetrieveTaskDetails;

public class RetrieveTaskDetailsCommandResponse : StandardCommandResponse 
{
    public TaskDto? Task { get; set; }

    public static RetrieveTaskDetailsCommandResponse Orchestrator(TaskDto? dto, string? notFoundMessage = null)
    {
        var response = new RetrieveTaskDetailsCommandResponse();

        if (dto is null)
            response.IsFailure(notFoundMessage ?? "Resource not found");
        else
        {
            response.IsSuccess("Task found");
            response.Task = dto;
        }

        return response;
    }

    public override object RetrieveObject() => new { Success, Message, Task };
}