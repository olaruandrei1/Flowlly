namespace Ollyware.Flowlly.Core.API.Application.Features.Tasks.GetAllTasks;

using FluentValidation;

public class GetAllTasksCommandValidator : AbstractValidator<GetAllTasksCommand>
{
    public GetAllTasksCommandValidator()
    {
        RuleFor(x => x.PaginationRequest.Page)
            .GreaterThan(0).WithMessage("Page must be greater than 0.");

        RuleFor(x => x.PaginationRequest.PageSize)
            .InclusiveBetween(1, 100).WithMessage("PageSize must be between 1 and 100.");

        When(x => x.PaginationRequest.Filter is not null, () =>
        {
            RuleFor(x => x.PaginationRequest.Filter!.Title)
                .MaximumLength(100).WithMessage("Title filter can't exceed 100 characters.")
                .When(f => !string.IsNullOrWhiteSpace(f.PaginationRequest.Filter!.Title));

            RuleFor(x => x.PaginationRequest.Filter!.Description)
                .MaximumLength(300).WithMessage("Description filter can't exceed 300 characters.")
                .When(f => !string.IsNullOrWhiteSpace(f.PaginationRequest.Filter!.Description));

            RuleFor(x => x.PaginationRequest.Filter!.DueDate)
                .GreaterThan(DateTime.Now.AddDays(-1)).WithMessage("Invalid due date. ")
                .When(f => f.PaginationRequest.Filter!.DueDate.HasValue);
        });
    }
}
