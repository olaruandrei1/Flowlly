using Microsoft.EntityFrameworkCore;
using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;
using Ollyware.Flowlly.Core.API.Domain.Entities;

namespace Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts.BaseContext;

public class InitiateRepository<T>(DbContext _context) : IInitiateRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = _context.Set<T>();

    public async Task<List<T>> GetAllRecords() => await _dbSet.ToListAsync();
    public async Task<T?> GetRecordById(Guid id) => await _dbSet.FindAsync(id);
    public async Task SaveRecord(T entity) => await _dbSet.AddAsync(entity);
    public Task UpdateRecord(T entity) => Task.FromResult(_dbSet.Update(entity));
    public async Task DeleteRecord(Guid? id = null, T? entity = null)
    {
        var toDelete = entity ?? await GetRecordById((Guid)id);

        if (toDelete is not null) { _dbSet.Remove(toDelete); }
    }

    public IQueryable<T> Query() => _dbSet.AsQueryable<T>();
}
