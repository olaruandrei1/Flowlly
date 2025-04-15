using AutoMapper;
using MediatR;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Domain.Constants;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.EditTask;

public readonly record struct EditTaskCommand(
    Guid Id,
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
) : IRequest<EditTaskCommandResponse>;

public class EditTaskCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<EditTaskCommand, EditTaskCommandResponse>
{
    public async Task<EditTaskCommandResponse> Handle(EditTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.Tasks.GetRecordById(request.Id);
        
        if (task is null || task.IsDeleted)
            return EditTaskCommandResponse.Orchestrator(false);

        _mapper.Map(request, task); 
        
        await _unitOfWork.Tasks.UpdateRecord(task);
        
        var result = await _unitOfWork.SaveChangesAsync();

        return EditTaskCommandResponse.Orchestrator(result > 0);
    }
}
