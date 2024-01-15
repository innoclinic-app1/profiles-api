using Domain.Entities;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class ReceptionistRepository : BaseRepository<Receptionist>, IReceptionistRepository
{
    public ReceptionistRepository(DataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Receptionist>> GetManyAsync(string name, int skip, int take, CancellationToken cancellationToken = default)
    {
        var query = Context.Receptionists.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(name))
        {
            query = GetByName(query, name);
        }
        
        return await GetManyAsync(query, skip, take, cancellationToken);
    }

    private static IQueryable<Receptionist> GetByName(IQueryable<Receptionist> query, string name)
    {
        var searchName = name.ToLower();
        
        var result = query.Where(d =>
                d.FirstName.ToLower().Contains(searchName) || d.LastName.ToLower().Contains(searchName) ||
                (d.MiddleName != null && d.MiddleName.ToLower().Contains(searchName))
                );
        
        return result;
    }
}
