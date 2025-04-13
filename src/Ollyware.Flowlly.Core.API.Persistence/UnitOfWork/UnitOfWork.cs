using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories;
using Ollyware.Flowlly.Core.API.Persistence.UnitOfWork.Configurations;

namespace Ollyware.Flowlly.Core.API.Persistence.UnitOfWork;

public sealed class UnitOfWork(IServiceProvider serviceProvider) : BaseUnitOfWorkDependencies(serviceProvider), IUnitOfWork, IDisposable
{
    public IUserRepository Users => _userRepository.Value;
    public IConfigurationsRepository Configurations => _configurationsRepository.Value;
    public IExpensesRepository Expenses => _expensesRepository.Value;
    public IHabitsRepository Habits => _habitsRepository.Value;
    public INotesRepository Notes => _notesRepository.Value;
    public ITasksRepository Tasks => _tasksRepository.Value;

    public async Task<int> SaveChangesAsync()
    {
        int changes = default;

        if (_userDbContext.IsValueCreated)
            changes += await _userDbContext.Value.SaveChangesAsync();

        if (_configurationDbContext.IsValueCreated)
            changes += await _configurationDbContext.Value.SaveChangesAsync();

        if (_expensesContext.IsValueCreated)
            changes += await _expensesContext.Value.SaveChangesAsync();

        if (_habitsContext.IsValueCreated)
            changes += await _habitsContext.Value.SaveChangesAsync();

        if (_notesContext.IsValueCreated)
            changes += await _notesContext.Value.SaveChangesAsync();

        if (_tasksContext.IsValueCreated)
            changes += await _tasksContext.Value.SaveChangesAsync();

        return changes;
    }

    public void Dispose()
    {
        if (_userDbContext.IsValueCreated)
            _userDbContext.Value.Dispose();

        if (_configurationDbContext.IsValueCreated)
            _configurationDbContext.Value.Dispose();

        if (_expensesContext.IsValueCreated)
            _expensesContext.Value.Dispose();

        if (_habitsContext.IsValueCreated)
            _habitsContext.Value.Dispose();

        if (_notesContext.IsValueCreated)
            _notesContext.Value.Dispose();

        if (_tasksContext.IsValueCreated)
            _tasksContext.Value.Dispose();

        GC.SuppressFinalize(this);
    }
}
