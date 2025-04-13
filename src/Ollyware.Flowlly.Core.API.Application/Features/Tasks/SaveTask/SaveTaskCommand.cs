using AutoMapper;
using MediatR;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.SaveTask;

public record struct SaveTaskCommand(string Title, string? Description, DateTime? DueDate) : IRequest<SaveTaskCommandResponse>;

public class SaveTaskCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<SaveTaskCommand, SaveTaskCommandResponse>
{
    public async Task<SaveTaskCommandResponse> Handle(SaveTaskCommand request, CancellationToken cancellationToken)
    {
        return new();
    }
}
