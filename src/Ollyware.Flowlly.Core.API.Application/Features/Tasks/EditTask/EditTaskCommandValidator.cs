using FluentValidation;

namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.EditTask;

public class EditTaskCommandValidator : AbstractValidator<EditTaskCommand>
{
    public EditTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Task ID is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title can't be longer than 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description can't exceed 500 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));

        RuleFor(x => x.EstimatedTime)
            .GreaterThan(0).WithMessage("Estimated time must be greater than zero.")
            .When(x => x.EstimatedTime.HasValue);

        RuleFor(x => x.Category)
            .MaximumLength(50).WithMessage("Category can't exceed 50 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Category));

        RuleFor(x => x.RepeatIntervalDays)
            .GreaterThan(0).WithMessage("Repeat interval must be greater than zero.")
            .When(x => x.Recurring);

        RuleFor(x => x.Comment)
            .MaximumLength(300).WithMessage("Comment can't exceed 300 characters.");
    }
}