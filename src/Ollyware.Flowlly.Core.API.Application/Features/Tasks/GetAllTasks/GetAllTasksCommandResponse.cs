using Ollyware.Flowlly.Core.API.Domain.Dtos;
using Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.GetAllTasks;

public class GetAllTasksCommandResponse : StandardCommandResponse
{
    public PaginationResult<TaskDto>? Data { get; set; }

    public static GetAllTasksCommandResponse Orchestrator(PaginationResult<TaskDto> result)
    {
        var response = new GetAllTasksCommandResponse
        {
            Data = result
        };

        response.IsSuccess("Tasks retrieved successfully");
        return response;
    }

    public override object RetrieveObject() => new { Success, Message, Data };
}