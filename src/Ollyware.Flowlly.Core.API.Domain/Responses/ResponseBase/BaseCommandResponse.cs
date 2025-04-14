namespace Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

public abstract class BaseCommandResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public virtual object RetrieveObject() => this;

    protected virtual void IsSuccess(string? message)
    {
        Success = true;
        Message = message;
    }

    protected virtual void IsFailure(string message)
    {
        Success = false;
        Message = message;
    }

    public static T Ok<T>(string? message = null) where T : BaseCommandResponse, new()
    {
        var response = new T();
        response.IsSuccess(message);

        return response;
    }

    public static T Fail<T>(string message) where T : BaseCommandResponse, new()
    {
        var response = new T();
        response.IsFailure(message);

        return response;
    }
}
