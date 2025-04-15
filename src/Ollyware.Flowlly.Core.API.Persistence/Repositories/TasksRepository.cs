using Microsoft.EntityFrameworkCore;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories;
using Ollyware.Flowlly.Core.API.Domain.Entities;
using Ollyware.Flowlly.Core.API.Domain.Extensions;
using Ollyware.Flowlly.Core.API.Domain.Requests.Bases;
using Ollyware.Flowlly.Core.API.Domain.Requests.Filters;
using Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts.BaseContext;

namespace Ollyware.Flowlly.Core.API.Persistence.Repositories;

internal class TasksRepository(TasksContext _tasksContext) : InitiateRepository<TaskEntity>(_tasksContext), ITasksRepository
{
    public async Task<PaginationResult<TaskEntity>> GetAll(PaginationRequest<TaskFilters> request, CancellationToken cancellationToken)
    {
        var query = _tasksContext.Tasks.AsQueryable();

        if (request.Filter is not null)
            query = query.ApplyFilters(request.Filter);

        var totalItems = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginationResult<TaskEntity>
        {
            Items = items,
            TotalItems = totalItems,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
