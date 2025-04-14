using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json;

namespace Ollyware.Flowlly.Core.API.Helpers;

public class BaseController : ControllerBase
{
    protected void LogException(HttpContext context, object? request = null, Exception? ex = null)
    => Log.Error
        (
            exception: ex,
            messageTemplate: "{message},{machineName},{innerException},{stackTrace},{exMessage},{timestamp},{request}",
            propertyValues:
            [
                ex?.Message,
                Environment.MachineName,
                ex?.InnerException,
                ex?.StackTrace,
                ex?.Message,
                DateTime.Now,
                request
            ]
        );

    protected void LogInformation(HttpContext context, string? message = "Api call finalized with success!", object? request = null, object? response = null)
    {
        var serializedRequest = JsonSerializer.Serialize(request);
        var serializedResponse = JsonSerializer.Serialize(response);

        Log.Information
            (
                messageTemplate: "{message},{machineName},{path},{method},{timestamp},{request},{response}",
                propertyValues:
                [
                    message,
                    Environment.MachineName,
                    context.Request.Path,
                    context.Request.Method,
                    DateTime.Now,
                    serializedRequest,
                    serializedResponse
                ]
            );
    }
}
