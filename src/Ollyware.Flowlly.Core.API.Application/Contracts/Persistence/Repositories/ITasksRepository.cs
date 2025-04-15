using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Domain.Entities;
using Ollyware.Flowlly.Core.API.Domain.Requests.Bases;
using Ollyware.Flowlly.Core.API.Domain.Requests.Filters;
using Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

namespace Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories;

public interface ITasksRepository : IInitiateRepository<TaskEntity>
{
    Task<PaginationResult<TaskEntity>> GetAll(PaginationRequest<TaskFilters> request, CancellationToken cancellationToken);
}
