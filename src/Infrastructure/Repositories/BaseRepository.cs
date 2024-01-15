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
    
    public async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<T>().AddAsync(entity, cancellationToken);
        
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
    {
        Context.Set<T>().Remove(entity);
        
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        
        await RemoveAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        Context.Set<T>().Update(entity);
        
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await Context.Set<T>().FindAsync(id, cancellationToken) 
                     ?? throw new NotFoundException<T>(id);
        
        return entity;
    }

    public async Task<IEnumerable<T>> GetManyAsync(int skip, int take, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().Skip(skip).Take(take).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetManyAsync(IQueryable<T> query, int skip, int take,
        CancellationToken cancellationToken = default)
    {
        return await query.Skip(skip).Take(take).ToListAsync(cancellationToken);
    }
}
