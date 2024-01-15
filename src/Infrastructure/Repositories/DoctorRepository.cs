using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Status = Domain.Enums.EmployeeStatus;

namespace Infrastructure.Repositories;

public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(DataContext context) : base(context)
    {
    }

    public async Task ChangeStatusAsync(int id, Status status)
    {
        var doctor = await GetByIdAsync(id);

        doctor.Status = status;
        
        await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Doctor>> GetManyAsync(string name, int officeId, int specializationId, int skip, int take,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Doctors.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = GetByName(query, name);
        }
        
        if (officeId != 0)
        {
            query = GetByOffice(query, officeId);
        }
        
        if (specializationId != 0)
        {
            query = GetBySpecialization(query, specializationId);
        }

        return await GetManyAsync(query, skip, take, cancellationToken);
    }

    private static IQueryable<Doctor> GetByName(IQueryable<Doctor> query, string name)
    {
        var searchName = name.ToLower();
        
        var result = query.Where(d => 
            d.FirstName.ToLower().Contains(searchName) || 
            d.LastName.ToLower().Contains(searchName) || 
            (d.MiddleName != null && d.MiddleName.ToLower().Contains(searchName))
            );
        
        return result;
    }

    private static IQueryable<Doctor> GetByOffice(IQueryable<Doctor> query, int officeId)
    {
        var result = query.Where(d => d.OfficeId == officeId);

        return result;
    }

    private static IQueryable<Doctor> GetBySpecialization(IQueryable<Doctor> query, int specializationId)
    {
        return query.Where(d => d.SpecializationId == specializationId);
    }
}
