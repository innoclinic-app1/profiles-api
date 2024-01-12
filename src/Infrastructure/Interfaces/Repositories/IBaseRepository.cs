namespace Infrastructure.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task InsertAsync(T entity);
    
    Task RemoveAsync(T entity);
    
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    
    Task<IQueryable<T>> GetManyAsync(int skip, int take, CancellationToken cancellationToken = default);
    
    Task<IQueryable<T>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}
