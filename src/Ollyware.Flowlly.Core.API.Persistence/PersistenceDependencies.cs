using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories;
using Ollyware.Flowlly.Core.API.Domain.ConfigurableObjects;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseConnectionFactory;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts;
using Ollyware.Flowlly.Core.API.Persistence.Repositories;

namespace Ollyware.Flowlly.Core.API.Persistence;

public static class PersistenceDependencies
{
    public static IServiceCollection PersistenceRegister(this IServiceCollection services, ConnectionStrings connectionStrings)
    => services.AddSingleton<IDbConnectionFactory>(new DbConnectionFactory(connectionStrings))
               .AddDbContext<UserContext>(options => options.UseSqlite(connectionStrings.SqlLite))
               .AddDbContext<ConfigurationContext>(options => options.UseSqlite(connectionStrings.SqlLite))
               .AddDbContext<ExpensesContext>(options => options.UseSqlite(connectionStrings.SqlLite))
               .AddDbContext<HabitsContext>(options => options.UseSqlite(connectionStrings.SqlLite))
               .AddDbContext<NotesContext>(options => options.UseSqlite(connectionStrings.SqlLite))
               .AddDbContext<TasksContext>(options => options.UseSqlite(connectionStrings.SqlLite))
               .AddScoped<IUserRepository, UserRepository>()
               .AddScoped<IConfigurationsRepository, ConfigurationsRepository>()
               .AddScoped<IExpensesRepository, ExpensesRepository>()
               .AddScoped<IHabitsRepository, HabitsRepository>()
               .AddScoped<INotesRepository, NotesRepository>()
               .AddScoped<ITasksRepository, TasksRepository>()
               .AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
}
