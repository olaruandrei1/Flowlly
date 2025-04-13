using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Domain.Entities;

namespace Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories
{
    public interface ITasksRepository : IInitiateRepository<TaskEntity>
    {
    }
}
