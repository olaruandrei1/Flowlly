using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories;
using Ollyware.Flowlly.Core.API.Domain.Entities;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts.BaseContext;

namespace Ollyware.Flowlly.Core.API.Persistence.Repositories;

internal class HabitsRepository(HabitsContext _habitsContext) : InitiateRepository<HabitEntity>(_habitsContext), IHabitsRepository
{
}
