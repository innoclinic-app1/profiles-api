using Domain.Exceptions;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected DataContext Context { get; }

    protected BaseRepository(DataContext context)
    {
        Context = context;
    }
    
    public async Task InsertAsync(T entity, CancellationToken cancellation = default)
    {
        await Context.Set<T>().AddAsync(entity, cancellation);
        
        await Context.SaveChangesAsync(cancellation);
    }

    public async Task RemoveAsync(T entity, CancellationToken cancellation = default)
    {
        Context.Set<T>().Remove(entity);
        
        await Context.SaveChangesAsync(cancellation);
    }

    public async Task RemoveAsync(int id, CancellationToken cancellation = default)
    {
        var entity = await GetOneAsync(id, cancellation);
        
        await RemoveAsync(entity, cancellation);
    }

    public abstract Task UpdateAsync(int id, T entity, CancellationToken cancellation = default);
    
    public async Task<T> GetOneAsync(int id, CancellationToken cancellation = default)
    {
        var entity = await Context.Set<T>().FindAsync(id, cancellation) 
                     ?? throw new NotFoundException<T>(id);
        
        return entity;
    }

    public async Task<IEnumerable<T>> GetManyAsync(int skip, int take, CancellationToken cancellation = default)
    {
        return await Context.Set<T>().Skip(skip).Take(take).ToListAsync(cancellation);
    }

    protected async Task<IEnumerable<T>> GetManyAsync(IQueryable<T> query, int skip, int take,
        CancellationToken cancellation = default)
    {
        return await query.Skip(skip).Take(take).ToListAsync(cancellation);
    }
}
