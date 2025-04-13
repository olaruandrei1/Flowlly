namespace Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

public class ApiResponse<T>
{
    public T? Data { get; private set; }
    public bool IsSuccess { get; private set; }

    public static ApiResponse<T> Success(T? data)
    => new()
    {
        IsSuccess = true,
        Data = data
    };

    public static ApiResponse<T> Failure()
    => new()
    {
        IsSuccess = false
    };
}

public class ApiResponse
{
    public bool IsSuccess { get; private set; }

    public static ApiResponse Success()
    => new()
    {
        IsSuccess = true
    };

    public static ApiResponse Failure()
    => new()
    {
        IsSuccess = false
    };
}
