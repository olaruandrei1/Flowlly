using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ollyware.Flowlly.Core.API.Application.PipelineBehaviours;
using System.Reflection;

namespace Ollyware.Flowlly.Core.API.Application;

public static class ApplicationDependencies
{
    private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();

    public static IServiceCollection ApplicationRegister(this IServiceCollection services)
    => services.AddAutoMapper(_assembly)
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(_assembly))
            .AddValidatorsFromAssembly(_assembly)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
}
