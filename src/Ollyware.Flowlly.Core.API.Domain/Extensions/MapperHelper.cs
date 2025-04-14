using AutoMapper;
using Ollyware.Flowlly.Core.API.Domain.Constants;

namespace Ollyware.Flowlly.Core.API.Domain.Extensions;

public static class MapperHelper
{
    public static object ToCommand(this IMapper mapper, object request)
    {
        var requestType = request.GetType();

        var requestTypeName = requestType.Name;

        if (!requestTypeName.EndsWith(CommonSequences.RequestType))
            throw new InvalidOperationException($"Request type {requestTypeName} does not follow naming convention 'Request'.");

        var commandTypeName = requestTypeName.Replace("Request", "Command");

        var commandType = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name == commandTypeName);

        return commandType is null
            ? throw new InvalidOperationException($"Could not resolve command type '{commandTypeName}' for request '{requestTypeName}'.")
            : mapper.Map(request, requestType, commandType);
    }

    public static T ToCommand<T>(this IMapper mapper, object request) => (T)mapper.ToCommand(request);
}
