using MediatR;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.DeleteTask;

public record struct DeleteTaskCommand(Guid TaskId) : IRequest<DeleteTaskCommandResponse> { }

public class DeleteTaskCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTaskCommand, DeleteTaskCommandResponse>
{
    public async Task<DeleteTaskCommandResponse> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        return new();
    }
}
