using Microsoft.Extensions.DependencyInjection;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts;
using Ollyware.Flowlly.Core.API.Persistence.Repositories;

namespace Ollyware.Flowlly.Core.API.Persistence.UnitOfWork.Configurations;

public abstract class BaseUnitOfWorkDependencies
{
    protected readonly IServiceProvider _serviceProvider;

    protected readonly Lazy<UserContext> _userDbContext;
    protected readonly Lazy<IUserRepository> _userRepository;

    protected readonly Lazy<ConfigurationContext> _configurationDbContext;
    protected readonly Lazy<IConfigurationsRepository> _configurationsRepository;

    protected readonly Lazy<ExpensesContext> _expensesContext;
    protected readonly Lazy<IExpensesRepository> _expensesRepository;

    protected readonly Lazy<HabitsContext> _habitsContext;
    protected readonly Lazy<IHabitsRepository> _habitsRepository;

    protected readonly Lazy<NotesContext> _notesContext;
    protected readonly Lazy<INotesRepository> _notesRepository;

    protected readonly Lazy<TasksContext> _tasksContext;
    protected readonly Lazy<ITasksRepository> _tasksRepository;

    protected BaseUnitOfWorkDependencies(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        _userDbContext = new Lazy<UserContext>(() => _serviceProvider.GetRequiredService<UserContext>());
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_userDbContext.Value));

        _configurationDbContext = new Lazy<ConfigurationContext>(() => _serviceProvider.GetRequiredService<ConfigurationContext>());
        _configurationsRepository = new Lazy<IConfigurationsRepository>(() => new ConfigurationsRepository(_configurationDbContext.Value));

        _expensesContext = new Lazy<ExpensesContext>(() => _serviceProvider.GetRequiredService<ExpensesContext>());
        _expensesRepository = new Lazy<IExpensesRepository>(() => new ExpensesRepository(_expensesContext.Value));

        _habitsContext = new Lazy<HabitsContext>(() => _serviceProvider.GetRequiredService<HabitsContext>());
        _habitsRepository = new Lazy<IHabitsRepository>(() => new HabitsRepository(_habitsContext.Value));

        _notesContext = new Lazy<NotesContext>(() => _serviceProvider.GetRequiredService<NotesContext>());
        _notesRepository = new Lazy<INotesRepository>(() => new NotesRepository(_notesContext.Value));

        _tasksContext = new Lazy<TasksContext>(() => _serviceProvider.GetRequiredService<TasksContext>());
        _tasksRepository = new Lazy<ITasksRepository>(() => new TasksRepository(_tasksContext.Value));
    }
}
