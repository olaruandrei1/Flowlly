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
    Guid? AssignedToUserId,
    string? Category,
    bool Recurring,
    int? RepeatIntervalDays,
    string? Comment
) : IRequest<EditTaskCommandResponse>;

public class EditTaskCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<EditTaskCommand, EditTaskCommandResponse>
{
    public async Task<EditTaskCommandResponse> Handle(EditTaskCommand request, CancellationToken cancellationToken)
    {
        return new();
    }
}
