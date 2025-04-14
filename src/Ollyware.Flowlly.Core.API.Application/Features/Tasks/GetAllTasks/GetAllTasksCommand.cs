using AutoMapper;
using MediatR;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Domain.Requests.Bases;
using Ollyware.Flowlly.Core.API.Domain.Requests.Filters;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.GetAllTasks;

public record struct GetAllTasksCommand(PaginationRequest<TaskFilters> PaginationRequest) : IRequest<GetAllTasksCommandResponse> { }

public class GetAllTasksCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetAllTasksCommand, GetAllTasksCommandResponse>
{
    public async Task<GetAllTasksCommandResponse> Handle(GetAllTasksCommand request, CancellationToken cancellationToken)
    {
        return new();
    }
}
