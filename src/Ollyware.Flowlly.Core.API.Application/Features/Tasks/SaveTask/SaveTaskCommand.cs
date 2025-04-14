using AutoMapper;
using MediatR;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Domain.Constants;
using Ollyware.Flowlly.Core.API.Domain.Entities;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.SaveTask;

public record struct SaveTaskCommand(
    string Title,
    string? Description,
    DateTime? DueDate,
    TaskPriority Priority,
    Domain.Constants.TaskStatus Status,
    List<string>? Tags,
    double? EstimatedTime,
    string? Category,
    bool Recurring,
    int? RepeatIntervalDays,
    string? Comment
) : IRequest<SaveTaskCommandResponse>;

public class SaveTaskCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<SaveTaskCommand, SaveTaskCommandResponse>
{
    public async Task<SaveTaskCommandResponse> Handle(SaveTaskCommand request, CancellationToken cancellationToken)
    {
        TaskEntity taskEntity = _mapper.Map<TaskEntity>(request);

        await _unitOfWork.Tasks.SaveRecord(taskEntity);

        int result = await _unitOfWork.SaveChangesAsync();

        return SaveTaskCommandResponse.Orchestrator
            (
                (saveChangesValue: result, taskId: taskEntity.Id)
            );
    }
}
