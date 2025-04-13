using Ollyware.Flowlly.Core.API.Application;
using Ollyware.Flowlly.Core.API.Infrastructure;
using Ollyware.Flowlly.Core.API.Persistence;

namespace Ollyware.Flowlly.Core.API.Helpers;

public static class DIRegister
{
    public static void RegisterDI(this IServiceCollection services)
    {
        services.ApplicationRegister();
        services.InfrastructureRegister();
        services.PersistenceRegister();
    }
}
