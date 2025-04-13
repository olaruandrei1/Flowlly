using Ollyware.Flowlly.Core.API.Domain.Errors;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Ollyware.Flowlly.Core.API.Middleware;

public class TraceMiddleware(RequestDelegate _next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var (statusCode, responseObj) = HandleException(ex);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var responseJson = JsonSerializer.Serialize(responseObj);

            await context.Response.WriteAsync(responseJson);
        }
    }

    private static (int statusCode, object responseObj) HandleException(Exception ex) => ex switch
    {
        ValidationException ve => (StatusCodes.Status400BadRequest, ve.Message),
        _ => (StatusCodes.Status500InternalServerError, new BaseError(Code: StatusCodes.Status500InternalServerError, Message: ex.Message))
    };
}
