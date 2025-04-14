using FluentValidation;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.RetrieveTaskDetails;

public class RetrieveTaskDetailsCommandValidator : AbstractValidator<RetrieveTaskDetailsCommand>
{
    public RetrieveTaskDetailsCommandValidator()
    {
        RuleFor(x => x.TaskId)
            .NotEmpty().WithMessage("Task ID must be provided.");
    }
}
