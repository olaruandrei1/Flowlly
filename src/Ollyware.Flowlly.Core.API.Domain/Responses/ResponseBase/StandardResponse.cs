namespace Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

public class StandardResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public static StandardResponse IsSuccess(string? message = null) => new() { Success = true, Message = message };
    public static StandardResponse IsFailure(string? message) => new() { Success = false, Message = message };
}
