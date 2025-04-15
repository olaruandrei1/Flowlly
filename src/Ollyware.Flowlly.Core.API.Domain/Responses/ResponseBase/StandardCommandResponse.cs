namespace Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

public class StandardCommandResponse : BaseCommandResponse
{
    public override object RetrieveObject()
    => new { Success, Message };

    protected override void IsSuccess(string? message) => base.IsSuccess(message);
    protected override void IsFailure(string? message) => base.IsFailure(message);

    public static T Orchestrator<T>(int result, string successMessage = "Operation successful", string failureMessage = "Operation failed")
    where T : StandardCommandResponse, new()
    {
        var response = new T();

        if (result > 0)
            response.IsSuccess(successMessage);
        else
            response.IsFailure(failureMessage);

        return response;
    }
}
