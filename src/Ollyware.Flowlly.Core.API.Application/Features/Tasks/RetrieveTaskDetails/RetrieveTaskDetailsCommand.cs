using AutoMapper;
using MediatR;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Domain.Dtos;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.RetrieveTaskDetails;

public record struct RetrieveTaskDetailsCommand(Guid TaskId) : IRequest<RetrieveTaskDetailsCommandResponse> { }

public class RetrieveTaskDetailsCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<RetrieveTaskDetailsCommand, RetrieveTaskDetailsCommandResponse>
{
    public async Task<RetrieveTaskDetailsCommandResponse> Handle(RetrieveTaskDetailsCommand request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.Tasks.GetRecordById(request.TaskId);

        if (task is null)
            return RetrieveTaskDetailsCommandResponse.Orchestrator(null, "Task not found");

        var dto = _mapper.Map<TaskDto>(task);

        return RetrieveTaskDetailsCommandResponse.Orchestrator(dto);
    }
}
