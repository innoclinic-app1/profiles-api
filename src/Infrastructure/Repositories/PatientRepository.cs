using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(DataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Patient>> GetManyAsync(string name, int skip, int take,
        CancellationToken cancellation = default)
    {
        var query = Context.Patients.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(name))
        {
            query = GetByName(query, name);
        }
        
        return await GetManyAsync(query, skip, take, cancellation);
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

    public override async Task UpdateAsync(int id, Patient entity, CancellationToken cancellation = default)
    {
        try
        {
            await Context.Patients
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.FirstName, entity.FirstName)
                    .SetProperty(e => e.LastName, entity.LastName)
                    .SetProperty(e => e.MiddleName, entity.MiddleName)
                    .SetProperty(e => e.BirthDate, entity.BirthDate));
        }
        catch (ArgumentNullException)
        {
            throw new NotFoundException<Patient>(id);
        }
    }
}
