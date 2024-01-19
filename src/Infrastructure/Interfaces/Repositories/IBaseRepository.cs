namespace Infrastructure.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task InsertAsync(T entity, CancellationToken cancellation = default);
    
    Task RemoveAsync(int id, CancellationToken cancellation = default);
    
    Task UpdateAsync(int id, T entity, CancellationToken cancellation = default);
    
    Task<T> GetOneAsync(int id, CancellationToken cancellation = default);
    
    Task<IEnumerable<T>> GetManyAsync(int skip, int take, CancellationToken cancellation = default);
}
