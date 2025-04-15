using MediatR;
using Serilog;
using System.Reflection;

namespace Ollyware.Flowlly.Core.API.Application.PipelineBehaviours;

public class LoggingBehaviour<TIn, TOut>(ILogger _logger) : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
{
    public async Task<TOut> Handle(TIn request, RequestHandlerDelegate<TOut> next, CancellationToken cancellationToken)
    {
        _logger.Information($"Handling {typeof(TIn).Name}");

        List<PropertyInfo> props = new(typeof(TIn).GetProperties());

        props.ForEach(prop =>
        {
            _logger.Information("{Property} : {@Value}", prop.Name, prop.GetValue(request, null));
        });

        var response = await next();

        _logger.Information($"Handled {typeof(TOut).Name}");

        return response;
    }
}
