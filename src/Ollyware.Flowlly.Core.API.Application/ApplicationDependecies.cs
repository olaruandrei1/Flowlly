using Microsoft.Extensions.DependencyInjection;

namespace Ollyware.Flowlly.Core.API.Application
{
    public static class ApplicationDependecies
    {
        public static IServiceCollection ApplicationRegister(this IServiceCollection services)
        { return services; }
    }
}
