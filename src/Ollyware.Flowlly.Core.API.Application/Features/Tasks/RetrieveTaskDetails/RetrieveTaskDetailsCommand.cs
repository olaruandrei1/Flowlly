using AutoMapper;
using MediatR;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.RetrieveTaskDetails;

public record struct RetrieveTaskDetailsCommand(Guid TaskId) : IRequest<RetrieveTaskDetailsCommandResponse> { }

public class RetrieveTaskDetailsCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<RetrieveTaskDetailsCommand, RetrieveTaskDetailsCommandResponse>
{
    public async Task<RetrieveTaskDetailsCommandResponse> Handle(RetrieveTaskDetailsCommand request, CancellationToken cancellationToken)
    {
        return new();
    }
}
