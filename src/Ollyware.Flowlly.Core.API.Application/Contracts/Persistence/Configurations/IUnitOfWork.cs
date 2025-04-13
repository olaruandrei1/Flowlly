using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories;

namespace Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IConfigurationsRepository Configurations { get; }
    IExpensesRepository Expenses { get; }
    IHabitsRepository Habits { get; }
    INotesRepository Notes { get; }
    ITasksRepository Tasks { get; }

    Task<int> SaveChangesAsync();
}