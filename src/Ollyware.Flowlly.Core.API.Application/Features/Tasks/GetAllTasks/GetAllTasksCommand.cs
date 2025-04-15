using AutoMapper;
using MediatR;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Domain.Dtos;
using Ollyware.Flowlly.Core.API.Domain.Entities;
using Ollyware.Flowlly.Core.API.Domain.Extensions;
using Ollyware.Flowlly.Core.API.Domain.Requests.Bases;
using Ollyware.Flowlly.Core.API.Domain.Requests.Filters;
using Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.GetAllTasks;

public record struct GetAllTasksCommand(PaginationRequest<TaskFilters> PaginationRequest) : IRequest<GetAllTasksCommandResponse> { }

public class GetAllTasksCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetAllTasksCommand, GetAllTasksCommandResponse>
{
    public async Task<GetAllTasksCommandResponse> Handle(GetAllTasksCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Tasks.GetAll(request.PaginationRequest, cancellationToken);

        var dtoList = _mapper.Map<List<TaskDto>>(result.Items);

        var responseData = new PaginationResult<TaskDto>
        {
            Items = dtoList,
            TotalItems = result.TotalItems,
            Page = result.Page,
            PageSize = result.PageSize
        };

        return GetAllTasksCommandResponse.Orchestrator(responseData);
    }
}
