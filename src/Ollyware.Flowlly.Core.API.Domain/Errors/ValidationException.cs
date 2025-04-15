using FluentValidation.Results;

namespace Ollyware.Flowlly.Core.API.Domain.Errors;

public class ValidationException : ApplicationException
{
    private const string GENERIC_ERROR_MESSAGE = @"One or more validations failed";
    public ValidationException() : base(message: GENERIC_ERROR_MESSAGE) { }

    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> ValidationErrors { get; set; }

    public ValidationException(List<ValidationFailure> failures) : base(message: GENERIC_ERROR_MESSAGE)
    {
        Success = false;
        Message = GENERIC_ERROR_MESSAGE;
        ValidationErrors = failures.Select(x => x.ErrorMessage).ToList();
    }
}
