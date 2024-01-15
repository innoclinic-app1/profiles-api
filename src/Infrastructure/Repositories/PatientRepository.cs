using Domain.Entities;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(DataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Patient>> GetManyAsync(string name, int skip, int take, CancellationToken cancellationToken = default)
    {
        var query = Context.Patients.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(name))
        {
            query = GetByName(query, name);
        }
        
        return await GetManyAsync(query, skip, take, cancellationToken);
    }
    
    private static IQueryable<Patient> GetByName(IQueryable<Patient> query, string name)
    {
        var searchName = name.ToLower();
        
        var result = query.Where(d =>
                d.FirstName.ToLower().Contains(searchName) || d.LastName.ToLower().Contains(searchName) ||
                (d.MiddleName != null && d.MiddleName.ToLower().Contains(searchName))
            );
        
        return result;
    }
}
