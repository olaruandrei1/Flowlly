namespace Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Configurations;

public interface IInitiateRepository<T> where T : class
{
    Task<T?> GetRecordById(Guid id);
    Task<List<T>> GetAllRecords();
    Task SaveRecord(T entity);
    Task DeleteRecord(Guid? id = null, T? entity = null);
    Task UpdateAsync(T entity);
}
