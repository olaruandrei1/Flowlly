using MediatR;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.DeleteTask;

public record struct DeleteTaskCommand(Guid TaskId) : IRequest<DeleteTaskCommandResponse> { }

public class DeleteTaskCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTaskCommand, DeleteTaskCommandResponse>
{
    public async Task<DeleteTaskCommandResponse> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.TaskEntity? task = await _unitOfWork.Tasks.GetRecordById(request.TaskId);

        if (task is null || task.IsDeleted)
            return DeleteTaskCommandResponse.Orchestrator(false);

        task.IsDeleted = true;

        await _unitOfWork.Tasks.UpdateRecord(task);

        var result = await _unitOfWork.SaveChangesAsync();

        return DeleteTaskCommandResponse.Orchestrator(result > 0);
    }
}
